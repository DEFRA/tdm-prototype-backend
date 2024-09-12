using MongoDB.Driver;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Data;
using TdmPrototypeDmpSynchroniser.Api.Services;

namespace TdmPrototypeDmpSynchroniser.Api.Extensions;

public static class ServiceExtensions
{
    
    // TODO at the moment synchroniser is using it's own DB to retain portability back to a seperate service if desired
    public static void AddSynchroniserDatabase(this WebApplicationBuilder builder)
    {
        
        // TODO - at the moment there's two different 
        var mongoUri = builder.Configuration.GetValue<string>("Mongo:DatabaseUri")!;
        var mongoDatabaseName = builder.Configuration.GetValue<string>("Mongo:DatabaseName")!;
        
        // if (builder.IsDevMode())
        // {
        //     logger.Information("MongoDB Connection mongoUri={mongoUri}, mongoDatabaseName={mongoDatabaseName}",
        //         mongoUri, mongoDatabaseName);
        // }

        // Mongo
        var factory = new MongoDbClientFactory(mongoUri,
            mongoDatabaseName);

        builder.Services.AddSingleton<IMongoDbClientFactory>(_ =>
        factory);
        
        
        builder.Services.AddSingleton<IMongoDatabase>(_ => factory.CreateClient().GetDatabase(mongoDatabaseName));
    }
    public static void AddSynchroniserServices(this IServiceCollection services)
    {
        
        
        services.AddSingleton<SynchroniserConfig, SynchroniserConfig>();
        services.AddKeyedSingleton<IBlobService, BlobService>("base");
        services.AddSingleton<IBlobService, CachingBlobService>();
        services.AddSingleton<IBusService, BusService>();
        services.AddSingleton<IWebService, WebService>();
        services.AddSingleton<ISyncService, SyncService>();
        // services.AddSingleton<IStorageService<Movement>, JsonApiStorageService<Movement>>();
        services.AddSingleton<MongoDbOptions<Movement>, MongoDbOptions<Movement>>(_ => new MongoDbOptions<Movement>() { CollectionName = "movements"});
        services.AddSingleton<IStorageService<Movement>, MongoStorageService<Movement>>();
        // services.AddSingleton<IStorageService<Movement>, MongoStorageService<Movement>>(x => ActivatorUtilities.CreateInstance<MongoStorageService>(x,"", ));
    }
}