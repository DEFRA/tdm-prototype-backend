using TdmPrototypeBackend.Matching.Pipelines;

namespace TdmPrototypeBackend.Matching.Rules;

public class TestPipelineRule3 : TestPipelineBase
{
    public override async Task<MatchResult> ProcessMatch(MatchModel model)
    {
        model.Record += "Did rule three" + Environment.NewLine;
        
        return new MatchResult(false);
    }
}