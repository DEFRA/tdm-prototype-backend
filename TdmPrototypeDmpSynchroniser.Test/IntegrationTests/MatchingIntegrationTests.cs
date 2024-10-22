using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeDmpSynchroniser.Api.Services;
using Xunit.Abstractions;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

[Trait("Category", "Integration")]
public class MatchingIntegrationTests : IntegrationTests
{
    private static readonly Action<IntegrationTestDependenciesBuilder>? ConfigureBuilder = builder => builder.UseLocalPathBlobStorage("Fixtures/Matching/ValidMatch");
    private readonly IStorageService<Movement> _movementService;
    private readonly IStorageService<Notification> _notificationService;
    private readonly ISyncService _syncService;

    public MatchingIntegrationTests(ITestOutputHelper outputHelper) : base(outputHelper, ConfigureBuilder)
    {
        _syncService = Dependencies.ServiceProvider.GetService<ISyncService>()!;
        _movementService = Dependencies.ServiceProvider.GetService<IStorageService<Movement>>()!;
        _notificationService = Dependencies.ServiceProvider.GetService<IStorageService<Notification>>()!;
        
        Task.WhenAll(
            Dependencies.MongoClearCollection<Notification>(),
            Dependencies.MongoClearCollection<Movement>()).Wait();
    }

    [Fact]
    public async Task ValidMovementToNotificationMatches()
    {
        await _syncService.SyncNotifications(SyncPeriod.All);
        await _syncService.SyncMovements(SyncPeriod.All);

        await ValidateMovements();
        await ValidateNotifications();
    }

    [Fact]
    public async Task ValidNotificationToMovementMatches()
    {
        await _syncService.SyncNotifications(SyncPeriod.All);
        await _syncService.SyncMovements(SyncPeriod.All);

        await ValidateMovements();
        await ValidateNotifications();
    }
    
    
    [Fact]
    public async Task ValidMultiCommodityMatch()
    {
        await _syncService.SyncNotifications(SyncPeriod.All);
        await _syncService.SyncMovements(SyncPeriod.All);
        
        var notification = await _notificationService.Find("CHEDPP.GB.2024.1038788");
        notification.Relationships.Movements.Matched.Should().BeTrue();
        notification.AuditEntries.Count(x => x.Status == "Matched").Should().Be(1);
        
        var movement = await _movementService.Find("CHEDPPGB20241038788");
        movement.Relationships.Notifications.Matched.Should().BeTrue();
        movement.AuditEntries.Count(x => x.Status == "Matched").Should().Be(10);
    }

    private async Task ValidateNotifications()
    {
        var notification = await _notificationService.Find("CHEDD.GB.2024.1004768");
        notification.Relationships.Movements.Matched.Should().BeFalse();
        notification.AuditEntries.Count(x => x.Status == "Matched").Should().Be(0);

        notification = await _notificationService.Find("CHEDA.GB.2024.1041389");
        notification.Relationships.Movements.Matched.Should().BeTrue();
        notification.AuditEntries.Count(x => x.Status == "Matched").Should().Be(1);

        notification = await _notificationService.Find("CHEDP.GB.2024.1042294");
        notification.Relationships.Movements.Matched.Should().BeTrue();
        notification.AuditEntries.Count(x => x.Status == "Matched").Should().Be(1);

        notification = await _notificationService.Find("CHEDD.GB.2024.1004777");
        notification.Relationships.Movements.Matched.Should().BeTrue();
        notification.AuditEntries.Count(x => x.Status == "Matched").Should().Be(1);
    }

    private async Task ValidateMovements()
    {
        var movement = await _movementService.Find("CHEDPGB20241039875A5");
        movement.Relationships.Notifications.Matched.Should().BeFalse();
        movement.AuditEntries.Count(x => x.Status == "Matched").Should().Be(0);

        movement = await _movementService.Find("CHEDAGB20241041389");
        movement.Relationships.Notifications.Matched.Should().BeTrue();
        movement.AuditEntries.Count(x => x.Status == "Matched").Should().Be(1);

        movement = await _movementService.Find("CHEDPGB20241042294A5");
        movement.Relationships.Notifications.Matched.Should().BeTrue();
        movement.AuditEntries.Count(x => x.Status == "Matched").Should().Be(1);

        movement = await _movementService.Find("CHEDDGB20241004777");
        movement.Relationships.Notifications.Matched.Should().BeTrue();
        movement.AuditEntries.Count(x => x.Status == "Matched").Should().Be(1);
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