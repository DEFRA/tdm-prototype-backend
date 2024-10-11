using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TdmPrototypeBackend.ASB;
using TdmPrototypeBackend.Matching;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeCdsSimulator.Config;
using TdmPrototypeCdsSimulator.Extensions;

namespace TdmPrototypeCdsSimulator.Endpoints;

public static class ClearanceRequestEndpoints
{
    private const string BaseRoute = "simulator";
    public static void UseClearanceRequestEndpoints(this IEndpointRouteBuilder app)
    {
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
        CdsSimulatorConfig config,
        string notificationId)
    {
        var notification = await notificationService.Find(notificationId);

        if (notification is null)
        {
            return Results.NotFound(notificationId);
        }
       

        ALVSClearanceRequest clearanceRequest = ALVSClearanceRequestBuilder.BuildFromNotification(notification);
        var now = DateTime.UtcNow;

        if (config.BypassAsb)
        {
            var movement = new Movement()
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
                ClearanceRequests = new List<ALVSClearanceRequest>() { clearanceRequest },
                Items = clearanceRequest.Items?.Select(x =>
                {
                    x.ClearanceRequestReference = clearanceRequest.Header.EntryReference;
                    return x;
                }).ToList(),
                AuditEntries = [new AuditEntry()
                {
                    CreatedLocal = now,
                    CreatedSource = now,
                    CreatedBy = "CDS Simulator",
                    Status = "Created",
                    Version = 1
                }]
            };

            var document = clearanceRequest.Items.First().Documents.First();
            await movementService.Upsert(movement);
            var matchResult = await matchingService.Match(MatchingReferenceNumber.FromCds(document.DocumentReference, document.DocumentCode));
            return Results.Ok(new { clearanceRequest, matchResult });

        }
        else
        {
            await busService.SendMessageAsync(clearanceRequest);
        }

        return Results.Ok(clearanceRequest);
    }

}