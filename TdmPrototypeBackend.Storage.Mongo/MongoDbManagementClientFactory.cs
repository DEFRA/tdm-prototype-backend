using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace TdmPrototypeBackend.Storage.Mongo;

public class MongoDbManagementClientFactory(
    ILogger<MongoDbManagementClientFactory> logger,
    string? connectionString,
    string databaseName)
    : MongoDbClientFactory(connectionString, databaseName), IMongoDbManagementClientFactory
{
    public async Task<List<string>> GetCollections()
    {
        var collections = await (await MongoDatabase.ListCollectionsAsync()).ToListAsync();
        return  collections.ConvertAll<string>(c => c["name"].ToString()!);
    }

    public async Task DropCollections()
    {
        try
        {
            var collections = await GetCollections();
            logger.LogInformation($"Dropping collections {collections}");
            collections.ForEach(c => MongoDatabase.DropCollection(c));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


    }
}