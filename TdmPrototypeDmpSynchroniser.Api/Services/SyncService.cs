using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text.Json.JsonDiffPatch;
using System.Text.Json.Nodes;
using Json.Patch;
using TdmPrototypeBackend.Matching;
using TdmPrototypeBackend.Storage;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Extensions;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Models;
using Status = TdmPrototypeDmpSynchroniser.Api.Models.Status;

namespace TdmPrototypeDmpSynchroniser.Api.Services;


public enum SyncStatus
{
    Failed,
    Success,
    SuccessAndMatched
}
public class SyncService(ILoggerFactory loggerFactory, SynchroniserConfig config, IBlobService blobService, IStorageService<Movement> movementService, IStorageService<Notification> notificationService, IMatchingService matchingService)
    : BaseService(loggerFactory, config), ISyncService
{

    private static string GetPeriodPath(SyncPeriod period)
    {
        if (period == SyncPeriod.LastMonth)
        {
            return DateTime.Today.AddMonths(-1).ToString("/yyyy/MM/");
        }
        else if (period == SyncPeriod.ThisMonth)
        {
            return DateTime.Today.ToString("/yyyy/MM/");
        }
        else if (period == SyncPeriod.LastMonth)
        {
            return DateTime.Today.AddMonths(-1).ToString("/yyyy/MM/");
        }
        else if (period == SyncPeriod.Today)
        {
            return DateTime.Today.ToString("/yyyy/MM/dd/");
        }
        else if (period == SyncPeriod.All)
        {
            return "/";
        }
        else
        {
            throw new Exception($"Unexpected SyncPeriod {period}");
        }
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
            var matchedCount = 0;
            foreach (IBlobItem item in result) //.Take(5)) //
            {
               var success = await SyncMovement(item);

               if (success == SyncStatus.Success)
               {
                   itemCount++;
               }
               else if (success == SyncStatus.SuccessAndMatched)
               {
                    itemCount++;
                    matchedCount++;
               }
               else
               {
                   erroredCount++;
               }
            }
            
            return new Status()
            {
                Success = true, Description = String.Format($"Connected. {itemCount} items upserted. {erroredCount} errors.  {matchedCount} items matched")
            };
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            
            return new Status() { Success = false, Description = ex.Message };
        }
    }

    internal async Task<SyncStatus> SyncMovement(IBlobItem item)
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
                    var auditEntry = AuditEntry.Create(existingMovement.ClearanceRequests.First(),
                        movement.ClearanceRequests.First(),
                        BuildNormalizedAlvsPath(item.Name),
                        movement.ClearanceRequests.First().Header.EntryVersionNumber.GetValueOrDefault(), 
                        movement.LastUpdated,
                        existingMovement.ClearanceRequests.First().Header.DeclarantName);

                    movement.AuditEntries.Add(auditEntry);
                    existingMovement.ClearanceRequests.RemoveAll(x =>
                        x.Header.EntryReference ==
                        movement.ClearanceRequests.First().Header.EntryReference);
                    existingMovement.ClearanceRequests.AddRange(movement.ClearanceRequests);
                    existingMovement.Items.RemoveAll(x =>
                        x.ClearanceRequestReference ==
                        movement.ClearanceRequests.First().Header.EntryReference);
                    existingMovement.Items.AddRange(movement.Items);

                    await movementService.Upsert(existingMovement);
                }
            }
            else
            {
                var auditEntry = AuditEntry.CreateCreatedEntry(
                    movement.ClearanceRequests.First(),
                    BuildNormalizedAlvsPath(item.Name),
                    movement.ClearanceRequests.First().Header.EntryVersionNumber.GetValueOrDefault(),
                    movement.LastUpdated,
                    movement.ClearanceRequests.First().Header.DeclarantName);
                movement.AuditEntries.Add(auditEntry);
                await movementService.Upsert(movement);
            }

            var document = movement.Items?.FirstOrDefault()?.Documents?.FirstOrDefault();
            if (document != null)
            {
                var matchResult = await matchingService.Match(MatchingReferenceNumber.FromCds(document?.DocumentReference, document?.DocumentCode));
                if (matchResult.Matched)
                {
                    return SyncStatus.SuccessAndMatched;
                }
            }

            return SyncStatus.Success;

        }
        catch (Exception ex)
        {
            Logger.LogError($"Failed to upsert movement from file {item.Name}. {ex.ToString()}.");

            return SyncStatus.Failed;
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
                Success = true, Description = $"Connected. {itemCount} items upserted. {erroredCount} errors."
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
                                    n.Version.GetValueOrDefault(),
                                    n.LastUpdated,
                                    n.LastUpdatedBy?.DisplayName);
                                n.AuditEntries.Add(auditEntry);
                            }
                            else
                            {
                                var auditEntry = AuditEntry.CreateSkippedVersion(
                                    n,
                                    BuildNormalizedIpaffsPath(item.Name),
                                    n.Version.GetValueOrDefault(),
                                    n.LastUpdated,
                                    n.LastUpdatedBy?.DisplayName);
                                n.AuditEntries.Add(auditEntry);
                            }
                            
                            await notificationService.Upsert(n);
                            itemCount++;
                        }
                    }
                    else
                    {
                        var auditEntry = AuditEntry.CreateCreatedEntry(
                            n,
                            BuildNormalizedIpaffsPath(item.Name),
                            n.Version.GetValueOrDefault(),
                            n.LastUpdated,
                            n.LastUpdatedBy?.DisplayName);
                        n.AuditEntries.Add(auditEntry);
                        await notificationService.Upsert(n);
                        itemCount++;
                    }

                    await matchingService.Match(MatchingReferenceNumber.FromIpaffs(n.ReferenceNumber, n.IpaffsType.Value));

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
        return fullPath.Replace("RAW/IPAFFS/", "");
    }

    private string BuildNormalizedAlvsPath(string fullPath)
    {
        return fullPath.Replace("RAW/ALVS/", "");
    }

}