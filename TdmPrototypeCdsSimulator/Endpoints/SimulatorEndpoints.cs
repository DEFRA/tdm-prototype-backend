using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using TdmPrototypeBackend.ASB;
using TdmPrototypeBackend.Matching;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeCdsSimulator.Config;
using TdmPrototypeCdsSimulator.Extensions;

namespace TdmPrototypeCdsSimulator.Endpoints;

public class SimulatorEndpoints2 { }
public static class SimulatorEndpoints
{
    private static string? _gatewayUrl;
    private const string BaseRoute = "simulator";

    public static void UseCdsSimulatorEndpoints(this IEndpointRouteBuilder app)
    {
        _gatewayUrl = app.ServiceProvider.GetService<IConfiguration>()?["GatewayUrl"]?.Trim('/');

        app.MapGet(BaseRoute + "/alvs-cds/send-decisions/{notificationId}/{scenario}", SendDecisionsAfterProxyAsync).AllowAnonymous();
        app.MapGet(BaseRoute + "/send-decisions/{notificationId}/{scenario}", SendDecisionsAsync).AllowAnonymous();
        app.MapGet(BaseRoute + "/cds/create-clearance-request/{notificationId}", CreateClearanceRequestsAfterProxyAsync).AllowAnonymous();
        app.MapGet(BaseRoute + "/create-clearance-request/{notificationId}", CreateClearanceRequestsAsync).AllowAnonymous();
        app.MapGet(BaseRoute + "/notification-received/{notificationId}", MatchNotification).AllowAnonymous();
        app.MapGet(BaseRoute + "/cds-received/{documentReference}", MatchCds).AllowAnonymous();
    }

    private static async Task<IResult> MatchNotification(
        IMatchingService matchingService,
        IStorageService<Notification> notificationService,
        string notificationId)
    {
        var notification = await notificationService.Find(notificationId);
        var matchResult = await matchingService.Match(MatchingReferenceNumber.FromIpaffs(notificationId, notification.IpaffsType.Value));

        return Results.Ok(matchResult);
    }

    private static async Task<IResult> MatchCds(
        IMatchingService matchingService,
        IStorageService<Movement> movementService,
        string movementId)
    {
        var movement = await movementService.Find(movementId);
        var document = movement.Items.First().Documents.First();
        var matchResult = await matchingService.Match(MatchingReferenceNumber.FromCds(document.DocumentReference, document.DocumentCode));

        return Results.Ok(matchResult);
    }

    private static async Task<IResult> CreateClearanceRequestsAsync(
        IMatchingService matchingService,
        IStorageService<Notification> notificationService,
        IStorageService<Movement> movementService,
        IBusService busService,
        CdsSimulatorConfig cdsSimulatorConfig,
        IHttpClientFactory httpClientFactory,
        [FromServices] ILogger<SimulatorEndpoints2> logger,
        string notificationId)
    {
        if (_gatewayUrl == null)
            return await CreateClearanceRequestsAfterProxyAsync(matchingService, notificationService, movementService, busService, cdsSimulatorConfig, logger, notificationId);

        var requestUri = $"{_gatewayUrl}/simulator-cds/create-clearance-request/{notificationId}";
        logger.LogInformation("Sending CreateClearanceRequests notification {NotificationId} to gateway {RequestUri}", notificationId, requestUri);
        var client = httpClientFactory.CreateClient("proxy");
        var response = await client.GetAsync(requestUri);
        logger.LogInformation("Got CreateClearanceRequests notification {NotificationId} response {StatusCode} from {RequestUri}", notificationId, response.StatusCode, requestUri);

        if (!response.IsSuccessStatusCode) return Results.StatusCode((int)response.StatusCode);

        var clearanceRequestJson = await response.Content.ReadAsStringAsync();
        logger.LogInformation("Responding CreateClearanceRequests notification {NotificationId} from {RequestUri}", notificationId, requestUri);
        return TypedResults.Text(clearanceRequestJson);
    }

