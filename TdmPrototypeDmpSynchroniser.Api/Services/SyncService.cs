using Azure.Storage.Blobs.Models;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public class SyncService(ILoggerFactory loggerFactory, SynchroniserConfig config, IBlobService blobService, IStorageService<Movement> movementService)
    : BaseService(loggerFactory, config), ISyncService
{
    
    public async Task<Status> SyncMovements()
    {
        try
        {
            var result = await blobService.GetResourcesAsync("RAW/ALVS/");
            
            var itemCount = 0;
            var erroredCount = 0;
            foreach (IBlobItem item in result.Take(5)) //
            {
                try
                {
                    await movementService.Upsert(await ConvertMovement(item));
                    itemCount++;
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex.ToString());
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
        
        Logger.LogInformation(blob.Content);
        
        return MovementExtensions.FromClearanceRequest(blob.Content);
    }

}