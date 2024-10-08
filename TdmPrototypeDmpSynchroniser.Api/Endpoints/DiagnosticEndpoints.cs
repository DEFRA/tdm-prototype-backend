using TdmPrototypeBackend.ASB;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Services;

// using MongoDB.Bson;

namespace TdmPrototypeDmpSynchroniser.Api.Endpoints;

public static class DiagnosticEndpoints
{
    private const string BaseRoute = "diagnostics";

    public static void UseDiagnosticEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet(BaseRoute + "/bus", GetBusDiagnosticAsync).AllowAnonymous();
        app.MapGet(BaseRoute + "/blob", GetBlobDiagnosticAsync).AllowAnonymous();
        app.MapGet(BaseRoute + "/bus-internal", GetBusInternalDiagnosticAsync).AllowAnonymous();
        app.MapGet(BaseRoute + "/blob-internal", GetBlobInternalDiagnosticAsync).AllowAnonymous();
        app.MapGet(BaseRoute + "/tradeapi", GetTradeApiDiagnosticAsync).AllowAnonymous();
        app.MapGet(BaseRoute + "/tradeapi-internal", GetTradeApiInternalDiagnosticAsync).AllowAnonymous();
        app.MapGet(BaseRoute + "/google", GetTradeApiDiagnosticAsync).AllowAnonymous();
    }

    private static async Task<IResult> GetBusDiagnosticAsync(
        IBusService service)
    {
        var result = await service.CheckBusAsync();
        Console.WriteLine(result.ToJson());
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }

    private static async Task<IResult> GetBusInternalDiagnosticAsync(
        IBusService service, SynchroniserConfig config)
    {
        var result = await service.CheckBusAsync(config.DmpBusPrivateEndpoint!);
        Console.WriteLine(result.ToJson());
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }
    
    private static async Task<IResult> GetBlobDiagnosticAsync(
        IBlobService service)
    {
        var result = await service.CheckBlobAsync();
        Console.WriteLine(result.ToJson());
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }
    
    private static async Task<IResult> GetBlobInternalDiagnosticAsync(
        IBlobService service, SynchroniserConfig config)
    {
        var result = await service.CheckBlobAsync(config.DmpBlobPrivateEndpoint!);
        Console.WriteLine(result.ToJson());
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }
    
    private static async Task<IResult> GetTradeApiDiagnosticAsync(
        IWebService service)
    {
        var result = await service.CheckTradeApiAsync();
        Console.WriteLine(result.ToJson());
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }
    
    private static async Task<IResult> GetTradeApiInternalDiagnosticAsync(
        IWebService service)
    {
        var result = await service.CheckTradeApiInternalAsync();
        Console.WriteLine(result.ToJson());
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }
    
    private static async Task<IResult> GetGoogleDiagnosticAsync(
        IWebService service)
    {
        var result = await service.CheckGoogleAsync();
        Console.WriteLine(result.ToJson());
        if (result.Success)
        {
            return Results.Ok(result);    
        }
        return Results.Conflict(result);
    }
}