using MongoDB.Driver;

namespace TdmPrototypeBackend.Storage
{
    public interface IStorageService<T> where T : class
    {
        Task Upsert(T item);

        Task<T> Find(string id);
        
        Task<List<T>> Filter(FilterDefinition<T> pipeline);
    }
}
