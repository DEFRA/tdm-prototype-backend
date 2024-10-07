using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeBackend.Types.VehicleMovement;
using TdmPrototypeDmpSynchroniser.Api.Services;
using Xunit.Abstractions;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

[Trait("Category", "Integration")]
public class SyncGmrsIntegrationTests : IntegrationTests
{
    public SyncGmrsIntegrationTests(ITestOutputHelper helper) : base(helper)
    {

    }

    protected override void AddTestServices(IServiceCollection services)
    {
        services.AddSingleton<MongoHelperService<Gmrs>>();
    }

    protected override Task OnBeforeTest()
    {
        return Dependencies.MongoClearCollection<Gmrs>();
    }

    [Fact]
    public async Task GmrsSync_ThisMonth()
    {
        await GetSynService().SyncGmrs(SyncPeriod.ThisMonth);
    }
}