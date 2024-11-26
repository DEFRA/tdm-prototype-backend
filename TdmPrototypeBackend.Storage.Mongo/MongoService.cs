using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace TdmPrototypeBackend.Storage.Mongo;

public abstract class MongoService<T> 
{
    protected readonly IMongoCollection<T> Collection;

    protected readonly ILogger Logger;

    protected MongoService(IMongoDbClientFactory connectionFactory, string collectionName, ILoggerFactory loggerFactory)
    {
        Collection = connectionFactory.GetCollection<T>(collectionName);
        var loggerName = GetType().FullName ?? GetType().Name;
        Logger = loggerFactory.CreateLogger(loggerName);
    }

    public IndexKeysDefinitionBuilder<T> IndexBuilder => Builders<T>.IndexKeys;

    public void DefineIndexesIfNotPresent(params IndexKeysDefinition<T>[] definedKeys)
    {
        var indexes = definedKeys.Select(keys => new CreateIndexModel<T>(keys));
        Collection.Indexes.CreateMany(indexes);

        Logger.LogInformation(
            "Ensuring index is created if it does not exist for collection {CollectionNamespaceCollectionName} in DB {DatabaseDatabaseNamespace}",
            Collection.CollectionNamespace.CollectionName,
            Collection.Database.DatabaseNamespace);
    }
}