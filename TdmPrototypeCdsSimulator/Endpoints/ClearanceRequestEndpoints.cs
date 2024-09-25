using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TdmPrototypeBackend.ASB;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeCdsSimulator.Config;
using TdmPrototypeDmpSynchroniser.Api.Services;

namespace TdmPrototypeCdsSimulator.Endpoints;

public static class ClearanceRequestEndpoints
{
    private const string BaseRoute = "simulator";
    
    public static void UseClearanceRequestEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet(BaseRoute + "/create-clearance-request/{notificationId}", CreateClearanceRequestsAsync);
    }

    private static async Task<IResult> CreateClearanceRequestsAsync(
        IStorageService<Notification> notificationService,
        IBusService busService,
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
            new() { ItemNumber = 1, Checks = new Check[1] { new() { CheckCode = "H2019", DepartmentCode = "GB" } } }
        };

        await busService.SendMessageAsync(clearanceRequest);


        return Results.Ok(clearanceRequest);
    }
}