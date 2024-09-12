using JsonApiConsumer;
using MongoDB.Driver;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Data;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public class MongoStorageService<T> : MongoService<T>, IStorageService<T> where T : class, new()
{   
    
    public MongoStorageService(IMongoDbClientFactory connectionFactory, ILoggerFactory loggerFactory, SynchroniserConfig config, MongoDbOptions<T> options)
        : base(connectionFactory, options.CollectionName, loggerFactory, config)
    {
        Logger.LogInformation($"Connecting {options.CollectionName} to MongoDB");
    }

    public async Task Upsert(T item)
    {
        try
        {
            Logger.LogInformation("Upsert to MongoDB");
            
            await Collection.InsertOneAsync(item);
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