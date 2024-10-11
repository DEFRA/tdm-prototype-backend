using Newtonsoft.Json;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Bson.Serialization.Attributes;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.Extensions;

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
    
    //[Attr]
    //public List<MatchingStatus> Notifications { get; set; } = [new() { Matched = false }];

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

    [Attr]
    public Dictionary<string, TdmRelationshipObject> Relationships { get; set; } =
        new() { { "notifications", TdmRelationshipObject.CreateDefault() } };

    /// <summary>
    /// Tracks the last time the record was changed
    /// </summary>
    [Attr]
    [BsonElement("_ts")]
    public DateTime _Ts { get; set; }

    [BsonElement("_matchReferences")]
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

    public void AddRelationship(string type, TdmRelationshipObject relationship)
    {
        if (Relationships.TryGetValue(type, out var value))
        {
            value.Links ??= relationship.Links;
            foreach (var dataItem in relationship.Data)
            {
                if (value.Data.All(x => x.Id != dataItem.Id))
                {
                    value.Data.Add(dataItem);
                }
            }

            value.Matched = Items
                .Select(x => x.ItemNumber)
                .All(itemNumber => value.Data.Any(x => x.Matched && x.SourceItem == itemNumber));
        {
            Relationships.Add(type, relationship);
        }
    }

    public void Update(AuditEntry auditEntry)
    {
        this.AuditEntries.Add(auditEntry);
        _Ts = DateTime.UtcNow;
    }

    public bool MergeDecision(string path, ALVSClearanceRequest clearanceRequest)
    {
        var before = this.ToJsonString();
        foreach (var item in clearanceRequest.Items)
        {
            var existingItem = this.Items.FirstOrDefault(x => x.ItemNumber == item.ItemNumber);

            if (existingItem is not null)
            {
                existingItem.MergeChecks(item);
            }
        }

        var after = this.ToJsonString();

        var auditEntry = AuditEntry.CreateDecision(before, after,
            BuildNormalizedDecisionPath(path),
            clearanceRequest.Header.EntryVersionNumber.GetValueOrDefault(),
            clearanceRequest.ServiceHeader.ServiceCallTimestamp,
            clearanceRequest.Header.DeclarantName);
        if (auditEntry.Diff.Any())
        {
            this.Update(auditEntry);
        }

        return auditEntry.Diff.Any();
    }

    private string BuildNormalizedDecisionPath(string fullPath)
    {
        return fullPath.Replace("RAW/DECISION/", "");
    }
}