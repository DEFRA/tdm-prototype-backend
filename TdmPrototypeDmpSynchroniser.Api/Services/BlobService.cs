using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using TdmPrototypeDmpSynchroniser.Api.Config;
using TdmPrototypeDmpSynchroniser.Api.Models;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public class BlobService(ILoggerFactory loggerFactory, SynchroniserConfig config, IHttpClientFactory clientFactory)
    : AzureService(loggerFactory, config, clientFactory), IBlobService
{
    private BlobContainerClient CreateBlobClient(string serviceUri, int retries = 3, int timeout = 10)
    {
        var options = new BlobClientOptions
        {
            Transport = Transport!,
            Retry =
            {
                MaxRetries = retries,
                NetworkTimeout = TimeSpan.FromSeconds(timeout)
            },
            Diagnostics = 
            {
                IsLoggingContentEnabled = true,
                IsLoggingEnabled = true
            }
        };
        
        var blobServiceClient = new BlobServiceClient(
            new Uri(serviceUri),
            Credentials,
            options);

        var containerClient = blobServiceClient.GetBlobContainerClient(Config.DmpBlobContainer);
        
        return containerClient;
    }

    public async Task<Status> CheckBlobAsync()
    {
        return await CheckBlobAsync(Config.DmpBlobUri);
    }
    
    public async Task<Status> CheckBlobAsync(string serviceUri)
    {
        Logger.LogInformation("Connecting to blob storage {0} : {1}", serviceUri,
            Config.DmpBlobContainer);
        try
        {
            var containerClient = CreateBlobClient(serviceUri, 0, 5);
            
            Logger.LogInformation("Getting blob folders...");
            var folders = containerClient.GetBlobsByHierarchyAsync(prefix: "RAW/", delimiter: "/");

            var itemCount = 0;
            await foreach (BlobHierarchyItem blobItem in folders)
            {
                Logger.LogInformation("\t" + blobItem.Prefix);
                itemCount++;
            }

            return new Status()
            {
                Success = true, Description = String.Format("Connected. {0} blob folders found in RAW", itemCount)
            };
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            return new Status() { Success = false, Description = ex.Message };
        }

    }

    public async Task<IEnumerable<IBlobItem>> GetResourcesAsync(string prefix)
    {
        Logger.LogInformation("Connecting to blob storage {0} : {1}", Config.DmpBlobUri,
            Config.DmpBlobContainer);
        try
        {
            var containerClient = CreateBlobClient(Config.DmpBlobUri);

            Logger.LogInformation("Getting blob files from {0}...", prefix);
            // var itemCount = 0;
            
            var files = containerClient.GetBlobsAsync(prefix: prefix);
            var output = new List<IBlobItem>();
            
            await foreach (BlobItem item in files)
            {
                if (item.Properties.ContentLength is not 0)
                {
                    Logger.LogInformation("\t" + item.Name);
                    // itemCount++;
                    output.Add(new SynchroniserBlobItem() { Name = item.Name });    
                }
            }
            
            Logger.LogInformation($"GetResourcesAsync {output.Count} blobs found.");

            return output;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            throw;
        }

    }
    
    public async Task<IBlobItem?> GetBlobAsync(string path)
    {
        Logger.LogInformation(
            $"Downloading blob {path} from blob storage {Config.DmpBlobUri} : {Config.DmpBlobContainer}");
        try
        {
            var containerClient = CreateBlobClient(Config.DmpBlobUri);

            var blobClient = containerClient.GetBlobClient(path);

            var content = await blobClient.DownloadContentAsync();
            
            // content.Value.Content.
            return new SynchroniserBlobItem() { Name = path, Content = content.Value.Content.ToString()! };
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            throw;
        }

    }
}