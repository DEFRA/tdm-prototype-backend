using MongoDB.Driver;

namespace TdmPrototypeBackend.Storage.Mongo;

public interface IMongoDbClientFactory
{
    protected IMongoClient CreateClient();

    IMongoCollection<T> GetCollection<T>(string collection);
}