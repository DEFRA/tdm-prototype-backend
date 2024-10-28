using TdmPrototypeBackend.Matching.Pipelines;

namespace TdmPrototypeBackend.Matching.Rules;

public class TestPipelineRule4 : TestPipelineBase
{
    public override async Task<MatchResult> ProcessMatch(MatchModel model)
    {
        model.Record += "Did rule four" + Environment.NewLine;
        
        return new MatchResult(false);
    }
}