using TdmPrototypeBackend.Api.Data;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Services;
using TdmPrototypeBackend.Api.Config;

// using MongoDB.Bson;

namespace TdmPrototypeBackend.Api.Endpoints;

public static class ManagementEndpoints
{
    private const string BaseRoute = "mgmt";

    public static void UseManagementEndpoints(this IEndpointRouteBuilder app, BackendConfig config)
    {
        if (config.EnableMongoManagement)
        {
            app.MapGet(BaseRoute + "/collections", GetCollectionsAsync);
            app.MapGet(BaseRoute + "/collections/drop", DropCollectionsAsync);    
        }
    }

    private static async Task<IResult> GetCollectionsAsync(
        IMongoDbClientFactory clientFactory)
    {
        return Results.Ok(clientFactory.GetCollections().ToArray());
    }
    
    private static async Task<IResult> DropCollectionsAsync(
        IMongoDbClientFactory clientFactory)
    {
        clientFactory.DropCollections();

        return Results.Ok("Dropped");
    }
}