using MediatR;

namespace TdmPrototypeBackend.Api.Mediatr;

public class TestPipelineRule1 : TestPipelineBase
{
    public override async Task<MatchResponse> ProcessMatch(MatchRequest request)
    {
        request.Record += "Did rule one" + Environment.NewLine;
        
        return new MatchResponse();
    }
}