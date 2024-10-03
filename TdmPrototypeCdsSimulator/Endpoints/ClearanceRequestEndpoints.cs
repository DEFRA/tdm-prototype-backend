using Json.Patch;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MongoDB.Driver;
using TdmPrototypeBackend.ASB;
using TdmPrototypeBackend.Matching;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Storage.Mongo;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeCdsSimulator.Config;

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
        IStorageService<Notification> notificationService,
        IStorageService<Movement> movementService,
        IBusService busService,
        CdsSimulatorConfig config,
        string notificationId)
    {
        var notification = await notificationService.Find(notificationId);

        ALVSClearanceRequest clearanceRequest = new ALVSClearanceRequest();
        clearanceRequest.Header = new Header()
        {
            EntryReference = notificationId,
            EntryVersionNumber = 2,
            DeclarationUCR = $"Sim{notificationId}",
            MasterUCR = $"Sim{notificationId}",
            DeclarantName = "CDS_Simulator",
            PreviousVersionNumber = 1,

        };

        clearanceRequest.ServiceHeader = new ServiceHeader()
        {
            ServiceCallTimestamp = DateTime.UtcNow,
            SourceSystem = "CDSSIM",
            DestinationSystem = "ALVS",
            CorrelationId = "000"
        };

        clearanceRequest.Items = new Items[1]
        {
            new()
            {
                ItemNumber = 1,
                Documents = new[]
                {
                    new Document()
                    {
                        DocumentReference = MatchingReferenceNumber.FromIpaffs(notificationId, notification.IpaffsType.Value).AsCdsDocumentReference(),
                        DocumentCode = "C640",
                        DocumentQuantity = 3,
                        DocumentStatus = "P"
                    }
                },
                Checks = new Check[1] { new() { CheckCode = "H2019", DepartmentCode = "GB" } }
            }
        };

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
            };

            await movementService.Upsert(movement);
        }
        else
        {
            await busService.SendMessageAsync(clearanceRequest);
        }

        return Results.Ok(clearanceRequest);
    }

}