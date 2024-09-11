using JsonApiConsumer;
using MongoDB.Driver;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Data;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public class MongoStorageService<T> : MongoService<T>, IStorageService<T> where T : class, new()
{   
    
    public MongoStorageService(IMongoDbClientFactory connectionFactory, ILoggerFactory loggerFactory, SynchroniserConfig config, MongoDbOptions<Movement> options)
        : base(connectionFactory, "Movement", loggerFactory, config)
    {
        Logger.LogInformation($"Connecting movement to MongoDB");
    }

    public async Task Upsert(T item)
    {
        try
        {
            Logger.LogInformation("Upsert to MongoDB");
            
            await Collection.InsertOneAsync(item);
            
            // Response<Movement> response = JsonApiConsumer.JsonApiConsumer.Create<Movement, Movement>(
            //     model: movement,
            //     baseURI: Config.TdmBackendApiUri,
            //     path: "api/movements"
            // );
            //
            // Logger.LogInformation($"HTTP Response {response.HttpStatusCode}");
            // if (response.DocumentRoot != null)
            // {
            //     Logger.LogInformation(response.DocumentRoot.ToString());    
            // }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            throw;
        }

    }

    protected override List<CreateIndexModel<T>> DefineIndexes(IndexKeysDefinitionBuilder<T> builder)
    {
        return new List<CreateIndexModel<T>>();
    }
}