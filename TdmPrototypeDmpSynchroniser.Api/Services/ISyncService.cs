using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public enum SyncPeriod
{
    Today,
    LastMonth,
    ThisMonth,
    All
}
public interface ISyncService
{
    public Task<Status> SyncMovements(SyncPeriod period);
    public Task<Status> SyncNotifications(SyncPeriod period);

    public Task<Status> SyncGmrs(SyncPeriod period);

    Task<Status> SyncDecisions(SyncPeriod period);

}