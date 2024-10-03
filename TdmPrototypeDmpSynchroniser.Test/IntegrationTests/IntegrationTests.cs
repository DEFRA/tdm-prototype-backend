using JsonApiDotNetCore.MongoDb.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TdmPrototypeBackend.Api.Utils;
using TdmPrototypeBackend.Matching.Extensions;
using TdmPrototypeBackend.Storage.Mongo;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeDmpSynchroniser.Api.Extensions;
using TdmPrototypeDmpSynchroniser.Api.Models;
using TdmPrototypeDmpSynchroniser.Api.Services;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

public abstract class IntegrationTests 
{
    protected IntegrationTestDependencies Dependencies;

    protected IntegrationTests()
    {
        Dependencies = new IntegrationTestDependenciesBuilder()
            .SetConfig(Path.Combine(Directory.GetCurrentDirectory(),
                @"../../../../TdmPrototypeBackend.Api/Properties/local.env"))
            .SetMongoDbName("tdm-prototype-backend-integration")
            .Build();

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

    protected Task SyncNotifications(SyncPeriod syncPeriod)
    {
        return GetSynService().SyncNotifications(syncPeriod);
    }

    protected SyncService GetSynService()
    {
        return Dependencies.ServiceProvider.GetService<ISyncService>() as SyncService;
    }
}