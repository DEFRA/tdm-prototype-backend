using System.Collections.Immutable;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Errors;
using JsonApiDotNetCore.Middleware;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Queries;
using JsonApiDotNetCore.Queries.Expressions;
using JsonApiDotNetCore.QueryStrings;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using JsonApiDotNetCore.Serialization.Objects;
using JsonApiDotNetCore.Serialization.Response;
using MongoDB.Bson.Serialization.Attributes;
using TdmPrototypeBackend.Types.Extensions;

namespace TdmPrototypeBackend.Types.Ipaffs;


public partial class Notification : IMongoIdentifiable
{
    private int? matchReference;

    //// This field is used by the jsonapi-consumer to control the correct casing in the type field
     [JsonIgnore]
    public string Type { get; set; } = "notifications";

    //[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [JsonIgnore]
    public virtual string Id
    {
        get => ReferenceNumber;
        set => ReferenceNumber = value;
    }

    // TODO : this is currently being written on the wire by the json api client
    /// <inheritdoc />
    [BsonIgnore]
    [JsonIgnore]
    // [NotMapped]
    [Attr]
    public string StringId
    {
        get => Id;
        set => Id = value;
    }
    
    /// <inheritdoc />
    [BsonIgnore]
    [JsonIgnore]
    [NotMapped]
    // [Attr]
    public string LocalId { get; set; }
    
    [Attr]
    public List<AuditEntry> AuditEntries { get; set; } = new List<AuditEntry>();
    
    [Attr]
    public NotificationTdmRelationships Relationships { get; set; } = new NotificationTdmRelationships();

    [Attr]
    public IpaffsCommodities Commodities { get; set; }

    [Attr]
    public IpaffsCommodityComplement[] CommoditiesSummary { get; set; }

    // Filter fields...
    // These fields are added to the model solely for use by the filtering
    // Mechanism in JSON API as a short term solution until we implement the more complex nested filtering
    // https://github.com/json-api-dotnet/JsonApiDotNetCore.MongoDb/issues/76
    // They are removed from the document that is sent to the client by the JsonApiResourceDefinition OnApplySparseFieldSet
    // mechanism

    /// <summary>
    /// Tracks the last time the record was changed
    /// </summary>
    [Attr]
    [BsonElement("_ts")]
    public DateTime _Ts { get; set; }

    [Attr]
    [BsonElement("_pointOfEntry")]
    public string _PointOfEntry
    {
        get => PartOne?.PointOfEntry;
        set
        {
            if (PartOne != null)
            {
                PartOne.PointOfEntry = value;
            }
        }
    }

    [Attr]
    [BsonElement("_pointOfEntryControlPoint")]
    public string _PointOfEntryControlPoint
    {
        get => PartOne?.PointOfEntryControlPoint;
        set
        {
            if (PartOne != null)
            {
                PartOne.PointOfEntryControlPoint = value;
            }
        }
    }

    [BsonElement("_matchReferences")]
    public int _MatchReference
    {
        get
        {
            if (matchReference is null)
            {
                matchReference = MatchingReferenceNumber.FromIpaffs(ReferenceNumber, IpaffsType.Value).Identifier;
            }
            return matchReference.Value;
        }
        set => matchReference = value;
    }

    public void AddRelationship(string type, TdmRelationshipObject relationship)
    {
        Relationships.Movements.Links ??= relationship.Links;
        foreach (var dataItem in relationship.Data)
        {
            if (Relationships.Movements.Data.All(x => x.Id != dataItem.Id))
            {
                Relationships.Movements.Data.Add(dataItem);
            }
        }

        Relationships.Movements.Matched = Relationships.Movements.Data.Any(x => x.Matched);
    }

    public void Update(AuditEntry auditEntry)
    {
        this.AuditEntries.Add(auditEntry);
        _Ts = DateTime.UtcNow;
    }
}