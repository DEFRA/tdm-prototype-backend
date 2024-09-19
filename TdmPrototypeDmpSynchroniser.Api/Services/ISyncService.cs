using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public interface ISyncService
{
    public Task<Status> SyncMovements();
    public Task<Status> SyncNotifications();
    
}