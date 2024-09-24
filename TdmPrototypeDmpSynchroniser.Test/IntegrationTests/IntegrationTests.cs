using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TdmPrototypeBackend.Api.Utils;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Extensions;
using TdmPrototypeDmpSynchroniser.Api.Models;
using TdmPrototypeDmpSynchroniser.Api.Services;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

public abstract class IntegrationTests
{
    protected IServiceProvider ServiceProvider;

    protected IntegrationTests()
    {
        var builder = WebApplication.CreateBuilder();
        var loggerConfiguration = new LoggerConfiguration();
        var logger = loggerConfiguration.CreateLogger();

        //This will look for your local.env file
        var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),
            @"..\..\..\..\TdmPrototypeBackend.Api/Properties/local.env"));
        builder.Configuration.AddIniFile(path, false);

        var config = new List<KeyValuePair<string, string>>
        {
            new ("Mongo:DatabaseName", "tdm-prototype-backend-integration"),
            new ("AZURE_TENANT_ID", "c9d74090-b4e6-4b04-981d-e6757a160812")
        };
        builder.Configuration.AddInMemoryCollection(config);

        builder.Services.AddHttpProxyServices(logger, builder.Configuration);
        builder.Services.AddSingleton<MongoHelperService<Movement>>();
        builder.AddSynchroniserDatabase();
        builder.Services.AddSynchroniserServices();

        AddTestServices(builder.Services);

        ServiceProvider = builder.Services.BuildServiceProvider();

        OnBeforeTest().GetAwaiter().GetResult();

    }

    protected virtual void AddTestServices(IServiceCollection services)
    {

    }

    protected virtual Task OnBeforeTest()
    {
        return Task.CompletedTask;
    }

    protected Task SyncMovement(string path)
    {
        return GetSynService().SyncMovement(new SynchroniserBlobItem() { Name = path });
    }

    protected Task SyncNotification(string path)
    {
        return GetSynService().SyncIpaffsNotifications(path);
    }

    protected SyncService GetSynService()
    {
        return ServiceProvider.GetService<ISyncService>() as SyncService;
    }
}