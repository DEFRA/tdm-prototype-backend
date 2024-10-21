using JsonApiDotNetCore.Serialization.Objects;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeBackend.Types.VehicleMovement;

namespace TdmPrototypeBackend.Api.Swagger;

public class ResourceData<T>
{
    public string Type { get; set; }
    public string Id { get; set; }
    public T Attributes { get; set; }

   
}

public class NotificationResourceData : ResourceData<Notification>
{
    public NotificationJsonApiTdmRelationships Relationships { get; set; }
}

public class MovementResourceData : ResourceData<Notification>
{
    public MovementJsonApiTdmRelationships Relationships { get; set; }
}

public class GmrResourceData : ResourceData<Gmr>
{
}
