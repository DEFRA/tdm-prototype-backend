using TdmPrototypeDmpSynchroniser.Api.Services;
using TdmPrototypeDmpSynchroniser.Api.Utils;

// using FluentValidation.Results;
// using MongoDB.Bson;

namespace TdmPrototypeDmpSynchroniser.Api.Endpoints;

public static class SyncEndpoints
{
    private const string BaseRoute = "sync";
    // private static ILogger Logger = ApplicationLogging.CreateLogger("SyncEndpoints");
    
    public static void UseSyncEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet(BaseRoute + "/clearance-requests", SyncClearanceRequestsAsync);
        app.MapGet(BaseRoute + "/ipaffs-notifications", SyncIpaffsNotificationsAsync);
    }

    private static async Task<IResult> SyncClearanceRequestsAsync(
        ISyncService service)
    {
        // var Logger = ApplicationLogging.CreateLogger("SyncEndpoints");
        
        var result = await service.SyncMovements();
        // Logger.LogInformation(result.ToJson());
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }
    
    private static async Task<IResult> SyncIpaffsNotificationsAsync(
        ISyncService service)
    {
        // var Logger = ApplicationLogging.CreateLogger("SyncEndpoints");
        
        var result = await service.SyncIpaffsNotifications();
        // Logger.LogInformation(result.ToJson());
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }
}