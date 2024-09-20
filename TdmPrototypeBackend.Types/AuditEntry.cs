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

    public string Status { get; set; }

    public List<AuditDiffEntry> Diff { get; set; } = new ();

    //[BsonIgnore]
    //public JsonPatch Diff { get; set; }

    //[JsonIgnore]
    //[BsonElement("diff")]
    //public BsonArray BsonDiff
    //{
    //    get => _bsonDiff;
    //    set
    //    {
    //        _bsonDiff = value;
    //        Diff ??= JsonSerializer.Deserialize<JsonPatch>(BsonDiff.ToJson());
    //    }
    //}


    public static AuditEntry Create<T>(T previous, T current, string id, int version, string lastUpdated, string lastUpdatedBy)
    {
        var node1 = JsonNode.Parse(previous.ToJsonString());
        var node2 = JsonNode.Parse(current.ToJsonString());

        var diff = node1.CreatePatch(node2);
       
        var auditEntry =  new AuditEntry()
        {
            Id = id,
            Version = version,
            DateTime = lastUpdated,
            LastUpdatedBy = lastUpdatedBy,
            Status = "DiffCreated"

        };

        foreach (var operation in diff.Operations)
        {
            auditEntry.Diff.Add(AuditDiffEntry.Create(operation));
        }

        return auditEntry;
    }

    public static AuditEntry CreateSkippedVersion<T>(T current, string id, int version, string lastUpdated, string lastUpdatedBy)
    {
        return new AuditEntry()
        {
            Id = id,
            Version = version,
            DateTime = lastUpdated,
            LastUpdatedBy = lastUpdatedBy,
            Status = "SkippedVersion"

        };
    }

    public class AuditDiffEntry
    {
        public string Path { get; set; }

        public string Op { get; set; }

        public object Value { get; set; }

        public static AuditDiffEntry Create(PatchOperation operation)
        {
            object value = null;
            switch (operation.Value.GetValueKind())
            {
                case JsonValueKind.Undefined:
                    value = "UNKNOWN";
                    break;
                case JsonValueKind.Object:
                    value = "COMPLEXTYPE";
                    break;
                case JsonValueKind.Array:
                    value = "ARRAY";
                    break;
                case JsonValueKind.String:
                    value = operation.Value.GetValue<string>();
                    break;
                case JsonValueKind.Number:
                    value = operation.Value.GetValue<int>();
                    break;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    value = operation.Value.GetValue<bool>();
                    break;
                case JsonValueKind.Null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new AuditEntry.AuditDiffEntry()
            {
                Path = operation.Path.ToString(),
                Op = operation.Op.ToString(),
                Value = value
            };
        }
    }
}

