using System.Net;
using Microsoft.Extensions.Logging;

namespace TdmPrototypeBackend.ASB;

public class BusServiceFactory(ILoggerFactory loggerFactory, IWebProxy webProxy) : IBusServiceFactory
{
    public IBusService Create(IBusConfig config)
    {
        return new BusService(loggerFactory.CreateLogger<BusService>(), config, webProxy);
    }
}