using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeBackend.Types.VehicleMovement;
using TdmPrototypeDmpSynchroniser.Api.Services;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

[Trait("Category", "Integration")]
public class SyncGmrsIntegrationTests : IntegrationTests
{
    public SyncGmrsIntegrationTests() : base()
    {

    }

    protected override void AddTestServices(IServiceCollection services)
    {
        services.AddSingleton<MongoHelperService<Gmrs>>();
    }

    protected override Task OnBeforeTest()
    {
        var mongoHelper = ServiceProvider.GetService<MongoHelperService<Gmrs>>();
        return mongoHelper.ClearCollection();
    }

    [Fact]
    public async Task GmrsSync_ThisMonth()
    {
        await GetSynService().SyncGmrs(SyncPeriod.ThisMonth);
    }
}