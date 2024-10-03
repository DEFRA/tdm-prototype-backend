using TdmPrototypeBackend.Types;

namespace TdmPrototypeBackend.Matching;

public interface IMatchingService
{
    public Task<MatchResult> Match(MatchingReferenceNumber matchingReferenceNumber);


}