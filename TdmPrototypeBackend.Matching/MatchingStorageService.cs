using JsonApiDotNetCore.MongoDb.Resources;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Storage.Mongo;

namespace TdmPrototypeBackend.Matching;

public class MatchingStorageService<T> : MongoService<T>, IStorageService<T> where T : class, IMongoIdentifiable
{
    public MatchingStorageService(IMongoDbClientFactory connectionFactory, ILoggerFactory loggerFactory, MongoDbOptions<T> options)
        : base(connectionFactory, options.CollectionName, loggerFactory)
    {
        Logger.LogInformation("Connecting {OptionsCollectionName} to MongoDB", options.CollectionName);
    }

    public async Task Upsert(T item)
    {
        try
        {
            Logger.LogInformation("Upsert to MongoDB: {Id}", item.Id);

            await Collection.ReplaceOneAsync(
                filter: new BsonDocument("_id", item.Id),
                options: new ReplaceOptions() { IsUpsert = true },
                replacement: item);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex,"Error Upserting in Matching Storage");
            throw;
        }
    }

    public async Task<T> Find(string id)
    {
        try
        {
            Logger.LogInformation("Find in MongoDB: {Id}", id);
            var filter = Builders<T>.Filter.Eq(new StringFieldDefinition<T, string>("_id"), id);

            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex,"Error Finding in Matching Storage");
            throw;
        }
    }

    public Task<List<T>> Aggregate(PipelineDefinition<T, T> pipeline)
    {
        try
        {
            Logger.LogInformation("Aggregate in MongoDB");
            return Collection.Aggregate(pipeline).ToListAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex,"Error Aggregating in Matching Storage");
            throw;
        }
    }

    public Task<List<T>> Filter(FilterDefinition<T> pipeline)
    {
        try
        {
            Logger.LogInformation("Filter MongoDB");
            return Collection.FindSync(pipeline).ToListAsync();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex,"Error Filtering in Matching Storage");
            throw;
        }
    }
}