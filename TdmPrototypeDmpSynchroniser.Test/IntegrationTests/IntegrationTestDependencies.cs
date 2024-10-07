using JsonApiDotNetCore.MongoDb.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace TdmPrototypeDmpSynchroniser.Test.IntegrationTests;

public class IntegrationTestDependencies(IServiceProvider serviceProvider)
{
    public IServiceProvider ServiceProvider { get; } = serviceProvider;

    public Task MongoClearCollection<T>() where T : class, IMongoIdentifiable
    {
        return ServiceProvider.GetService<MongoHelperService<T>>().ClearCollection();
    }
}