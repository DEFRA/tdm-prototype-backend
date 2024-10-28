using MediatR;
using MediatR.Pipeline;
using TdmPrototypeBackend.Matching;

namespace TdmPrototypeBackend.Matching.Pipelines;

public class TestPipelineRulePost : IRequestPostProcessor<MatchRequest, MatchResult>
{
    public async Task Process(MatchRequest request, MatchResult response, CancellationToken cancellationToken)
    {
        request.Model.Record += "Did Post Processing" + Environment.NewLine;
    }
}