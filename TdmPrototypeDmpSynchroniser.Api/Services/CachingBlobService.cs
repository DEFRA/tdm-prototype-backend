using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public class CachingBlobService(ILoggerFactory loggerFactory, SynchroniserConfig config, [FromKeyedServices("base")] IBlobService blobService)
    : BaseService(loggerFactory, config), IBlobService
{
    
    public async Task<Status> CheckBlobAsync()
    {
        return await blobService.CheckBlobAsync();
    }
    
    public async Task<Status> CheckBlobAsync(string uri)
    {
        return await blobService.CheckBlobAsync(uri);
    }

    private async void ScanFolder(List<IBlobItem> items, string path)
    {
        try 
        {
            foreach (string f in Directory.GetFiles(path)) 
            {
                items.Add(new SynchroniserBlobItem() { Name = f });
            }

            foreach (string d in Directory.GetDirectories(path)) 
            {
                ScanFolder(items, d);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Scan Folder Exception Thrown {ex}");
        }
    }
    public async Task<IEnumerable<IBlobItem>> GetResourcesAsync(string prefix)
    {
        if (config.CachingReadEnabled)
        {
            Logger.LogInformation("CachingBlobService scanning disk");
            var items = new List<IBlobItem>();
            ScanFolder(items, $"{System.Environment.CurrentDirectory}/.synchroniser-cache");
            return items;
        }
        else
        {
            return await blobService.GetResourcesAsync(prefix);
        }
    }
    
    public async Task<IBlobItem?> GetBlobAsync(string path)
    {
        if (config.CachingReadEnabled)
        {
            Logger.LogInformation($"CachingBlobService reading blob {path} from disk");
            return new SynchroniserBlobItem() { Name = path, Content = File.ReadAllText(path) };
        }
        else
        {
            var blob = await blobService.GetBlobAsync(path);
            
            if (blob != null && config.CachingStoreEnabled)
            {
                var fullPath = $"{System.Environment.CurrentDirectory}/.synchroniser-cache/{blob.Name}";
                
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                File.WriteAllText(fullPath, blob.Content);
            }


            return blob;    
        }
    }
}