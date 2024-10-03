using JsonApiDotNetCore.MongoDb.Resources;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TdmPrototypeBackend.Storage.Mongo;

public class MongoStorageService<T> : MongoService<T>, IStorageService<T> where T : class, IMongoIdentifiable
{   
    
    public MongoStorageService(IMongoDbClientFactory connectionFactory, ILoggerFactory loggerFactory,  MongoDbOptions<T> options)
        : base(connectionFactory, options.CollectionName, loggerFactory)
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

    public Task<List<T>> Pipeline(PipelineDefinition<T, T> pipeline)
    {
        try
        {

            return Collection.Aggregate(pipeline).ToListAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            throw;
        }

    }

    public Task<List<T>> Filter(FilterDefinition<T> pipeline)
    {
        try
        {

            return Collection.FindSync(pipeline).ToListAsync();
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