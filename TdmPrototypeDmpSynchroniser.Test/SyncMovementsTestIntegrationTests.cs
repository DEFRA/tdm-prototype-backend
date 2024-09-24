using FluentAssertions;
using FluentAssertions.Common;
using JsonApiDotNetCore.MongoDb.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Serilog;
using TdmPrototypeBackend.Api.Utils;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Data;
using TdmPrototypeDmpSynchroniser.Api.Extensions;
using TdmPrototypeDmpSynchroniser.Api.Services;

namespace TdmPrototypeDmpSynchroniser.Api.Models.Test;

public class MongoHelperService<T> : MongoService<T> where T : class, IMongoIdentifiable
{

    public MongoHelperService(IMongoDbClientFactory connectionFactory, ILoggerFactory loggerFactory, SynchroniserConfig config, MongoDbOptions<T> options)
        : base(connectionFactory, options.CollectionName, loggerFactory, config)
    {
        Logger.LogInformation($"Connecting {options.CollectionName} to MongoDB");
    }

    public Task ClearCollection()
    {
        return Collection.DeleteManyAsync(FilterDefinition<T>.Empty);
    }

    protected override List<CreateIndexModel<T>> DefineIndexes(IndexKeysDefinitionBuilder<T> builder)
    {
        return new List<CreateIndexModel<T>>();
    }
}

[Trait("Category", "Integration")]
public class SyncMovementsTestIntegrationTests
{
    private IServiceProvider serviceProvider;
    public SyncMovementsTestIntegrationTests()
    {
        var builder = WebApplication.CreateBuilder();
        var loggerConfiguration = new LoggerConfiguration();
        var logger = loggerConfiguration.CreateLogger();

        //This will look for your local.env file
        var path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),
            @"..\..\..\..\TdmPrototypeBackend.Api/Properties/local.env"));
        builder.Configuration.AddIniFile(path, false);
        
        var config = new List<KeyValuePair<string, string>>
        {
            new ("Mongo:DatabaseName", "tdm-prototype-backend-integration"),
            new ("AZURE_TENANT_ID", "c9d74090-b4e6-4b04-981d-e6757a160812")
        };
        builder.Configuration.AddInMemoryCollection(config);

        builder.Services.AddHttpProxyServices(logger, builder.Configuration);
        builder.Services.AddSingleton<MongoHelperService<Movement>>();
        builder.AddSynchroniserDatabase();
        builder.Services.AddSynchroniserServices();

        serviceProvider = builder.Services.BuildServiceProvider();

        var mongoHelper = serviceProvider.GetService<MongoHelperService<Movement>>();
        mongoHelper.ClearCollection().GetAwaiter().GetResult();
    }

    [Fact]
    public async Task CreateALVS_Integration()
    {
        await SyncMovement("RAW/ALVS/2024/02/14/ALVSCDSTEST0000314-361456c1-5369-4359-bb78-929121c618a6.json");
        await SyncMovement("RAW/ALVS/2024/02/14/ALVSCDSTEST0000314-a078fe92-de45-4477-a3c1-9d068669d905.json");

        var movementService = serviceProvider.GetService<IStorageService<Movement>>();

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
        existingMovement.AuditEntries[1].Diff.Count.Should().Be(7);
    }

    private Task SyncMovement(string path)
    {
        return GetSynService().SyncMovement(new SynchroniserBlobItem() { Name = path });
    }

    private SyncService GetSynService()
    {
        return serviceProvider.GetService<ISyncService>() as SyncService;
    }
}