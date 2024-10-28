using MediatR;
using MediatR.Pipeline;

namespace TdmPrototypeBackend.Api.Mediatr;

public class TestPipelineRulePost : IRequestPostProcessor<MatchRequest, MatchResponse>
{
    public async Task Process(MatchRequest request, MatchResponse response, CancellationToken cancellationToken)
    {
        request.Record += "Did Post Processing" + Environment.NewLine;
    }
}