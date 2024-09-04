using Newtonsoft.Json;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using MongoDB.Bson.Serialization.Attributes;
// using JsonApiSerializer.JsonApi;

namespace TdmPrototypeBackend.Types;
// namespace TdmPrototypeBackend.Models;

// Recreation of ClearanceRequest schema from
// https://eaflood.atlassian.net/wiki/spaces/TRADE/pages/5104664583/PHA+Port+Health+Authority+Integration+Data+Schema

public class ClearanceRequestItem
{
    public string CustomsProcedureCode { get; set; } = default!;
    
    public string TaricCommodityCode { get; set; } = default!;
}

[Resource]
public class ClearanceRequest : CustomStringMongoIdentifiable
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
    // [BsonIgnore]
    // [JsonIgnore]
    // // [Attr]
    // // [NoResourceAttribute]
    // public new string? StringId2
    // {
    //     get => "AAA";
    //     set => Id = value;
    // }
    
    // // Trying to remove this from the serialised message
    // [BsonIgnore]
    // [JsonIgnore]
    // // [NoResourceAttribute]
    // public new string? StringId
    // {
    //     get => "AAA";
    //     set => Id = value;
    // }

}