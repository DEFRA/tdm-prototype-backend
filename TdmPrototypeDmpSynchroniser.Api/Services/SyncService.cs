using Azure.Storage.Blobs.Models;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public class SyncService(ILoggerFactory loggerFactory, SynchroniserConfig config, IBlobService blobService, IStorageService<Movement> movementService, IStorageService<IpaffsNotification> notificationService)
    : BaseService(loggerFactory, config), ISyncService
{
    
    public async Task<Status> SyncMovements()
    {
        try
        {
            // TODO need to figure out how we select path
            
            var result = await blobService.GetResourcesAsync("RAW/ALVS/2024/09/");
            
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
            // throw new Exception();
            return MovementExtensions.FromClearanceRequest(blob.Content);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to convert file {item.Name} to movement. {ex.ToString()}. {blob.Content}");
            throw;
        }
    }
    
    public async Task<Status> SyncIpaffsNotifications()
    {
        try
        {
            // TODO need to figure out how we select path
            
            var result = await blobService.GetResourcesAsync("RAW/IPAFFS/CHEDP/2024/09/");
            
            var itemCount = 0;
            var erroredCount = 0;
            foreach (IBlobItem item in result.Take(5)) //) //
            {
                try
                {
                    await notificationService.Upsert(await ConvertIpaffsNotification(item));
                    itemCount++;
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Failed to upsert ipaffs notification from file {item.Name}. {ex.ToString()}.");
                    
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

    private async Task<IpaffsNotification> ConvertIpaffsNotification(IBlobItem item)
    {
        var blob = await blobService.GetBlobAsync(item.Name);

        try
        {
            // throw new Exception();
            return IpaffsNotificationExtensions.FromBlob(blob.Content);
        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to convert file {item.Name} to ipaffs notification. {ex.ToString()}. {blob.Content}");
            throw;
        }
    }

}