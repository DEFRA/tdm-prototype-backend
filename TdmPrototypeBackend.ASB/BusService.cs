using System;
using System.Net;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using TdmPrototypeBackend.Azure;

namespace TdmPrototypeBackend.ASB;

public class BusService(
    ILogger<BusService> logger,
    IBusConfig config,
    IWebProxy proxy) : AzureService<BusService>(logger, config), IBusService
{

    private ServiceBusClient CreateBusClient(string uri, int retries = 3, int timeout = 10)
    {
        logger.LogInformation(
            $"Connecting to bus {uri} : {config.DmpBusTopic}/{config.DmpBusSubscription}");

        var clientOptions = new ServiceBusClientOptions()
        {
            WebProxy = proxy,
            TransportType = ServiceBusTransportType.AmqpWebSockets,
            RetryOptions = new ServiceBusRetryOptions { TryTimeout = TimeSpan.FromSeconds(timeout), MaxRetries = retries },
        };

        return new ServiceBusClient(
            uri,
            Credentials,
            clientOptions);
    }

    public async Task<Status> CheckBusAsync()
    {
        return await CheckBusAsync(config.DmpBusNamespace);
    }

    public async Task SendMessageAsync<T>(T message)
    {
        await using var client = CreateBusClient(config.DmpBusNamespace, 0, 5);
        await using var sender = client.CreateSender(config.DmpBusTopic);
        await sender.SendMessageAsync(new ServiceBusMessage(BinaryData.FromObjectAsJson(message)));
    }

    public async Task<Status> CheckBusAsync(string uri)
    {   
        try
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            await using (var client = CreateBusClient(uri, 0, 5))
            {
                await using (var processor =
                             client.CreateReceiver(config.DmpBusTopic, config.DmpBusSubscription))
                {
                    var messages = await processor.PeekMessagesAsync(100);

                    return new Status()
                    {
                        Success = true,
                        Description = String.Format("Connected. {0} bus messages found", messages.Count)
                    };
                }
            }

        }
        catch (Exception ex)
        {
            logger.LogError(ex.ToString());
            return new Status() { Success = false, Description = ex.Message };
        }
    }
}