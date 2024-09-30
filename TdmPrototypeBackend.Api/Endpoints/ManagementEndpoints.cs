using System.Collections;
using Microsoft.AspNetCore.Authorization;
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
            app.MapGet(BaseRoute + "/collections", GetCollectionsAsync).AllowAnonymous();
            app.MapGet(BaseRoute + "/collections/drop", DropCollectionsAsync);  
            app.MapGet(BaseRoute + "/environment", GetEnvironment);
            app.MapGet(BaseRoute + "/proxy/set", SetProxy);
            app.MapGet(BaseRoute + "/proxy/unset", UnsetProxy);   
        }
    }

    private static bool FilterEnvKeys(DictionaryEntry d)
    {
        var key = d.Key.ToString()!;
        return key.StartsWith("DMP") | key.StartsWith("CDP")
                                     | key.StartsWith("AZURE") | key.StartsWith("TRADE")
                                     | key.StartsWith("HTTP") | key.StartsWith("TDM");
    }
    private static IResult GetEnvironment(IConfiguration configuration)
    {
        
        var dict = System.Environment.GetEnvironmentVariables();
        var filtered = dict.Cast<DictionaryEntry>().Where(FilterEnvKeys).ToArray();
        return Results.Ok(filtered); //(Dictionary)dict.Where(i => i.Value.BooleanProperty));
    }
    
    private static IResult SetProxy(IConfiguration configuration)
    {
        System.Environment.SetEnvironmentVariable("HTTPS_PROXY", configuration["CDP_HTTPS_PROXY"]);
        System.Environment.SetEnvironmentVariable("HTTP_PROXY", configuration["CDP_HTTP_PROXY"]);
        return Results.Ok();
    }

    private static IResult UnsetProxy(IConfiguration configuration)
    {
        System.Environment.SetEnvironmentVariable("HTTPS_PROXY", "");
        System.Environment.SetEnvironmentVariable("HTTP_PROXY", "");
        return Results.Ok();
    }
    
    [AllowAnonymous]
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