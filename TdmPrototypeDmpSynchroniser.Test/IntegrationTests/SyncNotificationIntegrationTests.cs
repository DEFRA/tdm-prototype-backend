using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeDmpSynchroniser.Api.Services;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

[Trait("Category", "Integration")]
public class SyncNotificationIntegrationTests : IntegrationTests
{
    public SyncNotificationIntegrationTests() : base()
    {

    }

    protected override void AddTestServices(IServiceCollection services)
    {
        services.AddSingleton<MongoHelperService<Notification>>();
    }

    protected override Task OnBeforeTest()
    {
        var mongoHelper = ServiceProvider.GetService<MongoHelperService<Notification>>();
        return mongoHelper.ClearCollection();
    }

    [Fact]
    public async Task NotificationSync_ThisMonth()
    {
        //These files exist in the SND env
        await SyncNotifications(SyncPeriod.ThisMonth);
    }

    [Fact]
    public async Task Notification_IntegrationTest()
    {
        //These files exist in the SND env
        await SyncNotification("RAW/IPAFFS/CHEDA/2024/02/14/CHEDA_GB_2024_1101869-1639d446-0706-4a83-ad4c-976f0837816a.json");
        await SyncNotification("RAW/IPAFFS/CHEDA/2024/02/14/CHEDA_GB_2024_1101869-42a70100-aeb3-47c2-a445-b0f335db1190.json");

        var storageService = ServiceProvider.GetService<IStorageService<Notification>>();

        var notification = await storageService.Find("CHEDA.GB.2024.1101869");

        notification.AuditEntries.Count.Should().Be(2);
        notification.AuditEntries[0].Id.Should().Be("CHEDA/2024/02/14/CHEDA_GB_2024_1101869-1639d446-0706-4a83-ad4c-976f0837816a.json");
        notification.AuditEntries[0].Version.Should().Be(2);
        notification.AuditEntries[0].CreatedBy.Should().Be("Mark Admin-Tester");
        notification.AuditEntries[0].Status.Should().Be("Created");
        notification.AuditEntries[0].Diff.Should().BeEmpty();

        notification.AuditEntries[1].Id.Should().Be("CHEDA/2024/02/14/CHEDA_GB_2024_1101869-42a70100-aeb3-47c2-a445-b0f335db1190.json");
        notification.AuditEntries[1].Version.Should().Be(3);
        notification.AuditEntries[1].CreatedBy.Should().Be("Mark Admin-Tester");
        notification.AuditEntries[1].Status.Should().Be("Updated");
        notification.AuditEntries[1].Diff.Count.Should().Be(5);

    }


}