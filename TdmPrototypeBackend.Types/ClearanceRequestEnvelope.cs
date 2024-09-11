using System.Text.Json.Serialization;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Converters;

// using JsonApiSerializer.JsonApi;

namespace TdmPrototypeBackend.Types;
// namespace TdmPrototypeBackend.Models;

// Recreation of ClearanceRequest schema from
// https://eaflood.atlassian.net/wiki/spaces/TRADE/pages/5104664583/PHA+Port+Health+Authority+Integration+Data+Schema

public class ClearanceRequest
{
    [Attr]
    public string EntryReference { get; set; } = default!;
    
    [Attr]
    public int EntryVersionNumber { get; set; } = default!;
    
    [Attr]
    public int PreviousVersionNumber { get; set; } = default!;
    
    [Attr]
    [JsonPropertyName("DeclarationUCR")]
    public string DeclarationUcr{ get; set; } = default!;
    
    [Attr]
    public string DeclarationPartNumber { get; set; } = default!;
    
    [Attr]
    public string DeclarationType { get; set; } = default!;
    
    [Attr]
    [Newtonsoft.Json.JsonConverter(typeof(IsoDateTimeConverter))]
    public DateTime ArrivalDateTime { get; set; } = default!;
    
    [Attr]
    [JsonPropertyName("SubmitterTURN")]
    public string SubmitterTurn { get; set; } = default!;
    
    [Attr]
    public string DeclarantId { get; set; } = default!;
    
    [Attr]
    public string DeclarantName { get; set; } = default!;
    
    [Attr]
    public string DispatchCountryCode { get; set; } = default!;
    
    [Attr]
    public string GoodsLocationCode { get; set; } = default!;
    
    [Attr]
    [JsonPropertyName("MasterUCR")]
    public string MasterUcr { get; set; } = default!;
    
    [Attr]
    public MovementItem[] Items { get; set; } = default!;
}

// [Resource]
public class ClearanceRequestEnvelope
{

    // This field is used by the jsonapi-consumer to control the correct casing in the type field
    // public string Type { get; set; } = "clearanceRequests";
    //
    // [Attr]
    // public MatchingStatus IpaffsNotification { get; set; } = new MatchingStatus() { Matched = false };
    
    [Attr]
    public AlvsServiceHeader ServiceHeader { get; set; } = default!;
    
    [Attr]
    public ClearanceRequest Header { get; set; } = default!;

    [Attr]
    public MovementItem[] Items { get; set; } = default!;
}