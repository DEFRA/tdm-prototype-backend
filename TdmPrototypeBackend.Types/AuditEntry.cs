using System.Text.Json.Nodes;
using Json.Patch;
using TdmPrototypeBackend.Types.Extensions;

namespace TdmPrototypeBackend.Types;

// TODO : Can we generate this from the schema file 
// https://eaflood.atlassian.net/wiki/spaces/TRADE/pages/5104664583/PHA+Port+Health+Authority+Integration+Data+Schema

public class AuditEntry
{
    public string Id { get; set; }
    public int Version { get; set; }

    public string LastUpdatedBy { get; set; }

    public string DateTime { get; set; }

    public string Diff { get; set; }

    public static AuditEntry Create<T>(T previous, T current, string id, int version, string lastUpdated, string lastUpdatedBy)
    {
        var node1 = JsonNode.Parse(previous.ToJsonString());
        var node2 = JsonNode.Parse(current.ToJsonString());

        var diff = node1.CreatePatch(node2);
        
       return new AuditEntry()
        {
            Id = id,
            Version = version,
            DateTime = lastUpdated,
            LastUpdatedBy = lastUpdatedBy,
            Diff = diff.ToJsonString()

        };
    }
}

