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
    public int CorrelationID { get; set; } = default!;

    [Attr]
    public DateTime ServiceCallTimestamp { get; set; } = default!;
}