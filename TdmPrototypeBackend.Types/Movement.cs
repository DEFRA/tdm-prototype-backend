using Newtonsoft.Json;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Bson.Serialization.Attributes;
using TdmPrototypeBackend.Types.Alvs;
// using JsonApiSerializer.JsonApi;

namespace TdmPrototypeBackend.Types;
// namespace TdmPrototypeBackend.Models;

// Recreation of ClearanceRequest schema from
// https://eaflood.atlassian.net/wiki/spaces/TRADE/pages/5104664583/PHA+Port+Health+Authority+Integration+Data+Schema


public partial class Item
{
    //    [Attr]
//    public int ItemNumber { get; set; } = default!;
    
//    [Attr]
//    public string CustomsProcedureCode { get; set; } = default!;
    
//    [Attr]
//    public string TaricCommodityCode { get; set; } = default!;
    
//    [Attr]
//    public string GoodsDescription { get; set; } = default!;
    
    // TODO : Unclear yet whether items in a clearance request can be  
    // split across GMRs
    [Attr]
    public MatchingStatus Gmr { get; set; } = new MatchingStatus() { Matched = false }!;
}


[Resource]
public class Movement : CustomStringMongoIdentifiable
{
    private List<int> matchReferences;

    // This field is used by the jsonapi-consumer to control the correct casing in the type field
    public string Type { get; set; } = "movements";
    
    [Attr]
    public List<MatchingStatus> Notifications { get; set; } = [new() { Matched = false }];

    [Attr]
    public List<Alvs.ALVSClearanceRequest> ClearanceRequests { get; set; } = default!;
    
    [Attr]
    public List<Items> Items { get; set; } = default!;

    /// <summary>
    /// Date when the notification was last updated.
    /// </summary>
    [Attr]
    public  DateTime? LastUpdated { get; set; }

    [Attr]
    public string EntryReference { get; set; }
    
    [Attr]
    public string MasterUCR { get; set; }
    
    [Attr]
    public int? DeclarationPartNumber { get; set; }
    
    [Attr]
    public string DeclarationType { get; set; }
    
    [Attr]
    public DateTime? ArrivalDateTime { get; set; }
    
    [Attr]
    public string SubmitterTURN { get; set; }
    
    [Attr]
    public string DeclarantId { get; set; }
    
    [Attr]
    public string DeclarantName { get; set; }
    
    [Attr]
    public string DispatchCountryCode { get; set; }
    
    [Attr]
    public string GoodsLocationCode { get; set; }

    [Attr]
    public List<AuditEntry> AuditEntries { get; set; } = new List<AuditEntry>();

    public List<int> _MatchReferences
    {
        get
        {
            var list = new HashSet<int>();
            foreach (var item in Items)
            {
                if (item.Documents != null)
                {
                    foreach (var itemDocument in item.Documents)
                    {
                        list.Add(MatchingReferenceNumber
                            .FromCds(itemDocument.DocumentReference, itemDocument.DocumentCode).Identifier);
                    }
                }
            }

            return list.ToList();
        }
        set => matchReferences = value;
    }

    public void AddMatchingStatus(MatchingStatus matchingStatus)
    {
        if (!Notifications.Exists(x => x.Reference == matchingStatus.Reference))
        {
            Notifications.Add(matchingStatus);
        }
    }
}