using TdmPrototypeDmpSynchroniser.Api.Services;
using TdmPrototypeDmpSynchroniser.Api.Utils;

// using FluentValidation.Results;
// using MongoDB.Bson;

namespace TdmPrototypeDmpSynchroniser.Api.Endpoints;

public static class SyncEndpoints
{
    private const string BaseRoute = "sync";
    // private static ILogger Logger = ApplicationLogging.CreateLogger("SyncEndpoints");
    // private static ILogger Logger = ApplicationLogging.CreateLogger("SyncEndpoints");

    private static SyncPeriod Parse(string? period)
    {
        if (string.IsNullOrEmpty(period))
        {
            return SyncPeriod.All;
        }

        return Enum.Parse<SyncPeriod>(period, true);
        
        // if (Enum.TryParse<SyncPeriod>(period, true, out SyncPeriod typed))
        // {
        //     return typed;
        // }
        // return SyncPeriod.All;
    }
    public static void UseSyncEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet(BaseRoute + "/clearance-requests/{period}", SyncClearanceRequestsAsync).AllowAnonymous();
        app.MapGet(BaseRoute + "/notifications/{period}", SyncNotificationsAsync).AllowAnonymous();
    }

    private static async Task<IResult> SyncClearanceRequestsAsync(
        ISyncService service, string? period)
    {
        // 
        // Logger.LogInformation($"SyncClearanceRequestsAsync {period}");
        var result = await service.SyncMovements(Parse(period));
        
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }
    
    private static async Task<IResult> SyncNotificationsAsync(
        ISyncService service, string? period)
    {
        // var Logger = ApplicationLogging.CreateLogger("SyncEndpoints");
        
        var result = await service.SyncNotifications(Parse(period));
        // Logger.LogInformation(result.ToJson());
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }
}