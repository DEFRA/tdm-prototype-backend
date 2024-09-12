using JsonApiDotNetCore.Resources.Annotations;

namespace TdmPrototypeBackend.Types;

[Resource]
public class AlvsServiceHeader
{   
    [Attr]
    public string SourceSystem { get; set; } = default!;
    
    [Attr]
    public string DestinationSystem { get; set; } = default!;
    
    [Attr]
    public ulong CorrelationID { get; set; } = default!;

    // TODO : Should be datetime...
    [Attr]
    public DateTime ServiceCallTimestamp { get; set; } = default!;
    
}