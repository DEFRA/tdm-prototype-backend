using JsonApiConsumer;
using TdmPrototypeBackend.Types;
using TdmPrototypeDmpSynchroniser.Api.Config;

namespace TdmPrototypeDmpSynchroniser.Api.Services;

public class JsonApiStorageService<T>: BaseService, IStorageService<T> where T : class, new()
{
    public JsonApiStorageService(ILoggerFactory loggerFactory, SynchroniserConfig config) : base(loggerFactory, config)
    {
        Extensions.AssertIsNotNull(config.TdmBackendApiUri);
        Logger.LogInformation("Connecting to JSON API {0}", config.TdmBackendApiUri);
    }
    public async Task Upsert(T item)
    {
        try
        {
            
            Response<T> response = JsonApiConsumer.JsonApiConsumer.Create<T, T>(
                model: item,
                baseURI: Config.TdmBackendApiUri,
                path: "api/movements"
            );
            
            Logger.LogInformation($"HTTP Response {response.HttpStatusCode}");
            if (response.DocumentRoot != null)
            {
                Logger.LogInformation(response.DocumentRoot.ToString());    
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            throw;
        }

    }
}