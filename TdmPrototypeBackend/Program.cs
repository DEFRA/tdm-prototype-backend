using TdmPrototypeBackend.Config;
using TdmPrototypeBackend.Data;
using TdmPrototypeBackend.Endpoints;
using TdmPrototypeBackend.Services;
using TdmPrototypeBackend.Utils;
using FluentValidation;
using Serilog;

//-------- Configure the WebApplication builder------------------//

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddSingleton<IMongoDbClientFactory>(_ =>
    new MongoDbClientFactory(mongoUri,
        mongoDatabaseName));

// our service
builder.Services.AddSingleton<IBookService, BookService>();

// health checks
builder.Services.AddHealthChecks();

// http client
builder.Services.AddHttpClient();
builder.Services.AddHttpProxyClient(logger);

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
app.UseLibraryEndpoints();
app.MapHealthChecks("/health");

app.Run();
