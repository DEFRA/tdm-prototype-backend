using MediatR;

namespace TdmPrototypeBackend.Api.Mediatr;

public abstract class TestPipelineTerminate : IPipelineBehavior<MatchRequest, MatchResponse>
{
    public async Task<MatchResponse> Handle(
        MatchRequest request, 
        RequestHandlerDelegate<MatchResponse> next,
        CancellationToken cancellationToken)
    {
        return await Task.FromResult(new MatchResponse());
    }
}