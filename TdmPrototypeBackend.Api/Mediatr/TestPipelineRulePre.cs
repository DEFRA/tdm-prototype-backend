using MediatR;
using MediatR.Pipeline;

namespace TdmPrototypeBackend.Api.Mediatr;

public class TestPipelineRulePre : IRequestPreProcessor<MatchRequest>
{
    public async Task Process(MatchRequest request, CancellationToken cancellationToken)
    {
        request.Record += $"Did pre-processing with initial request [{request.InitialRequest}]{Environment.NewLine}";
    }
}