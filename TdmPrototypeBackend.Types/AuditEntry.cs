using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Json.Patch;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using TdmPrototypeBackend.Types.Extensions;

namespace TdmPrototypeBackend.Types;

// TODO : Can we generate this from the schema file 
// https://eaflood.atlassian.net/wiki/spaces/TRADE/pages/5104664583/PHA+Port+Health+Authority+Integration+Data+Schema

public class AuditEntry
{
    private BsonArray _bsonDiff;
    public string Id { get; set; }
    public int Version { get; set; }

    public string LastUpdatedBy { get; set; }

    public string DateTime { get; set; }

    [BsonIgnore]
    public JsonPatch Diff { get; set; }

    [JsonIgnore]
    [BsonElement("diff")]
    public BsonArray BsonDiff
    {
        get => _bsonDiff;
        set
        {
            _bsonDiff = value;
            Diff ??= JsonSerializer.Deserialize<JsonPatch>(BsonDiff.ToJson());
        }
    }


    public static AuditEntry Create<T>(T previous, T current, string id, int version, string lastUpdated, string lastUpdatedBy)
    {
        var node1 = JsonNode.Parse(previous.ToJsonString());
        var node2 = JsonNode.Parse(current.ToJsonString());

        var diff = node1.CreatePatch(node2);
        BsonArray bsonDiff;
        using (var jsonReader = new JsonReader(diff.ToJsonString()))
        {
            var serializer = new BsonArraySerializer();
            bsonDiff = serializer.Deserialize(BsonDeserializationContext.CreateRoot(jsonReader));
        }

        return new AuditEntry()
        {
            Id = id,
            Version = version,
            DateTime = lastUpdated,
            LastUpdatedBy = lastUpdatedBy,
            Diff = diff,
            BsonDiff = bsonDiff

        };
    }
}

