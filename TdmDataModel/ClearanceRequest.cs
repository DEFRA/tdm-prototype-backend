using System.Text.Json.Serialization;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TdmDataModel;

public class ClearanceRequestItem
{
    public string CustomsProcedureCode { get; set; } = default!;
    
    public string TaricCommodityCode { get; set; } = default!;
}

[Resource]
public class ClearanceRequest : HexStringMongoIdentifiable
{
    public string SourceSystem { get; set; } = default!;

    public string DestinationSystem { get; set; } = default!;
    
    public int CorrelationId { get; set; }

    // public ClearanceRequestItem[] Items = [];

}