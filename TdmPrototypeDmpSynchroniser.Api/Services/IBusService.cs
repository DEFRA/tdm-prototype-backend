using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public interface IBusService
{
    public Task<Status> CheckBusAsync();

    public Task<Status> CheckBusAsync(string uri);
    
}