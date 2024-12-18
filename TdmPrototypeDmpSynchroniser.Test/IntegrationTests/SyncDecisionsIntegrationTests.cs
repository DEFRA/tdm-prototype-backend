using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
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

    [Fact]
    public async Task SimpleDecisionWithExistingChecks_Test()
    {
        Dependencies = new IntegrationTestDependenciesBuilder(OutputHelper)
            .UseLocalPathBlobStorage("Fixtures/SimpleDecisionsWithExistingChecksFolder")
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
        existingMovement.Items[0].Checks[0].DecisionCode.Should().Be("A02");
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