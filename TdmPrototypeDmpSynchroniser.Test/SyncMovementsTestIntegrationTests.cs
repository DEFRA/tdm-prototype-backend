using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TdmPrototypeBackend.Api.Utils;
using TdmPrototypeDmpSynchroniser.Api.Extensions;
using TdmPrototypeDmpSynchroniser.Api.Services;

namespace TdmPrototypeDmpSynchroniser.Api.Models.Test;

[Trait("Category", "Integration")]
public class SyncMovementsTestIntegrationTests
{
    private IServiceProvider serviceProvider;
    public SyncMovementsTestIntegrationTests()
    {
        var builder = WebApplication.CreateBuilder();
        var loggerConfiguration = new LoggerConfiguration();
        var logger = loggerConfiguration.CreateLogger();


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
        builder.AddSynchroniserDatabase();
        builder.Services.AddSynchroniserServices();

        serviceProvider = builder.Services.BuildServiceProvider();
    }

    [Fact]
    public async Task CreateALVS_Integration()
    {
        await SyncMovement("RAW/ALVS/2024/02/14/ALVSCDSTEST0000314-361456c1-5369-4359-bb78-929121c618a6.json");
        await SyncMovement("RAW/ALVS/2024/02/14/ALVSCDSTEST0000314-a078fe92-de45-4477-a3c1-9d068669d905.json");
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