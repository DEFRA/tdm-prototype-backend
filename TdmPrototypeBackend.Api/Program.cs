using System.Reflection;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Api.Config;
using TdmPrototypeBackend.Api.Utils;
using TdmPrototypeBackend.Api.Extensions;
using FluentValidation;
using HealthChecks.UI.Client;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.MongoDb.Configuration;
using JsonApiDotNetCore.MongoDb.Repositories;
using JsonApiDotNetCore.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic.CompilerServices;
using MongoDB.Driver;
using Serilog;
using TdmPrototypeBackend.Api.Endpoints;
using TdmPrototypeBackend.Api.HealthChecks;
using TdmPrototypeBackend.Api.JsonApi;
using TdmPrototypeDmpSynchroniser.Api.Endpoints;
using TdmPrototypeBackend.Api.Utils;
using TdmPrototypeBackend.Matching;
using TdmPrototypeBackend.Matching.Extensions;
using TdmPrototypeBackend.Types;
using TdmPrototypeCdsSimulator.Extensions;
using TdmPrototypeDmpSynchroniser.Api.Extensions;
using TdmPrototypeBackend.Api.Swagger;

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


builder.Services.AddJsonApi(ConfigureJsonApiOptions, discovery => discovery.AddAssembly(Assembly.Load("TdmPrototypeBackend.Types")));

builder.Services.AddJsonApiMongoDb();
builder.Services.AddResourceDefinition<NotificationResource>();
builder.Services.AddResourceDefinition<MovementResource>();
builder.Services.AddScoped<ITdmClaimsProvider, TdmClaimsPrincipalProvider>();
builder.Services.AddTransient<IClaimsTransformation, TdmClaimsTransformer>();

builder.AddTdmAuthentication(new BackendConfig(builder.Configuration));
builder.AddTdmAuthorisation(new BackendConfig(builder.Configuration));

// Expose the synchroniser project
builder.AddSynchroniserDatabase();
builder.Services.AddSynchroniserServices();

builder.Services.AddScoped(typeof(IResourceReadRepository<,>), typeof(MongoRepository<,>));
builder.Services.AddScoped(typeof(IResourceWriteRepository<,>), typeof(MongoRepository<,>));
builder.Services.AddScoped(typeof(IResourceRepository<,>), typeof(MongoRepository<,>));

builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample");

//Add CDS Simulator
builder.Services.AddCdsSimulator();

//Add Matching Service
builder.Services.AddMatchingService();

// swagger endpoints
if (builder.IsSwaggerEnabled())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        c.SwaggerDoc("internal-v0.1", new OpenApiInfo { Title = "My API", Version = "internal-v0.1" });
        c.SwaggerDoc("public-v0.1", new OpenApiInfo { Title = "My API", Version = "v0.1" });
        

        c.DocInclusionPredicate((name, api) =>  !name.StartsWith("public"));
        c.DocumentFilter<DocumentFilter>();
    });
}
builder.Services.AddValidatorsFromAssemblyContaining<Program>();



var app = builder.Build();

if (builder.IsSwaggerEnabled())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/internal-v0.1/swagger.json", "internal");
        options.SwaggerEndpoint("/swagger/public-v0.1/swagger.json", "public");
    });
}

app.UseRouting();
app.UseJsonApi();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseDiagnosticEndpoints();
app.UseManagementEndpoints(new BackendConfig(builder.Configuration));
app.UseSyncEndpoints();

app.UseCdsSimulator();
// app.MapHealthChecks("/health")

app.MapHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpLogging();

app.Run();
