using MediatR;

namespace TdmPrototypeBackend.Matching.Pipelines;

public abstract class TestPipelineBase : IPipelineBehavior<MatchRequest, MatchResult>
{
    public abstract Task<MatchResult> ProcessMatch(MatchModel model);

    public async Task<MatchResult> Handle(
        MatchRequest request, 
        RequestHandlerDelegate<MatchResult> next,
        CancellationToken cancellationToken)
    {
        var currentProgress = await ProcessMatch(request.Model);
        
        if (currentProgress.Matched)
        {
            return currentProgress;
        }

        return await next();
    }
}