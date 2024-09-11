using MongoDB.Driver;

namespace TdmPrototypeBackend.Data;

public interface IMongoDbClientFactory
{
    protected IMongoClient CreateClient();

    IMongoCollection<T> GetCollection<T>(string collection);
}