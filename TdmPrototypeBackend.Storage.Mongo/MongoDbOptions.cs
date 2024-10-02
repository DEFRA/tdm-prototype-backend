namespace TdmPrototypeBackend.Storage.Mongo;

public class MongoDbOptions<T> //: IOptions<T> where T : class, new()
{
    public string CollectionName { get; set; }
}