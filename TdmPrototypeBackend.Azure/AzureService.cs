using System.Diagnostics.Tracing;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Identity;
using Microsoft.Extensions.Logging;

namespace TdmPrototypeBackend.Azure;

public abstract class AzureService<T> 
{
    protected readonly TokenCredential Credentials;
    protected readonly HttpClientTransport? Transport;
    protected readonly ILogger<T> Logger;
    
    protected AzureService(ILogger<T> logger, IAzureConfig config, IHttpClientFactory? clientFactory = null)
    {
        Logger = logger;
        using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);

        if (config.AzureClientId != null)
        {
            logger.LogInformation($"Creating azure credentials based on config vars for {config.AzureClientId}");
            Credentials =
                new ClientSecretCredential(config.AzureTenantId, config.AzureClientId, config.AzureClientSecret);

            logger.LogInformation($"Created azure credentials");
        }
        else
        {
            logger.LogInformation($"Creating azure credentials using default creds because AZURE_CLIENT_ID env var not found.");
            Credentials = new DefaultAzureCredential();
            logger.LogInformation($"Created azure default credentials");
        }

        if (clientFactory != null)
        {
            var client = clientFactory.CreateClient("proxy");
            client.DefaultRequestHeaders.Add("Host", "devdmpinfdl1001.blob.core.windows.net");
            var transport = new HttpClientTransport(client);
            Transport = transport;
        }
        
    }
}