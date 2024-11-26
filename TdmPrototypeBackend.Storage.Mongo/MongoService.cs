using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace TdmPrototypeBackend.Storage.Mongo;

public abstract class MongoService<T> 
{
    protected readonly IMongoCollection<T> Collection;

    protected readonly ILogger Logger;

    protected MongoService(IMongoDbClientFactory connectionFactory, string collectionName, ILogger<T> logger)
    {
        Collection = connectionFactory.GetCollection<T>(collectionName);
        Logger = logger;
    }

    public IndexKeysDefinitionBuilder<T> IndexBuilder => Builders<T>.IndexKeys;

    public async Task DefineIndexesIfNotPresentAsync(params IndexKeysDefinition<T>[] definedKeys)
    {
        var indexes = definedKeys.Select(keys => new CreateIndexModel<T>(keys));
        await Collection.Indexes.CreateManyAsync(indexes);

        Logger.LogInformation(
            "Ensuring index is created if it does not exist for collection {CollectionNamespaceCollectionName} in DB {DatabaseDatabaseNamespace}",
            Collection.CollectionNamespace.CollectionName,
            Collection.Database.DatabaseNamespace);
    }
}