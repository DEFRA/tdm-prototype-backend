using JsonApiDotNetCore.MongoDb.Resources;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using TdmPrototypeBackend.Storage.Mongo;
using TdmPrototypeDmpSynchroniser.Api.Config;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

public class MongoHelperService<T> : MongoService<T> where T : class, IMongoIdentifiable
{

    public MongoHelperService(IMongoDbClientFactory connectionFactory, ILogger<T> logger, SynchroniserConfig config, MongoDbOptions<T> options)
        : base(connectionFactory, options.CollectionName, logger)
    {
        Logger.LogInformation("Connecting {OptionsCollectionName} to MongoDB", options.CollectionName);
    }

    public Task ClearCollection()
    {
        return Collection.DeleteManyAsync(FilterDefinition<T>.Empty);
    }
}