    private static async Task<IResult> CreateClearanceRequestsAfterProxyAsync(
        IMatchingService matchingService,
        IStorageService<Notification> notificationService,
        IStorageService<Movement> movementService,
        IBusService busService,
        CdsSimulatorConfig cdsSimulatorConfig,
        [FromServices] ILogger<SimulatorEndpoints2> logger,
        string notificationId)
    {
        logger.LogInformation("Processing CreateClearanceRequests notification {NotificationId} from gateway", notificationId);
        var notification = await notificationService.Find(notificationId);

        if (notification is null)
        {
            return Results.NotFound(notificationId);
        }

        var clearanceRequest = ALVSClearanceRequestBuilder.BuildFromNotification(notification);
        var now = DateTime.UtcNow;

        if (cdsSimulatorConfig.BypassAsb)
        {
            var movement = new Movement
            {
                Id = clearanceRequest.Header!.EntryReference,
                LastUpdated = clearanceRequest.ServiceHeader?.ServiceCallTimestamp,
                EntryReference = clearanceRequest.Header.EntryReference,
                MasterUCR = clearanceRequest.Header.MasterUCR,
                // DeclarationPartNumber = ConvertInt(r.Header.DeclarationPartNumber),
                DeclarationType = clearanceRequest.Header.DeclarationType,
                // ArrivalDateTime = r.Header.ArrivalDateTime,
                SubmitterTURN = clearanceRequest.Header.SubmitterTURN,
                DeclarantId = clearanceRequest.Header.DeclarantId,
                DeclarantName = clearanceRequest.Header.DeclarantName,
                DispatchCountryCode = clearanceRequest.Header.DispatchCountryCode,
                GoodsLocationCode = clearanceRequest.Header.GoodsLocationCode,
                ClearanceRequests = new List<AlvsClearanceRequest>() { clearanceRequest },
                Items = clearanceRequest.Items?.Select(x =>
                {
                    x.ClearanceRequestReference = clearanceRequest.Header.EntryReference;
                    return x;
                }).ToList(),
                AuditEntries =
                [
                    new AuditEntry
                    {
                        CreatedLocal = now,
                        CreatedSource = now,
                        CreatedBy = "CDS Simulator",
                        Status = "Created",
                        Version = 1
                    }
                ]
            };

            var document = clearanceRequest.Items.First().Documents.First();
            await movementService.Upsert(movement);
            var matchResult = await matchingService.Match(MatchingReferenceNumber.FromCds(document.DocumentReference, document.DocumentCode));
            logger.LogInformation("Found CreateClearanceRequests notification {NotificationId} with match {Match} from gateway", notificationId, matchResult.Matched);
            return Results.Ok(new { clearanceRequest, matchResult });
        }

        await busService.SendMessageAsync(clearanceRequest);

        return Results.Ok(clearanceRequest);
    }

    private static async Task<IResult> SendDecisionsAsync(
        IMatchingService matchingService,
        IStorageService<Notification> notificationService,
        MatchingStorageService<Movement> movementService,
        IBusService busService,
        CdsSimulatorConfig cdsSimulatorConfig,
        IHttpClientFactory httpClientFactory,
        [FromServices] ILogger<SimulatorEndpoints2> logger,
        string notificationId,
        string scenario)
    {
        if (_gatewayUrl == null)
            return await SendDecisionsAfterProxyAsync(matchingService, notificationService, movementService, busService, cdsSimulatorConfig, logger, notificationId, scenario);

        var requestUri = $"{_gatewayUrl}/simulator-alvs-cds/send-decisions/{notificationId}/{scenario}";
        logger.LogInformation("Sending SendDecisions notification {NotificationId} to gateway {RequestUri}", notificationId, requestUri);
        var client = httpClientFactory.CreateClient("proxy");
        var response = await client.GetAsync(requestUri);
        logger.LogInformation("Got SendDecisions notification {NotificationId} response {StatusCode} from {RequestUri}", notificationId, response.StatusCode, requestUri);

        if (!response.IsSuccessStatusCode) return Results.StatusCode((int)response.StatusCode);

        var clearanceRequestJson = await response.Content.ReadAsStringAsync();
        logger.LogInformation("Responding SendDecisions notification {NotificationId} from {RequestUri}", notificationId, requestUri);
        return TypedResults.Text(clearanceRequestJson);
    }

