using FluentAssertions;
using FluentAssertions.Common;
using JsonApiDotNetCore.MongoDb.Resources;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Data;
using TdmPrototypeDmpSynchroniser.Api.Models;
using TdmPrototypeDmpSynchroniser.Api.Services;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

[Trait("Category", "Integration")]
public class SyncMovementsIntegrationTests : IntegrationTests
{
    public SyncMovementsIntegrationTests() : base()
    {

    }

    protected override void AddTestServices(IServiceCollection services)
    {
        services.AddSingleton<MongoHelperService<Movement>>();
    }

    protected override Task OnBeforeTest()
    {
        var mongoHelper = ServiceProvider.GetService<MongoHelperService<Movement>>();
        return mongoHelper.ClearCollection();
    }

    [Fact]
    public async Task CreateALVS_Integration()
    {
        //These files exist in the SND env
        await SyncMovement("RAW/ALVS/2024/02/14/ALVSCDSTEST0000314-361456c1-5369-4359-bb78-929121c618a6.json");
        await SyncMovement("RAW/ALVS/2024/02/14/ALVSCDSTEST0000314-a078fe92-de45-4477-a3c1-9d068669d905.json");

        var movementService = ServiceProvider.GetService<IStorageService<Movement>>();

        var existingMovement = await movementService.Find("ALVSCDSTEST0000314");


        existingMovement.ClearanceRequests.Count.Should().Be(1);
        existingMovement.ClearanceRequests[0].Header.EntryVersionNumber.Should().Be(3);

        existingMovement.AuditEntries.Count.Should().Be(2);
        existingMovement.AuditEntries[0].Id.Should().Be("2024/02/14/ALVSCDSTEST0000314-361456c1-5369-4359-bb78-929121c618a6.json");
        existingMovement.AuditEntries[0].Version.Should().Be(2);
        existingMovement.AuditEntries[0].CreatedBy.Should().Be("TRANSITAIR.GB");
        existingMovement.AuditEntries[0].Status.Should().Be("Created");
        existingMovement.AuditEntries[0].Diff.Should().BeEmpty();

        existingMovement.AuditEntries[1].Id.Should().Be("2024/02/14/ALVSCDSTEST0000314-a078fe92-de45-4477-a3c1-9d068669d905.json");
        existingMovement.AuditEntries[1].Version.Should().Be(3);
        existingMovement.AuditEntries[1].CreatedBy.Should().Be("TRANSITAIR.GB");
        existingMovement.AuditEntries[1].Status.Should().Be("Updated");
        existingMovement.AuditEntries[1].Diff.Count.Should().Be(8);
    }

    private Task SyncMovement(string path)
    {
        return GetSynService().SyncMovement(new SynchroniserBlobItem() { Name = path });
    }

    private SyncService GetSynService()
    {
        return ServiceProvider.GetService<ISyncService>() as SyncService;
    }
}