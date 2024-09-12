using Azure.Storage.Blobs.Models;
using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public interface IBlobService
{
    public Task<Status> CheckBlobAsync();
    public Task<Status> CheckBlobAsync(string uri);
    public Task<IEnumerable<IBlobItem>> GetResourcesAsync(string prefix);
    public Task<IBlobItem?> GetBlobAsync(string path);
    
}