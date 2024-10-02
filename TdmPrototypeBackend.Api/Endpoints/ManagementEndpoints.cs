using System.Collections;
using System.Security.Claims;
using Azure.Core;
using Json.More;
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
        if (config.EnableManagement)
        {
            app.MapGet(BaseRoute + "/collections", GetCollectionsAsync).AllowAnonymous();
            app.MapGet(BaseRoute + "/collections/drop", DropCollectionsAsync).RequireAuthorization("tdm-technical");  
            app.MapGet(BaseRoute + "/environment", GetEnvironment).AllowAnonymous(); 
            app.MapGet(BaseRoute + "/auth/status", GetAuth).AllowAnonymous();
            // app.MapGet(BaseRoute + "/proxy/set", SetProxy).RequireAuthorization("technical");
            // app.MapGet(BaseRoute + "/proxy/unset", UnsetProxy).RequireAuthorization("technical");   
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

    private static IResult GetAuth(IConfiguration configuration, HttpRequest request, ClaimsPrincipal user)
    {

        var dict = new Dictionary<string, object>
        {
            { "user", user.Identity.ToJsonDocument() },
            { "claims", user.Claims.ToList().Select(c => new { key= c.Type,  value = c.Value }).ToJsonDocument() }
        };
        return Results.Ok(dict);
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