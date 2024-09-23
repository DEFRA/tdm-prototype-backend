using JsonApiConsumer;
using JsonApiDotNetCore.MongoDb.Resources;
using MongoDB.Bson;
using MongoDB.Driver;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Data;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public class MongoStorageService<T> : MongoService<T>, IStorageService<T> where T : class, IMongoIdentifiable
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
            
            await Collection.ReplaceOneAsync( 
                filter: new BsonDocument("_id", item.Id),
                options: new ReplaceOptions() {IsUpsert = true},
                replacement: item);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            throw;
        }

    }

    public async Task<T> Find(string id)
    {
        try
        {
            Logger.LogInformation("Upsert to MongoDB");
            var filter = Builders<T>.Filter.Eq(new StringFieldDefinition<T, string>("_id"), id);

            return await Collection.Find(filter).FirstOrDefaultAsync();
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