using MediatR;
using TdmPrototypeBackend.Matching.Pipelines;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeBackend.Matching;

public class MatchModel
{
    public List<Notification> Notifications { get; set; } = new ();
    public List<Movement> Movements { get; set; } = new ();
    public string MatchReference { get; set; } = string.Empty;

    // Debugging
    public string Record { get; set; } = string.Empty;
}