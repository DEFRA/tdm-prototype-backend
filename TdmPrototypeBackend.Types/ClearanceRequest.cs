using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace TdmPrototypeBackend.Types;
// namespace TdmPrototypeBackend.Models;

public class ClearanceRequestItem
{
    public string CustomsProcedureCode { get; set; } = default!;
    
    public string TaricCommodityCode { get; set; } = default!;
}

[Resource]
public class ClearanceRequest : HexStringMongoIdentifiable
{
    // This field is used by the jsonapi-consumer to 
    public string Type { get; set; } = "clearanceRequests";
    
    [Attr]
    public string SourceSystem { get; set; } = default!;

    [Attr]
    public string DestinationSystem { get; set; } = default!;
    
    [Attr]
    public int CorrelationId { get; set; } = default!;

    // public ClearanceRequestItem[] Items = [];

}