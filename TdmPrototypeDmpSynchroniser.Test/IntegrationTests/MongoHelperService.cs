using JsonApiDotNetCore.MongoDb.Resources;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Data;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

public class MongoHelperService<T> : MongoService<T> where T : class, IMongoIdentifiable
{

    public MongoHelperService(IMongoDbClientFactory connectionFactory, ILoggerFactory loggerFactory, SynchroniserConfig config, MongoDbOptions<T> options)
        : base(connectionFactory, options.CollectionName, loggerFactory, config)
    {
        Logger.LogInformation($"Connecting {options.CollectionName} to MongoDB");
    }

    public Task ClearCollection()
    {
        return Collection.DeleteManyAsync(FilterDefinition<T>.Empty);
    }

    protected override List<CreateIndexModel<T>> DefineIndexes(IndexKeysDefinitionBuilder<T> builder)
    {
        return new List<CreateIndexModel<T>>();
    }
}