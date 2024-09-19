using Newtonsoft.Json;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using MongoDB.Bson.Serialization.Attributes;
using TdmPrototypeBackend.Types.Alvs;
// using JsonApiSerializer.JsonApi;

namespace TdmPrototypeBackend.Types;
// namespace TdmPrototypeBackend.Models;

// Recreation of ClearanceRequest schema from
// https://eaflood.atlassian.net/wiki/spaces/TRADE/pages/5104664583/PHA+Port+Health+Authority+Integration+Data+Schema

//public class MovementItem
//{
//    [Attr]
//    public int ItemNumber { get; set; } = default!;
    
//    [Attr]
//    public string CustomsProcedureCode { get; set; } = default!;
    
//    [Attr]
//    public string TaricCommodityCode { get; set; } = default!;
    
//    [Attr]
//    public string GoodsDescription { get; set; } = default!;
    
//    // TODO : Unclear yet whether items in a clearance request can be  
//    // split across GMRs
//    [Attr]
//    public MatchingStatus Gmr { get; set; } = default!;
//}

[Resource]
public class Movement : CustomStringMongoIdentifiable
{

    // This field is used by the jsonapi-consumer to control the correct casing in the type field
    public string Type { get; set; } = "movements";
    
    [Attr]
    public MatchingStatus IpaffsNotification { get; set; } = new MatchingStatus() { Matched = false };
    
    [Attr]
    public Alvs.ALVSClearanceRequest[] ClearanceRequests { get; set; } = default!;
    
    [Attr]
    public Items[] Items { get; set; } = default!;

    [Attr]
    public DateTime? LastUpdateDateTime { get; set; }

}