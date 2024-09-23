using Azure.Storage.Blobs.Models;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Models;
using Status = TdmPrototypeDmpSynchroniser.Api.Models.Status;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public class SyncService(ILoggerFactory loggerFactory, SynchroniserConfig config, IBlobService blobService, IStorageService<Movement> movementService, IStorageService<Notification> notificationService)
    : BaseService(loggerFactory, config), ISyncService
{

    private static string GetPeriodPath(SyncPeriod period)
    {
        if (period == SyncPeriod.ThisMonth)
        {
            return DateTime.Today.ToString("/yyyy/MM/");
        }
        else if (period == SyncPeriod.Today)
        {
            return DateTime.Today.ToString("/yyyy/MM/dd/");
        }
        return "/";
    }
    
    public async Task<Status> SyncMovements(SyncPeriod period)
    {
        Logger.LogInformation($"SyncMovements period={period}");
        try
        {
            // TODO need to figure out how we select path
            
            var result = await blobService.GetResourcesAsync($"RAW/ALVS{GetPeriodPath(period)}");
            
            var itemCount = 0;
            var erroredCount = 0;
            foreach (IBlobItem item in result) //.Take(5)) //
            {
                try
                {
                    await movementService.Upsert(await ConvertMovement(item));
                    itemCount++;
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Failed to upsert movement from file {item.Name}. {ex.ToString()}.");
                    
                    erroredCount++;
                }
            }
            
            return new Status()
            {
                Success = true, Description = String.Format($"Connected. {itemCount} items upserted. {erroredCount} errors.")
            };
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            
            return new Status() { Success = false, Description = ex.Message };
        }
    }

    private async Task<Movement> ConvertMovement(IBlobItem item)
    {
        var blob = await blobService.GetBlobAsync(item.Name);

        try
        {
            return MovementExtensions.FromClearanceRequest(blob.Content);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to convert file {item.Name} to movement. {ex.ToString()}. {blob.Content}");
            throw;
        }
    }
    
    public async Task<Status> SyncNotifications(SyncPeriod period)
    {
        Logger.LogInformation($"SyncNotifications period={period}");
        try
        {
            var itemCount = 0;
            var erroredCount = 0;
        
            // TODO need to figure out how we select path

            var (e, i) = await SyncIpaffsNotifications($"RAW/IPAFFS/CHEDA{GetPeriodPath(period)}");
            itemCount += i;
            erroredCount += e;
                
            (e, i) = await SyncIpaffsNotifications($"RAW/IPAFFS/CHEDD{GetPeriodPath(period)}");
            itemCount += i;
            erroredCount += e;
            
            (e, i) = await SyncIpaffsNotifications($"RAW/IPAFFS/CHEDP{GetPeriodPath(period)}");
            itemCount += i;
            erroredCount += e;
            
            (e, i) = await SyncIpaffsNotifications($"RAW/IPAFFS/CHEDPP{GetPeriodPath(period)}");
            itemCount += i;
            erroredCount += e;
            
            return new Status()
            {
                Success = true, Description = String.Format($"Connected. {itemCount} items upserted. {erroredCount} errors.")
            };
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            
            return new Status() { Success = false, Description = ex.Message };
        }
    }
    
    public async Task<(int, int)> SyncIpaffsNotifications(string path)
    {
        var itemCount = 0;
        var erroredCount = 0;

        try
        {
            // TODO need to figure out how we select path

            var result = await blobService.GetResourcesAsync(path);

            foreach (IBlobItem item in result) //) //
            {
                try
                {
                    var n = await ConvertIpaffsNotification(item);
                    await notificationService.Upsert(n);
                    itemCount++;
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Failed to upsert ipaffs notification from file {item.Name}. {ex.ToString()}.");

                    erroredCount++;
                }
            }

        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
        }
        
        return (erroredCount, itemCount);
    }

    private async Task<Notification> ConvertIpaffsNotification(IBlobItem item)
    {
        var blob = await blobService.GetBlobAsync(item.Name);

        try
        {
            // throw new Exception();
            return NotificationExtensions.FromBlob(blob.Content);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to convert file {item.Name} to ipaffs notification. {ex.ToString()}. {blob.Content}");
            throw;
        }
    }

}