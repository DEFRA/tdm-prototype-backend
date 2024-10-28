using MediatR;
using MediatR.Pipeline;

namespace TdmPrototypeBackend.Matching.Pipelines;

public class TestPipelineRulePre : IRequestPreProcessor<MatchRequest>
{
    public async Task Process(MatchRequest request, CancellationToken cancellationToken)
    {
        request.Model.Record += $"Did pre-processing with initial request [{request.Model.MatchReference}]{Environment.NewLine}";
    }
}