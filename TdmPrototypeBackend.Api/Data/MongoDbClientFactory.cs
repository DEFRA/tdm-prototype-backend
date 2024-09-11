using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using ILogger = Serilog.ILogger;

namespace TdmPrototypeBackend.Api.Data;

public class MongoDbClientFactory : IMongoDbClientFactory
{
    private readonly string _connectionString;
    private readonly IMongoDatabase _mongoDatabase;
    private IMongoClient _client;
    ILogger<MongoDbClientFactory> _logger;

    public MongoDbClientFactory(ILogger<MongoDbClientFactory> logger,  string? connectionString, string databaseName)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("MongoDB connection string cannot be empty");
        _connectionString = connectionString;
        _client = CreateClient();
        _mongoDatabase = _client.GetDatabase(databaseName); // change me
        _logger = logger;
    }

    public IMongoClient CreateClient()
    {
        var settings = MongoClientSettings.FromConnectionString(_connectionString);
        _client = new MongoClient(settings);
        var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
        // convention must be registered before initialising collection
        ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
        return _client;
    }

    public IMongoCollection<T> GetCollection<T>(string collection)
    {
        return _mongoDatabase.GetCollection<T>(collection);
    }

    public List<string> GetCollections()
    {
        return _mongoDatabase.ListCollections().ToListAsync().Result.ConvertAll<string>(c => c["name"].ToString()!);
    }

    public void DropCollections()
    {
        try
        {
            var collections = GetCollections();
            _logger.LogInformation($"Dropping collections {collections}");
            collections.ForEach(c => _mongoDatabase.DropCollection(c));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
    }
}