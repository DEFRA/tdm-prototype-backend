using TdmPrototypeBackend.Matching.Pipelines;

namespace TdmPrototypeBackend.Matching.Rules;

public class TestPipelineRule5 : TestPipelineBase
{
    public override async Task<MatchResult> ProcessMatch(MatchModel model)
    {
        model.Record += "Did rule five" + Environment.NewLine;
        
        return new MatchResult(false);
    }
}