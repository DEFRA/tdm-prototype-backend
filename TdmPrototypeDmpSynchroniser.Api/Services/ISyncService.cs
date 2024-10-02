using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public enum SyncPeriod
{
    Today,
    LastMonth,
    ThisMonth,
    LastMonth,
    All
}
public interface ISyncService
{
    public Task<Status> SyncMovements(SyncPeriod period);
    public Task<Status> SyncNotifications(SyncPeriod period);
    
}