using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Serilog;
using TdmPrototypeBackend.Api.Utils;
using TdmPrototypeBackend.Matching.Extensions;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Extensions;
using TdmPrototypeDmpSynchroniser.Api.Services;
using Xunit.Abstractions;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

public class IntegrationTestDependenciesBuilder(ITestOutputHelper outputHelper)
{
    private string configPath = Path.Combine(Directory.GetCurrentDirectory(), @"../../../../TdmPrototypeBackend.Api/Properties/local.env");
    private string mongoDbName = "tdm-prototype-backend-integration";
    private List<Action<IServiceCollection>> testServices = new List<Action<IServiceCollection>>();

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
        this.testServices.Add(testServices);
        return this;
    }

    public IntegrationTestDependenciesBuilder UseLocalPathBlobStorage(string relativeLocalPath)
    {
        var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        var config = new SynchroniserConfig(new ConfigurationBuilder().Build());
        config.CachingReadEnabled = true;
        config.CachingRootFolder = $"{projectPath}/{relativeLocalPath}";
        this.AddTestServices(services =>
        {
            services.AddSingleton<IBlobService>(sp =>
                new CachingBlobService(sp.GetService<ILoggerFactory>(), config, new Mock<IBlobService>().Object));
        });
        return this;
    }


    public IntegrationTestDependencies Build()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddLogging((builder) => builder.AddXUnit(outputHelper));
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

        testServices?.ForEach(x => x(builder.Services));

        var serviceProvider = builder.Services.BuildServiceProvider();
        return new IntegrationTestDependencies(serviceProvider);
    }

}