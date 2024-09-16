using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace TdmPrototypeBackend.Types.Ipaffs;

// TODO : Can we generate this from the schema file 
// https://eaflood.atlassian.net/wiki/spaces/TRADE/pages/5104664583/PHA+Port+Health+Authority+Integration+Data+Schema

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
   
}