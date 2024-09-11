using TdmPrototypeBackend.Types;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public interface IStorageService<in T> where T : class
{
    public Task Upsert(T item);
}