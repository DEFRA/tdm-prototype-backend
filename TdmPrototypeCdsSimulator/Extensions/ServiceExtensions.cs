using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TdmPrototypeCdsSimulator.Config;
using TdmPrototypeCdsSimulator.Endpoints;

namespace TdmPrototypeCdsSimulator.Extensions;

public static class ServiceExtensions
{
    public static void AddCdsSimulator(this IServiceCollection services)
    {
        services.AddSingleton<CdsSimulatorConfig>();
    }

    public static void UseCdsSimulator(this WebApplication app)
    {
        app.UseCdsSimulatorEndpoints();
    }
}