using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace TdmPrototypeBackend.Types;

[Resource]
public class IpaffsNotification : HexStringMongoIdentifiable
{
    // This field is used by the jsonapi-consumer to 
    public string Type { get; set; } = "ipaffsNotifications";
    
    [Attr]
    public int IpaffsID { get; set; } = default!;
    
    [Attr]
    public string ReferenceNumber { get; set; } = default!;

    [Attr]
    public int Version { get; set; } = default!;
    
}