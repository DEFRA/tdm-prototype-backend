using Microsoft.Extensions.DependencyInjection;
using TdmPrototypeDmpSynchroniser.Api.Models;
using TdmPrototypeDmpSynchroniser.Api.Services;
using Xunit.Abstractions;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

public abstract class IntegrationTests
{
    protected IntegrationTestDependencies Dependencies;
    protected readonly ITestOutputHelper OutputHelper;

    protected IntegrationTests(ITestOutputHelper outputHelper, Action<IntegrationTestDependenciesBuilder>? configureBuilder = default)
    {
        OutputHelper = outputHelper;
        var builder = new IntegrationTestDependenciesBuilder(outputHelper)
            .SetConfig(Path.Combine(Directory.GetCurrentDirectory(),
                @"../../../../TdmPrototypeBackend.Api/Properties/local.env"))
            .SetMongoDbName("tdm-prototype-backend-integration");
        configureBuilder?.Invoke(builder);
        Dependencies = builder.Build();

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