using System.Reflection;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Config;
using TdmPrototypeBackend.Data;
using TdmPrototypeBackend.Utils;
using FluentValidation;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.MongoDb.Configuration;
using JsonApiDotNetCore.MongoDb.Repositories;
using JsonApiDotNetCore.Repositories;
using Microsoft.AspNetCore.HttpLogging;
using MongoDB.Driver;
using Serilog;
using TdmPrototypeBackend.Types;
// using TdmPrototypeBackend.Models;

//-------- Configure the WebApplication builder------------------//

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});

// Grab environment variables
builder.Configuration.AddEnvironmentVariables("CDP");
builder.Configuration.AddEnvironmentVariables();

// Serilog
builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.With<LogLevelMapper>()
    .CreateLogger();
builder.Logging.AddSerilog(logger);

logger.Information("Starting application");

// Load certificates into Trust Store - Note must happen before Mongo and Http client connections 
TrustStore.SetupTrustStore(logger);

var mongoUri = builder.Configuration.GetValue<string>("Mongo:DatabaseUri")!;
var mongoDatabaseName = builder.Configuration.GetValue<string>("Mongo:DatabaseName")!;
    
if (builder.IsDevMode())
{
    logger.Information("MongoDB Connection mongoUri={mongoUri}, mongoDatabaseName={mongoDatabaseName}",
        mongoUri, mongoDatabaseName);
}

// Mongo
var factory = new MongoDbClientFactory(mongoUri,
    mongoDatabaseName);

builder.Services.AddSingleton<IMongoDbClientFactory>(_ =>
    factory);

// health checks
builder.Services.AddHealthChecks();

// http client
builder.Services.AddHttpClient();
builder.Services.AddHttpProxyClient(logger);

// JSON API

static void ConfigureJsonApiOptions(JsonApiOptions options)
{
    options.Namespace = "api";
    options.UseRelativeLinks = true;
    options.IncludeTotalResourceCount = true;
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
#if DEBUG
    options.IncludeExceptionStackTraceInErrors = true;
    options.IncludeRequestBodyInErrors = true;
    options.SerializerOptions.WriteIndented = true;
#endif
}

builder.Services.AddSingleton<IMongoDatabase>(_ => factory.CreateClient().GetDatabase(mongoDatabaseName));
builder.Services.AddJsonApi(resources: resourceGraphBuilder =>
{
    resourceGraphBuilder.Add<ClearanceRequest, string?>();
    resourceGraphBuilder.Add<GvmsGmr, string?>();
    resourceGraphBuilder.Add<IpaffsNotification, string?>();
    // resourceGraphBuilder.Add<Item, string?>();
});
// builder.Services.AddJsonApi(ConfigureJsonApiOptions, discovery => discovery.AddCurrentAssembly());
// builder.Services.AddJsonApi(ConfigureJsonApiOptions, discovery => discovery.());
builder.Services.AddJsonApi(ConfigureJsonApiOptions, discovery => discovery.AddAssembly(Assembly.Load("TdmPrototypeBackend.Types")));
builder.Services.AddJsonApiMongoDb();

builder.Services.AddScoped(typeof(IResourceReadRepository<,>), typeof(MongoRepository<,>));
builder.Services.AddScoped(typeof(IResourceWriteRepository<,>), typeof(MongoRepository<,>));
builder.Services.AddScoped(typeof(IResourceRepository<,>), typeof(MongoRepository<,>));

// swagger endpoints
if (builder.IsSwaggerEnabled())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

if (builder.IsSwaggerEnabled())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseJsonApi();
app.MapControllers();
app.MapHealthChecks("/health");
app.UseHttpLogging();

app.Run();
