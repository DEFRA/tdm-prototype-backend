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
public class SyncNotificationIntegrationTests(ITestOutputHelper outputHelper) : IntegrationTests(outputHelper)
{
    protected override void AddTestServices(IServiceCollection services)
    {
        services.AddSingleton<MongoHelperService<Notification>>();
    }

    protected override Task OnBeforeTest()
    {
        return Dependencies.MongoClearCollection<Notification>();
    }

    [Theory]
    [InlineData("Invalid Purpose Group Value", "InvalidPurposeGroup", "CHEDD.GB.2024.1004768", true)]
    [InlineData("Missing Unique Ids", "MissingUniqueIDs", "CHEDPP.GB.2024.1041046", true)]
    [InlineData("Missing Unique Complement Id", "MissingUniqueComplementId", "CHEDP.GB.2024.1001439", true)]
    [InlineData("No Commodity Complements", "NoCommodityComplements", "CHEDPP.GB.2024.1110138", false)]
    public async Task SyncNotification_FromLocationFolder(string reason, string folder, string id, bool valid)
    {
        Dependencies = new IntegrationTestDependenciesBuilder(OutputHelper)
            .UseLocalPathBlobStorage($"Fixtures/Notification/{folder}")
            .AddTestServices(services =>
            {
                services.AddSingleton(new Mock<IStorageService<Movement>>().Object);
            })
            .Build();

        var storageService = Dependencies.ServiceProvider.GetService<IStorageService<Notification>>()!;

        var result = await Dependencies.ServiceProvider.GetService<ISyncService>().SyncNotifications(SyncPeriod.All);

        result.Success.Should().Be(true, reason);
        result.Description.Should().Be($"Connected. {(valid ? 1 : 0)} items upserted. {(valid ? 0 : 1)} errors.", reason);

        if (valid)
        {
            var existingMovement = await storageService.Find(id);

            existingMovement.Should().NotBeNull(reason);
        }
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

        var storageService = Dependencies.ServiceProvider.GetService<IStorageService<Notification>>();

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
        notification.AuditEntries[1].Diff.Count.Should().Be(6);

    }


}