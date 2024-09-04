using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace TdmPrototypeBackend.Types;

[Resource]
public class IpaffsNotification : FreeStringMongoIdentifiable
{
    // This field is used by the jsonapi-consumer to control the correct casing in the type field
    public string Type { get; set; } = "ipaffsNotifications";
    
    [Attr]
    public string ReferenceNumber { get; set; } = default!;

    [Attr]
    public int Version { get; set; } = default!;
    
}