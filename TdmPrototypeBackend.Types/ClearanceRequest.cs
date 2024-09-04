using Newtonsoft.Json;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using MongoDB.Bson.Serialization.Attributes;

namespace TdmPrototypeBackend.Types;
// namespace TdmPrototypeBackend.Models;

public class ClearanceRequestItem
{
    public string CustomsProcedureCode { get; set; } = default!;
    
    public string TaricCommodityCode { get; set; } = default!;
}

[Resource]
public class ClearanceRequest : FreeStringMongoIdentifiable
{
    // This field is used by the jsonapi-consumer to control the correct casing in the type field
    public string Type { get; set; } = "clearanceRequests";
    
    [Attr]
    public string SourceSystem { get; set; } = default!;

    [Attr]
    public string DestinationSystem { get; set; } = default!;
    
    [Attr]
    public int CorrelationID { get; set; } = default!;

    // public ClearanceRequestItem[] Items = [];
    
    // // Trying to remove this from the serialised message
    // [BsonIgnore]
    // [JsonIgnore]
    // // [NoResourceAttribute]
    // public string? StringId
    // {
    //     get => Id;
    //     set => Id = value;
    // }

}