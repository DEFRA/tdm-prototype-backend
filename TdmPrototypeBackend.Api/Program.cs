using System.Reflection;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Api.Config;
using TdmPrototypeBackend.Api.Data;
using TdmPrototypeBackend.Api.Utils;
using FluentValidation;
using HealthChecks.UI.Client;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.MongoDb.Configuration;
using JsonApiDotNetCore.MongoDb.Repositories;
using JsonApiDotNetCore.Repositories;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.VisualBasic.CompilerServices;
using MongoDB.Driver;
using Serilog;
using TdmPrototypeBackend.Api.Endpoints;
using TdmPrototypeBackend.Api.HealthChecks;
using TdmPrototypeDmpSynchroniser.Api.Endpoints;
using TdmPrototypeBackend.Api.Utils;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Extensions;

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
builder.Configuration.AddIniFile("Properties/local.env", true);

// Serilog
builder.Logging.ClearProviders();
var loggerConfiguration = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.With<LogLevelMapper>();

// Is there something better we can do here:
var loggerFactory = builder.Services.BuildServiceProvider()
    .GetService<ILoggerFactory>()!;

TdmPrototypeBackend.Api.Utils.ApplicationLogging.LoggerFactory = loggerFactory;


var logger = loggerConfiguration
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
var factory = new MongoDbClientFactory(loggerFactory.CreateLogger<MongoDbClientFactory>(), mongoUri,
    mongoDatabaseName);

builder.Services.AddSingleton<IMongoDbClientFactory>(_ =>
    factory);

// health checks
builder.Services.AddHealthChecks();

// http client
builder.Services.AddHttpClient();
builder.Services.AddHttpProxyServices(logger, builder.Configuration);

// TODO Refactor this and tidy up
// JSON API

static void ConfigureJsonApiOptions(JsonApiOptions options)
{ 
    options.Namespace = "api";
    options.UseRelativeLinks = true;
    options.IncludeTotalResourceCount = true;
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.ClientIdGeneration = ClientIdGenerationMode.Allowed;
    // options.AllowClientGeneratedIds = true;
#if DEBUG
    options.IncludeExceptionStackTraceInErrors = true;
    options.IncludeRequestBodyInErrors = true;
    options.SerializerOptions.WriteIndented = true;
#endif
}

builder.Services.AddSingleton<BackendConfig, BackendConfig>();

builder.Services.AddSingleton<IMongoDatabase>(_ => factory.CreateClient().GetDatabase(mongoDatabaseName));

builder.Services.AddJsonApi(ConfigureJsonApiOptions, discovery => discovery.AddAssembly(Assembly.Load("TdmPrototypeBackend.Types")));

builder.Services.AddJsonApiMongoDb();

// Expose the synchroniser project
builder.AddSynchroniserDatabase();
builder.Services.AddSynchroniserServices();

builder.Services.AddScoped(typeof(IResourceReadRepository<,>), typeof(MongoRepository<,>));
builder.Services.AddScoped(typeof(IResourceWriteRepository<,>), typeof(MongoRepository<,>));
builder.Services.AddScoped(typeof(IResourceRepository<,>), typeof(MongoRepository<,>));

builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample");

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
app.UseDiagnosticEndpoints();
app.UseManagementEndpoints(new BackendConfig(builder.Configuration));
app.UseSyncEndpoints();
// app.MapHealthChecks("/health")

app.MapHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpLogging();

app.Run();
