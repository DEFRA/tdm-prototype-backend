using System.Dynamic;
using System.Text.Json.JsonDiffPatch;
using System.Text.Json.Nodes;
using Json.Patch;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Extensions;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Models;
using Status = TdmPrototypeDmpSynchroniser.Api.Models.Status;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public class SyncService(ILoggerFactory loggerFactory, SynchroniserConfig config, IBlobService blobService, IStorageService<Movement> movementService, IStorageService<Notification> notificationService)
    : BaseService(loggerFactory, config), ISyncService
{
    
    public async Task<Status> SyncMovements()
    {
        try
        {
            // TODO need to figure out how we select path
            
            var result = await blobService.GetResourcesAsync("RAW/ALVS/");
            
            var itemCount = 0;
            var erroredCount = 0;
            foreach (IBlobItem item in result) //.Take(5)) //
            {
                try
                {
                    var movement = await ConvertMovement(item);
                    var existingMovement = await movementService.Find(movement.Id);

                    if (existingMovement is not null)
                    {
                        if (movement.ClearanceRequests.First().Header.EntryVersionNumber > existingMovement.ClearanceRequests.First().Header.EntryVersionNumber)
                        {
                            movement.AuditEntries = existingMovement.AuditEntries;
                            var auditEntry = AuditEntry.Create(existingMovement, movement,
                                BuildNormalizedAlvsPath(item.Name),
                                existingMovement.ClearanceRequests.First().Header.EntryVersionNumber.GetValueOrDefault(), movement.LastUpdated.ToString(),
                                string.Empty);

                            movement.AuditEntries.Add(auditEntry);
                            await movementService.Upsert(movement);
                            itemCount++;
                        }
                    }
                    else
                    {
                        await movementService.Upsert(movement);
                        itemCount++;
                    }

                   
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
    
    public async Task<Status> SyncNotifications()
    {
        try
        {
            var itemCount = 0;
            var erroredCount = 0;
        
            // TODO need to figure out how we select path

            var (e, i) = await SyncIpaffsNotifications("RAW/IPAFFS/CHEDA/2024/09/");
            itemCount += i;
            erroredCount += e;
                
            (e, i) = await SyncIpaffsNotifications("RAW/IPAFFS/CHEDD/2024/09/");
            itemCount += i;
            erroredCount += e;
            
            (e, i) = await SyncIpaffsNotifications("RAW/IPAFFS/CHEDP/2024/09/");
            itemCount += i;
            erroredCount += e;
            
            (e, i) = await SyncIpaffsNotifications("RAW/IPAFFS/CHEDPP/2024/09/");
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
    
    public async Task<(int, int)> SyncIpaffsNotifications(string path = "RAW/IPAFFS/")
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
                    var existingNotification = await notificationService.Find(n.Id);

                    if (existingNotification is not null)
                    {
                        if (n.Version > existingNotification.Version)
                        {
                            n.AuditEntries = existingNotification.AuditEntries;

                            if ((n.Version - existingNotification.Version) == 1)
                            {
                                var auditEntry = AuditEntry.Create(existingNotification,
                                    n,
                                    BuildNormalizedIpaffsPath(item.Name),
                                    existingNotification.Version.GetValueOrDefault(),
                                    n.LastUpdated,
                                    n.LastUpdatedBy?.DisplayName);
                                n.AuditEntries.Add(auditEntry);
                            }
                            else
                            {
                                var auditEntry = AuditEntry.CreateSkippedVersion(
                                    n,
                                    BuildNormalizedIpaffsPath(item.Name),
                                    existingNotification.Version.GetValueOrDefault(),
                                    n.LastUpdated,
                                    n.LastUpdatedBy?.DisplayName);
                                n.AuditEntries.Add(auditEntry);
                            }

                            var s = n.AuditEntries.ToJsonString();
                            await notificationService.Upsert(n);
                            itemCount++;
                        }
                    }
                    else
                    {
                        await notificationService.Upsert(n);
                        itemCount++;
                    }


                    
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

    private string BuildNormalizedIpaffsPath(string fullPath)
    {
        return fullPath.Replace("\"RAW/IPAFFS/", "");
    }

    private string BuildNormalizedAlvsPath(string fullPath)
    {
        return fullPath.Replace("\"RAW/ALVS/", "");
    }

}