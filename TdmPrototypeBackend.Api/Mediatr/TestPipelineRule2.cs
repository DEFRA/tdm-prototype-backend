using MediatR;

namespace TdmPrototypeBackend.Api.Mediatr;

public class TestPipelineRule2 : TestPipelineBase
{
    public override async Task<MatchResponse> ProcessMatch(MatchRequest request)
    {
        request.Record += "Did rule two" + Environment.NewLine;
        
        return new MatchResponse();
    }
}