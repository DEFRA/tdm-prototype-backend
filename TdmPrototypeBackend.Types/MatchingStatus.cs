using JsonApiDotNetCore.Resources.Annotations;

namespace TdmPrototypeBackend.Types;

public class MatchingStatus
{
    [Attr]
    public bool Matched { get; set; } = default!;
    
    [Attr]
    public string Reference { get; set; } = default!;
    
    [Attr]
    public int Item { get; set; } = default!;
    
    [Attr]
    public KeyValuePair<string,string>? AdditionalInformation { get; set; }
}