namespace TdmPrototypeBackend.Storage.Mongo;

public interface IMongoDbManagementClientFactory : IMongoDbClientFactory
{
    public Task<List<string>> GetCollections();

    public Task DropCollections();
}