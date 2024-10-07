using Json.Patch;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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

    private static readonly char[] s_AlphaNumeric = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    // private static Random Random = new();
    

    private static string GenerateRandomString(int characters=14)
    {
        return new string(new Random().GetItems(s_AlphaNumeric, characters));
    }
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
        const string documentCode = "C640";
        const string declarant = "GB363127805000";
        var now = DateTime.UtcNow;
        
        ALVSClearanceRequest clearanceRequest = new ALVSClearanceRequest();
        clearanceRequest.Header = new Header()
        {
            EntryReference = $"{now.ToString("yy")}GB{GenerateRandomString()}",
            EntryVersionNumber = 2,
            DeclarationUCR = $"Sim{notificationId}",
            MasterUCR = $"Sim{notificationId}",
            DeclarantName = "CDS_Simulator",
            PreviousVersionNumber = 1,
            GoodsLocationCode = "BELBELGVM",

        };

        clearanceRequest.ServiceHeader = new ServiceHeader()
        {
            ServiceCallTimestamp = now,
            SourceSystem = "CDSSIM",
            DestinationSystem = "ALVS",
            CorrelationId = "000"
        };

        var document = new Document()
        {
            DocumentReference =
                MatchingReferenceNumber.FromIpaffs(notificationId, notification.IpaffsType.Value)
                    .AsCdsDocumentReference(),
            DocumentCode = documentCode,
            DocumentQuantity = 3,
            DocumentStatus = "P"
        };

        var commodities = notification!.PartOne!.Commodities!;
        
        clearanceRequest.Items = commodities.CommodityComplements!
            .Select((c, index) => new Items() {
                ItemNumber = index + 1,
                TaricCommodityCode = c.CommodityID!.PadRight(10, '0'),
                GoodsDescription = c.CommodityDescription, //from notification
                ItemOriginCountryCode = commodities.CountryOfOrigin,
                ItemSupplementaryUnits = c.AdditionalData!.ContainsKey("numberAnimal") ? decimal.Parse(c.AdditionalData["numberAnimal"].ToString()!) : 0, //Number animals
                ItemNetMass = c.AdditionalData!.ContainsKey("numberAnimal") ? 0 : 1000, //from notification, 0 if animals
                Documents = new[]
                {
                    document
                },
                Checks = new Check[1] { new() { CheckCode = "H2019", DepartmentCode = "GB" } }
            }).ToArray();

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