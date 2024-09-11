using MongoDB.Driver;

namespace TdmPrototypeDmpSynchroniser.Api.Data;

public interface IMongoDbClientFactory
{
    protected IMongoClient CreateClient();

    IMongoCollection<T> GetCollection<T>(string collection);
}