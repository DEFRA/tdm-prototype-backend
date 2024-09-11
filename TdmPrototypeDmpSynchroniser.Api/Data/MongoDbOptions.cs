using Microsoft.Extensions.Options;

namespace TdmPrototypeDmpSynchroniser.Api.Data;

public class MongoDbOptions<T> //: IOptions<T> where T : class, new()
{
    public string CollectionName { get; set; }
}