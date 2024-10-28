using TdmPrototypeBackend.Matching.Pipelines;

namespace TdmPrototypeBackend.Matching.Rules;

public class TestPipelineRule1 : TestPipelineBase
{
    public override async Task<MatchResult> ProcessMatch(MatchModel model)
    {
        model.Record += "Did rule one" + Environment.NewLine;
        
        return new MatchResult(false);
    }
}