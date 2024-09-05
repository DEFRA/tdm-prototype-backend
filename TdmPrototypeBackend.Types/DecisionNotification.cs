using JsonApiDotNetCore.MongoDb.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace TdmPrototypeBackend.Types;

// Recreation of DecisionNotification schema from
// https://eaflood.atlassian.net/wiki/spaces/TRADE/pages/5104664583/PHA+Port+Health+Authority+Integration+Data+Schema

[Resource]
public class DecisionNotification : CustomStringMongoIdentifiable
{
    // This field is used by the jsonapi-consumer to control the correct casing in the type field
    public string Type { get; set; } = "decisionNotifications";
    
    [Attr]
    public string SourceSystem { get; set; } = default!;

    [Attr]
    public string DestinationSystem { get; set; } = default!;
    
    [Attr]
    public int CorrelationID { get; set; } = default!;
}