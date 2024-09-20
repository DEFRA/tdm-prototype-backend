using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Security.Cryptography;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Json.Patch;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace TdmPrototypeBackend.Types.Ipaffs;

// TODO : Can we generate this from the schema file 
// https://eaflood.atlassian.net/wiki/spaces/TRADE/pages/5104664583/PHA+Port+Health+Authority+Integration+Data+Schema



public class VersionHistory
{
    public string Id { get; set; }
    public int Version { get; set; }

    public string LastUpdatedBy { get; set; }

    public string DateTime { get; set; }

    public string Diff { get; set; }


}

public partial class IpaffsNotification : IMongoIdentifiable
{

    //// This field is used by the jsonapi-consumer to control the correct casing in the type field
    public string Type { get; set; } = "ipaffsNotifications";

    //[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
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

    public List<VersionHistory> VersionHistories { get; set; } = new List<VersionHistory>();
   
}

/// <summary>
/// Added manual class to include message, which isn't part of the schema, but a lot of data includes it
/// </summary>
public partial class IpaffsValidationMessageCode  //
{


    /// <summary>
    /// Field
    /// </summary>
    [Attr]
    [JsonPropertyName("message")]
    public string? Message { get; set; }

}