using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using MongoDB.Bson.Serialization.Attributes;

using Microsoft.AspNetCore.Authorization;

namespace TdmPrototypeBackend.Types.Ipaffs;

public partial class Notification : IMongoIdentifiable
{

    //// This field is used by the jsonapi-consumer to control the correct casing in the type field
     [JsonIgnore]
    public string Type { get; set; } = "notifications";

    //[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [JsonIgnore]
    public virtual string? Id
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
    public string? StringId
    {
        get => Id;
        set => Id = value;
    }
    
    /// <inheritdoc />
    [BsonIgnore]
    [JsonIgnore]
    [NotMapped]
    // [Attr]
    public string? LocalId { get; set; }
    
    [Attr]
    public MatchingStatus Movement { get; set; } = new MatchingStatus() { Matched = false };

    [Attr]
    public List<AuditEntry> AuditEntries { get; set; } = new List<AuditEntry>();
    
    // Filter fields...
    // These fields are added to the model solely for use by the filtering
    // Mechanism in JSON API as a short term solution until we implement the more complex nested filtering
    // https://github.com/json-api-dotnet/JsonApiDotNetCore.MongoDb/issues/76
    // They are removed from the document that is sent to the client by the JsonApiResourceDefinition OnApplySparseFieldSet
    // mechanism
    
    [Attr]
    public string _PointOfEntry
    {
        get => PartOne.PointOfEntry;
        set
        {
            if (PartOne != null)
            {
                PartOne.PointOfEntry = value;
            }
        }
    }

    [Attr]
    public string _PointOfEntryControlPoint
    {
        get => PartOne.PointOfEntryControlPoint;
        set
        {
            if (PartOne != null)
            {
                PartOne.PointOfEntryControlPoint = value;
            }
        }
    }
}