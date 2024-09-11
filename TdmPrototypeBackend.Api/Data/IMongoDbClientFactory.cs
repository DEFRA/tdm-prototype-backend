using MongoDB.Driver;

namespace TdmPrototypeBackend.Api.Data;

public interface IMongoDbClientFactory
{
    public IMongoClient CreateClient();

    IMongoCollection<T> GetCollection<T>(string collection);

    public List<string> GetCollections();
    
    public void DropCollections();
}