using FluentAssertions;
using FluentAssertions.Common;
using JsonApiDotNetCore.MongoDb.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Storage.Mongo;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeBackend.Types.VehicleMovement;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Models;
using TdmPrototypeDmpSynchroniser.Api.Services;
using Xunit.Abstractions;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;


[Trait("Category", "Integration")]
public class SyncDecisionsIntegrationTests(ITestOutputHelper outputHelper) : IntegrationTests(outputHelper)
{
    protected override Task OnBeforeTest()
    {
        return Dependencies.MongoClearCollection<Movement>();
    }

    [Fact]
    public async Task SyncMovements_LastMonth()
    {
        //These files exist in the SND env
        await SyncDecisions(SyncPeriod.LastMonth);
       
    }
    
    [Fact]
    public async Task SimpleDecision_Test()
    {
        Dependencies = new IntegrationTestDependenciesBuilder(OutputHelper)
            .UseLocalPathBlobStorage("Fixtures/SimpleDecisionsFolder")
            .AddTestServices(services =>
            {
                services.AddSingleton<IStorageService<Notification>>(new Mock<IStorageService<Notification>>().Object);
            })
            .Build();

        await SyncMovements(SyncPeriod.All);
        await SyncDecisions(SyncPeriod.All);

        var movementService = Dependencies.ServiceProvider.GetService<IStorageService<Movement>>()!;
        
        var existingMovement = await movementService.Find("CHEDPGB20241039875A5");

        existingMovement.Should().NotBeNull();
        existingMovement.Items[0].Checks.Length.Should().Be(1);
        existingMovement.Items[0].Checks[0].CheckCode.Should().Be("H234");
        existingMovement.Items[0].Checks[0].DepartmentCode.Should().Be("PHA");
    }

    
    private Task SyncDecisions(SyncPeriod syncPeriod)
    {
        return GetSynService().SyncDecisions(syncPeriod);
    }

    private Task SyncMovements(SyncPeriod syncPeriod)
    {
        return GetSynService().SyncMovements(syncPeriod);
    }

    private SyncService GetSynService()
    {
        return Dependencies.ServiceProvider.GetService<ISyncService>() as SyncService;
    }
}