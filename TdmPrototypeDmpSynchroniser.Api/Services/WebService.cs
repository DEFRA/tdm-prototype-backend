﻿using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public class WebService(ILoggerFactory loggerFactory, SynchroniserConfig config, IHttpClientFactory clientFactory)
    : BaseService(loggerFactory, config), IWebService
{

    public async Task<Status> CheckGoogleAsync()
    {
        return await CheckApiAsync("https://www.google.com");
    }
    
    public async Task<Status> CheckTradeApiInternalAsync()
    {
        return await CheckApiAsync($"https://{config.TradeApiEmvironment}-internal-gateway.trade.azure.defra.cloud");
    }
    
    public async Task<Status> CheckTradeApiAsync()
    {
        return await CheckApiAsync($"https://{config.TradeApiEmvironment}-gateway.trade.azure.defra.cloud");
    }
    
    private async Task<Status> CheckApiAsync(string uri)
    {
        try
        {
            Extensions.AssertIsNotNull(uri);
            
            Logger.LogInformation("Attempting connection to {0}", uri);
            
            // Gets a proxied client when CDP_HTTP_PROXY is set whilst running in CDP
            // https://github.com/DEFRA/cdp-portal-backend/blob/main/Defra.Cdp.Backend.Api/Utils/Proxy.cs#L16
            HttpClient client = clientFactory.CreateClient("proxy");
            client.Timeout = TimeSpan.FromSeconds(10);

            using HttpRequestMessage request = new(
                HttpMethod.Head, 
                uri);

            using HttpResponseMessage response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode()
                .WriteRequestToConsole();

            foreach (var header in response.Headers)
            {
                Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
            }
            Console.WriteLine();
            
            return new Status() { Success = false, Description = "Connected" };
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return new Status() { Success = false, Description = ex.Message };
        }
    }
}