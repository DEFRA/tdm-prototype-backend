using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace TdmPrototypeBackend.Storage.Mongo.Extensions;

public static class ServiceExtensions
{
    
    // TODO at the moment synchroniser is using it's own DB to retain portability back to a seperate service if desired
    public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        
        // TODO - at the moment there's two different 
        var mongoUri = configuration.GetValue<string>("Mongo:DatabaseUri")!;
        var mongoDatabaseName = configuration.GetValue<string>("Mongo:DatabaseName")!;
        
        // if (builder.IsDevMode())
        // {
        //     logger.Information("MongoDB Connection mongoUri={mongoUri}, mongoDatabaseName={mongoDatabaseName}",
        //         mongoUri, mongoDatabaseName);
        // }

        // Mongo
        var factory = new MongoDbClientFactory(mongoUri,
            mongoDatabaseName);

        services.AddSingleton<IMongoDbClientFactory>(_ =>
        factory);
        
        
        services.AddSingleton<IMongoDatabase>(_ => factory.CreateClient().GetDatabase(mongoDatabaseName));
    }
}