using MediatR;

namespace TdmPrototypeBackend.Api.Mediatr;

public class TestPipelineRule4 : TestPipelineBase
{
    public override async Task<MatchResponse> ProcessMatch(MatchRequest request)
    {
        request.Record += "Did rule four" + Environment.NewLine;
        
        return new MatchResponse();
    }
}