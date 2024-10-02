using Microsoft.Extensions.DependencyInjection;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeBackend.Types;

namespace TdmPrototypeBackend.Matching.Extensions;

public static class ServiceExtensions
{
    public static void AddMatchingService(this IServiceCollection services)
    {
        services.AddSingleton<MatchingStorageService<Movement>>();
        services.AddSingleton<MatchingStorageService<Notification>>();
        services.AddSingleton<IMatchingService, MatchingService>();
    }
}