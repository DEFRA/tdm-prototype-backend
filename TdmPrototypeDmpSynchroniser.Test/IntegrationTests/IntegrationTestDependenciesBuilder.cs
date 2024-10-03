using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TdmPrototypeBackend.Api.Utils;
using TdmPrototypeBackend.Matching.Extensions;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeDmpSynchroniser.Api.Extensions;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

public class IntegrationTestDependenciesBuilder
{
    private string configPath = Path.Combine(Directory.GetCurrentDirectory(), @"../../../../TdmPrototypeBackend.Api/Properties/local.env");
    private string mongoDbName = "tdm-prototype-backend-integration";
    private Action<IServiceCollection> testServices;

    public IntegrationTestDependenciesBuilder SetConfig(string path)
    {
        configPath = path;
        return this;
    }

    public IntegrationTestDependenciesBuilder SetMongoDbName(string name)
    {
        mongoDbName = name;
        return this;
    }

    public IntegrationTestDependenciesBuilder AddTestServices(Action<IServiceCollection> testServices)
    {
        this.testServices = testServices;
        return this;
    }


    public IntegrationTestDependencies Build()
    {
        var builder = WebApplication.CreateBuilder();
        var loggerConfiguration = new LoggerConfiguration();
        var logger = loggerConfiguration.CreateLogger();

        //This will look for your local.env file
        var path = new Uri(configPath).LocalPath;

        builder.Configuration.AddIniFile(path, false);

        var config = new List<KeyValuePair<string, string>>
        {
            new ("Mongo:DatabaseName", mongoDbName),
            new ("AZURE_TENANT_ID", "c9d74090-b4e6-4b04-981d-e6757a160812")
        };
        builder.Configuration.AddInMemoryCollection(config);
        builder.Services.AddMatchingService();
        builder.Services.AddHttpProxyServices(logger, builder.Configuration);
        builder.Services.AddSingleton<MongoHelperService<Movement>>();
        builder.Services.AddSingleton<MongoHelperService<Notification>>();
        builder.AddSynchroniserDatabase();
        builder.Services.AddSynchroniserServices();

        if (testServices is not null)
        {
            testServices(builder.Services);
        }

        //AddTestServices(builder.Services);

        var serviceProvider = builder.Services.BuildServiceProvider();
        return new IntegrationTestDependencies(serviceProvider);
    }

}