using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public interface IWebService
{
    public Task<Status> CheckTradeApiAsync();
    public Task<Status> CheckTradeApiInternalAsync();
    public Task<Status> CheckGoogleAsync();
    
}