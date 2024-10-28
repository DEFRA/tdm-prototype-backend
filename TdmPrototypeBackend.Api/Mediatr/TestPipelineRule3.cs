using MediatR;

namespace TdmPrototypeBackend.Api.Mediatr;

public class TestPipelineRule3 : TestPipelineBase
{
    public override async Task<MatchResponse> ProcessMatch(MatchRequest request)
    {
        request.Record += "Did rule three" + Environment.NewLine;
        
        return new MatchResponse();
    }
}