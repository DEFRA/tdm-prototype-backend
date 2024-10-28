using MediatR;
using TdmPrototypeBackend.Matching.Pipelines;

namespace TdmPrototypeBackend.Matching;

public record MatchRequest(MatchModel Model) : IRequest<MatchResult>;