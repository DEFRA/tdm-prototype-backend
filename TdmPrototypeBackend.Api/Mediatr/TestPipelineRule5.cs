using MediatR;

namespace TdmPrototypeBackend.Api.Mediatr;

public class TestPipelineRule5 : TestPipelineBase
{
    public override async Task<MatchResponse> ProcessMatch(MatchRequest request)
    {
        request.Record += "Did rule five" + Environment.NewLine;
        
        return new MatchResponse();
    }
}