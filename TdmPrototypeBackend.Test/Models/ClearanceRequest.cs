using System.Text.Json.Serialization;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TdmPrototypeBackend.Test.Models;

public class ClearanceRequestItem
{
    public string CustomsProcedureCode { get; set; } = default!;
    
    public string TaricCommodityCode { get; set; } = default!;
}

[Resource]
public class ClearanceRequest : HexStringMongoIdentifiable
{
    public string Type { get; set; } = "clearanceRequests";
    
    [Attr]
    public string SourceSystem { get; set; } = default!;

    [Attr]
    public string DestinationSystem { get; set; } = default!;
    
    [Attr]
    public int CorrelationId { get; set; } = default!;

    // public ClearanceRequestItem[] Items = [];

}