    private static async Task<IResult> SendDecisionsAfterProxyAsync(
        IMatchingService matchingService,
        IStorageService<Notification> notificationService,
        MatchingStorageService<Movement> movementService,
        IBusService busService,
        CdsSimulatorConfig cdsSimulatorConfig,
        [FromServices] ILogger<SimulatorEndpoints2> logger,
        string notificationId,
        string scenario)
    {
        logger.LogInformation("Processing SendDecisions notification {NotificationId} from gateway", notificationId);
        var notification = await notificationService.Find(notificationId);

        if (notification is null)
        {
            return Results.NotFound(notificationId);
        }

        var movements = await movementService.Filter(Builders<Movement>.Filter.AnyIn(x => x._MatchReferences, [notification._MatchReference]));

        foreach (var movement in movements)
        {
            foreach (var request in movement.ClearanceRequests)
            {
                // TODO - support more complex scenarios
                var decisionCode = scenario == "hold" ? "H02" : "C02";
                var decision = ALVSClearanceRequestBuilder.BuildDecision(request, decisionCode);
                var existingMovement = await movementService.Find(decision.Header!.EntryReference);

                if (cdsSimulatorConfig.BypassAsb)
                {
                    var merged = existingMovement.MergeDecision("CreatedCdsSim", decision);
                    if (merged)
                    {
                        await movementService.Upsert(existingMovement);
                    }
                }
                else
                {
                    await busService.SendMessageAsync(decision);
                }
            }
        }

        var clearanceRequest = ALVSClearanceRequestBuilder.BuildFromNotification(notification);
        var now = DateTime.UtcNow;

        if (cdsSimulatorConfig.BypassAsb)
        {
            var movement = new Movement
            {
                Id = clearanceRequest.Header!.EntryReference,
                LastUpdated = clearanceRequest.ServiceHeader?.ServiceCallTimestamp,
                EntryReference = clearanceRequest.Header.EntryReference,
                MasterUCR = clearanceRequest.Header.MasterUCR,
                // DeclarationPartNumber = ConvertInt(r.Header.DeclarationPartNumber),
                DeclarationType = clearanceRequest.Header.DeclarationType,
                // ArrivalDateTime = r.Header.ArrivalDateTime,
                SubmitterTURN = clearanceRequest.Header.SubmitterTURN,
                DeclarantId = clearanceRequest.Header.DeclarantId,
                DeclarantName = clearanceRequest.Header.DeclarantName,
                DispatchCountryCode = clearanceRequest.Header.DispatchCountryCode,
                GoodsLocationCode = clearanceRequest.Header.GoodsLocationCode,
                ClearanceRequests = new List<AlvsClearanceRequest>() { clearanceRequest },
                Items = clearanceRequest.Items?.Select(x =>
                {
                    x.ClearanceRequestReference = clearanceRequest.Header.EntryReference;
                    return x;
                }).ToList(),
                AuditEntries =
                [
                    new AuditEntry()
                    {
                        CreatedLocal = now,
                        CreatedSource = now,
                        CreatedBy = "CDS Simulator",
                        Status = "Created",
                        Version = 1
                    }
                ]
            };

            var document = clearanceRequest.Items.First().Documents.First();
            await movementService.Upsert(movement);
            var matchResult = await matchingService.Match(MatchingReferenceNumber.FromCds(document.DocumentReference, document.DocumentCode));
            logger.LogInformation("Found SendDecisions notification {NotificationId} with match {Match} from gateway", notificationId, matchResult.Matched);
            return Results.Ok(new { clearanceRequest, matchResult });
        }

        await busService.SendMessageAsync(clearanceRequest);

        return Results.Ok(clearanceRequest);
    }
}