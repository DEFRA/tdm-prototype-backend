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
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Models;
using TdmPrototypeDmpSynchroniser.Api.Services;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

[Trait("Category", "Integration")]
public class SyncMovementsIntegrationTests : IntegrationTests
{
    public SyncMovementsIntegrationTests() : base()
    {

    }


    protected override Task OnBeforeTest()
    {
        return Dependencies.MongoClearCollection<Movement>();
    }

    [Fact]
    public async Task SyncMovements_LastMonth()
    {
        var testDependencies = new IntegrationTestDependenciesBuilder()
            .Build();

        testDependencies.MongoClearCollection<Movement>();
        //These files exist in the SND env
        await SyncMovements(SyncPeriod.LastMonth);
       
    }

    [Fact]
    public async Task CreateALVS_Integration()
    {
        //These files exist in the SND env
        await SyncMovement("RAW/ALVS/2024/02/14/ALVSCDSTEST0000314-361456c1-5369-4359-bb78-929121c618a6.json");
        await SyncMovement("RAW/ALVS/2024/02/14/ALVSCDSTEST0000314-a078fe92-de45-4477-a3c1-9d068669d905.json");

        var movementService = Dependencies.ServiceProvider.GetService<IStorageService<Movement>>();

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
    
    [Fact]
    public async Task FromLocalSimpleFolder_ShouldCreateSuccessfully()
    {
        var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        var config = new SynchroniserConfig(new ConfigurationBuilder().Build());
        config.CachingReadEnabled = true;
        config.CachingRootFolder = $"{projectPath}/Fixtures/SimpleMovementsFolder";
        
        Dependencies = new IntegrationTestDependenciesBuilder()
            .SetConfig(Path.Combine(Directory.GetCurrentDirectory(),
                @"../../../../TdmPrototypeBackend.Api/Properties/local.env"))
            .SetMongoDbName("tdm-prototype-backend-integration")
            .AddTestServices(services =>
            {
                services.AddSingleton<SynchroniserConfig>(config);
                services.AddSingleton<IBlobService>(sp => new CachingBlobService(sp.GetService<ILoggerFactory>(), config, new Mock<IBlobService>().Object));
                services.AddSingleton<IStorageService<Notification>>(new Mock<IStorageService<Notification>>().Object);
            })
            .Build();

        var movementService = Dependencies.ServiceProvider.GetService<IStorageService<Movement>>()!;

        var result = await Dependencies.ServiceProvider.GetService<ISyncService>().SyncMovements(SyncPeriod.All);

        result.Success.Should().Be(true);
        
        var existingMovement = await movementService.Find("CHEDPGB20241039875A5");

        existingMovement.Should().NotBeNull();
    }

    private Task SyncMovement(string path)
    {
        return GetSynService().SyncMovement(new SynchroniserBlobItem() { Name = path });
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