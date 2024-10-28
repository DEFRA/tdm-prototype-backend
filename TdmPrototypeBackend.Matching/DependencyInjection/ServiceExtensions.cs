using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TdmPrototypeBackend.Matching.Pipelines;
using TdmPrototypeBackend.Matching.Rules;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeBackend.Matching.DependencyInjection;

public static class ServiceExtensions
{
    public static void AddMatchingService(this IServiceCollection services)
    {
        services.AddSingleton<MatchingStorageService<Movement>>();
        services.AddSingleton<MatchingStorageService<Notification>>();
        services.AddSingleton<IMatchingService, MatchingService>();
        
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(MatchRequest).Assembly);
            cfg.AddRequestPreProcessor<TestPipelineRulePre>();
            cfg.AddRequestPostProcessor<TestPipelineRulePost>();

            cfg.AddBehavior<IPipelineBehavior<MatchRequest, MatchResult>, TestPipelineRule5>();
            cfg.AddBehavior<IPipelineBehavior<MatchRequest, MatchResult>, TestPipelineRule4>();
            cfg.AddBehavior<IPipelineBehavior<MatchRequest, MatchResult>, TestPipelineRule3>();
            cfg.AddBehavior<IPipelineBehavior<MatchRequest, MatchResult>, TestPipelineRule2>();
            cfg.AddBehavior<IPipelineBehavior<MatchRequest, MatchResult>, TestPipelineRule1>();

            cfg.AddBehavior<IPipelineBehavior<MatchRequest, MatchResult>, TestPipelineTerminate>();
        });
    }
}