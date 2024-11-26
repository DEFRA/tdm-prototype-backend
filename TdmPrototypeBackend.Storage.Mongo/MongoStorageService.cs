using System.Diagnostics;
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
        Logger.LogInformation("Connecting {OptionsCollectionName} to MongoDB", options.CollectionName);
    }

    public async Task Upsert(T item)
    {
        try
        {
            var stopwatch = Stopwatch.StartNew();
            await Collection.ReplaceOneAsync( 
                filter: new BsonDocument("_id", item.Id),
                options: new ReplaceOptions() {IsUpsert = true},
                replacement: item);
            Logger.LogInformation("Upsert MongoDB in Mongo Storage took {Elapsed} ms", stopwatch.Elapsed.TotalMilliseconds.ToString("N3"));
        }
        catch (Exception ex)
        {
            Logger.LogError(ex,"Upsert MongoDB Error in Mongo Storage");
            throw;
        }
    }

    public async Task<T> Find(string id)
    {
        try
        {
            var filter = Builders<T>.Filter.Eq(new StringFieldDefinition<T, string>("_id"), id);

            var stopwatch = Stopwatch.StartNew();
            var result = await Collection.Find(filter).FirstOrDefaultAsync();
            Logger.LogInformation("Find MongoDB in Mongo Storage took {Elapsed} ms", stopwatch.Elapsed.TotalMilliseconds.ToString("N3"));
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex,"Find MongoDB Error in Mongo Storage");
            throw;
        }
    }

    public Task<List<T>> Aggregate(PipelineDefinition<T, T> pipeline)
    {
        try
        {
            var stopwatch = Stopwatch.StartNew();
            var result = Collection.Aggregate(pipeline).ToListAsync();
            Logger.LogInformation("Aggregate MongoDB in Mongo Storage took {Elapsed} ms", stopwatch.Elapsed.TotalMilliseconds.ToString("N3"));
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex,"Aggregate MongoDB Error in Mongo Storage");
            throw;
        }
    }

    public Task<List<T>> Filter(FilterDefinition<T> pipeline)
    {
        try
        {
            var stopwatch = Stopwatch.StartNew();
            var result = Collection.FindSync(pipeline).ToListAsync();
            Logger.LogInformation("Filter MongoDB in Matching Storage took {Elapsed} ms", stopwatch.Elapsed.TotalMilliseconds.ToString("N3"));
            return result;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex,"Filter MongoDB Error in Mongo Storage");
            throw;
        }
    }
}