using TdmPrototypeDmpSynchroniser.Api.Services;

// using FluentValidation.Results;
// using MongoDB.Bson;

namespace TdmPrototypeDmpSynchroniser.Api.Endpoints;

public static class SyncEndpoints
{
    private const string BaseRoute = "sync";

    public static void UseSyncEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet(BaseRoute + "/clearance-requests", SyncClearanceRequestsAsync);
    }

    private static async Task<IResult> SyncClearanceRequestsAsync(
        ISyncService service)
    {
        var result = await service.SyncMovements();
        Console.WriteLine(result.ToJson());
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }
}