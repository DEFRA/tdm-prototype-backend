namespace TdmPrototypeBackend.Storage
{
    public interface IStorageService<T> where T : class
    {
        public Task Upsert(T item);

        public Task<T> Find(string id);
    }
}
