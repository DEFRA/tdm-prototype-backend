using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using Json.Patch;
using TdmPrototypeBackend.Types.Extensions;

namespace TdmPrototypeBackend.Types;

public class AuditEntry
{    public string Id { get; set; }
    public int Version { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedSource { get; set; }

    public DateTime CreatedLocal { get; set;} = System.DateTime.UtcNow;

    public string Status { get; set; }

    public List<AuditDiffEntry> Diff { get; set; } = new ();


    public static AuditEntry Create<T>(T previous, T current, string id, int version, DateTime? lastUpdated, string lastUpdatedBy, string status)
    {
        var node1 = JsonNode.Parse(previous.ToJsonString());
        var node2 = JsonNode.Parse(current.ToJsonString());

        return Create(node1, node2, id, version, lastUpdated, lastUpdatedBy, status);
    }

    public static AuditEntry Create(JsonNode previous, JsonNode current, string id, int version, DateTime? lastUpdated, string lastUpdatedBy, string status)
    {
        var diff = previous.CreatePatch(current);

        var auditEntry = new AuditEntry()
        {
            Id = id,
            Version = version,
            CreatedSource = lastUpdated,
            CreatedBy = lastUpdatedBy,
            CreatedLocal = DateTime.UtcNow,
            Status = status

        };

        foreach (var operation in diff.Operations)
        {
            auditEntry.Diff.Add(AuditDiffEntry.Create(operation));
        }

        return auditEntry;
    }

    public static AuditEntry CreateUpdated<T>(T previous, T current, string id, int version, DateTime? lastUpdated, string lastUpdatedBy)
    {
        return Create(previous,current, id, version, lastUpdated, lastUpdatedBy, "Updated");
    }

    public static AuditEntry CreateCreatedEntry<T>(T current, string id, int version, DateTime? lastUpdated, string lastUpdatedBy)
    {
        return new AuditEntry()
        {
            Id = id,
            Version = version,
            CreatedSource = lastUpdated,
            CreatedBy = lastUpdatedBy,
            CreatedLocal = DateTime.UtcNow,
            Status = "Created"

        };
    }

    public static AuditEntry CreateSkippedVersion<T>(T current, string id, int version, DateTime? lastUpdated, string lastUpdatedBy)
    {
        return new AuditEntry()
        {
            Id = id,
            Version = version,
            CreatedSource = lastUpdated,
            CreatedBy = lastUpdatedBy,
            CreatedLocal = DateTime.UtcNow,
            Status = "Updated"

        };
    }

    public static AuditEntry CreateMatch(string id, int version, DateTime? lastUpdated, string lastUpdatedBy)
    {
        return new AuditEntry()
        {
            Id = id,
            Version = version,
            CreatedSource = lastUpdated,
            CreatedBy = lastUpdatedBy,
            CreatedLocal = DateTime.UtcNow,
            Status = "Matched"

        };
    }

    public static AuditEntry CreateDecision(string previous, string current, string id, int version, DateTime? lastUpdated, string lastUpdatedBy)
    {
        var node1 = JsonNode.Parse(previous);
        var node2 = JsonNode.Parse(current);

        return Create(node1, node2, id, version, lastUpdated, lastUpdatedBy, "Decision");
    }

    public class AuditDiffEntry
    {
        public string Path { get; set; }

        public string Op { get; set; }

        public object Value { get; set; }

        public static AuditDiffEntry Create(PatchOperation operation)
        {
            object value = null;
            if (operation.Value != null)
            {
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