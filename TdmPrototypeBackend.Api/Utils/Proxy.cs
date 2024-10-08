using System.Net;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog.Core;
// using TdmPrototypeBackend.Api.Services;

namespace TdmPrototypeBackend.Api.Utils;

public static class Proxy
{
    public interface IProxyConfig
    {
        public bool UseProxy { get; set; }
        public IWebProxy Proxy { get; set; }
    }
    public class ProxyConfig : IProxyConfig
    {
        public bool UseProxy { get; set; } = default!;
        public IWebProxy Proxy { get; set; } = default!;
    }
    
    public const string ProxyClient = "proxy";

    /**
     * A preconfigured HTTP Client that uses the Platform's outbound proxy.
     * 
     * Usage:
     *  1. inject an `IHttpClientFactory` into your class.
     *  2. Use the IHttpClientFactory to create a named instance of HttpClient:
     *     `clientFactory.CreateClient(Proxy.ProxyClient);`
     */
    public static void AddHttpProxyServices(this IServiceCollection services, Logger logger, IConfiguration configuration)
    {
        var proxyUri = configuration["CDP_HTTPS_PROXY"];
        var proxy = new WebProxy
        {
            BypassProxyOnLocal = true
        };
        
        if (proxyUri != null)
        {
            logger.Information($"Creating {ProxyClient} proxy http client");
            var uri = new UriBuilder(proxyUri);

            var credentials = GetCredentialsFromUri(uri);
            if (credentials != null)
            {
                logger.Debug("Setting proxy credentials");
                proxy.Credentials = credentials;    
            }

            // Remove credentials from URI to so they don't get logged.
            uri.UserName = "";
            uri.Password = "";
            proxy.Address = uri.Uri;
            
            logger.Information($"Proxy http client {ProxyClient} created connected to {uri.Uri}");
        }
        else
        {
            logger.Warning("CDP_HTTPS_PROXY is NOT set, proxy client will be disabled");
        }
        
        services.AddHttpClient(ProxyClient).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { Proxy = proxy, UseProxy = proxyUri != null });
        services.AddSingleton<IProxyConfig, ProxyConfig>(provider => new ProxyConfig() { Proxy = proxy, UseProxy = proxyUri != null});
        services.AddSingleton<IWebProxy, WebProxy>(provider => proxy);
    }
    
    private static NetworkCredential? GetCredentialsFromUri(UriBuilder uri)
    {
        var username = uri.UserName;
        var password = uri.Password;
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return null;
        return new NetworkCredential(username, password);
    }

}
