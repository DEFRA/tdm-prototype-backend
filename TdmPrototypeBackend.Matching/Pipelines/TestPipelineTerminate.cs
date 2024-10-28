using MediatR;

namespace TdmPrototypeBackend.Matching.Pipelines;

public class TestPipelineTerminate : IPipelineBehavior<MatchRequest, MatchResult>
{
    public async Task<MatchResult> Handle(
        MatchRequest request, 
        RequestHandlerDelegate<MatchResult> next,
        CancellationToken cancellationToken)
    {
        return await Task.FromResult(new MatchResult(false));
    }
}