using MediatR;

namespace TdmPrototypeBackend.Api.Mediatr;

public abstract class TestPipelineBase : IPipelineBehavior<MatchRequest, MatchResponse>
{
    public abstract Task<MatchResponse> ProcessMatch(MatchRequest request);

    public async Task<MatchResponse> Handle(
        MatchRequest request, 
        RequestHandlerDelegate<MatchResponse> next,
        CancellationToken cancellationToken)
    {
        var currentProgress = await ProcessMatch(request);
        
        if (currentProgress.CompleteMatch)
        {
            return currentProgress;
        }

        return await next();
    }
}

public class MatchRequest : IRequest<MatchResponse>
{
    public string InitialRequest { get; set; } = String.Empty;
    public string Record { get; set; } = String.Empty;
}

public class MatchResponse
{
    public bool CompleteMatch { get; set; } = false;
}