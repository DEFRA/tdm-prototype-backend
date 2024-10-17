using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeDmpSynchroniser.Api.Services;
using Xunit.Abstractions;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;


[Trait("Category", "Integration")]
public class MatchingIntegrationTests(ITestOutputHelper outputHelper) : IntegrationTests(outputHelper)
{
    protected override Task OnBeforeTest()
    {
        return Task.WhenAll(
            Dependencies.MongoClearCollection<Notification>(),
            Dependencies.MongoClearCollection<Movement>());
    }

    [Fact]
    public async Task ValidMatch()
    {
        Dependencies = new IntegrationTestDependenciesBuilder(OutputHelper)
            .UseLocalPathBlobStorage("Fixtures/Matching/ValidMatch")
            .Build();

        var syncService = Dependencies.ServiceProvider.GetService<ISyncService>();
        var movementService = Dependencies.ServiceProvider.GetService<IStorageService<Movement>>();
        var notificationService = Dependencies.ServiceProvider.GetService<IStorageService<Notification>>();

        await syncService.SyncNotifications(SyncPeriod.All);
        await syncService.SyncMovements(SyncPeriod.All);

        var movement = await movementService.Find("CHEDPGB20241039875A5");
        movement.Relationships.Notifications.Matched.Should().BeFalse();
        movement.AuditEntries.Count(x => x.Status == "Matched").Should().Be(0);

        movement = await movementService.Find("CHEDAGB20241041389");
        movement.Relationships.Notifications.Matched.Should().BeTrue();
        movement.AuditEntries.Count(x => x.Status == "Matched").Should().Be(1);


        var notification = await notificationService.Find("CHEDD.GB.2024.1004768");
        notification.Relationships.Movements.Matched.Should().BeFalse();
        notification.AuditEntries.Count(x => x.Status == "Matched").Should().Be(0);

        notification = await notificationService.Find("CHEDA.GB.2024.1041389");
        notification.Relationships.Movements.Matched.Should().BeTrue();
        notification.AuditEntries.Count(x => x.Status == "Matched").Should().Be(1);


    }

    [Fact]
    public async Task Cds_InvalidIpaffsType()
    {
        Dependencies = new IntegrationTestDependenciesBuilder(OutputHelper)
            .UseLocalPathBlobStorage("Fixtures/Matching/CdsWrongIpaffsType")
            .Build();

        var syncService = Dependencies.ServiceProvider.GetService<ISyncService>();
        var movementService = Dependencies.ServiceProvider.GetService<IStorageService<Movement>>();
        var notificationService = Dependencies.ServiceProvider.GetService<IStorageService<Notification>>();

        await syncService.SyncNotifications(SyncPeriod.All);
        await syncService.SyncMovements(SyncPeriod.All);


        var movement =  await movementService.Find("CHEDAGB20241041389");
        movement.Relationships.Notifications.Matched.Should().BeFalse();
        movement.AuditEntries.Count(x => x.Status == "Matched").Should().Be(1);



        var notification= await notificationService.Find("CHEDA.GB.2024.1041389");
        notification.Relationships.Movements.Matched.Should().BeFalse();
        notification.AuditEntries.Count(x => x.Status == "Matched").Should().Be(1);


    }
}