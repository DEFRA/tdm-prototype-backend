namespace TdmPrototypeBackend.Matching;

public class MatchResult(bool matched)
{
    public bool Matched {get; } = matched;
}