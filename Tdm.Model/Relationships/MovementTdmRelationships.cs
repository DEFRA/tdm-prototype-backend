using JsonApiDotNetCore.Resources.Annotations;

namespace Tdm.Model.Relationships;

public class MovementTdmRelationships : ITdmRelationships
{
    [Attr]
    public TdmRelationshipObject Notifications { get; set; } = TdmRelationshipObject.CreateDefault();

    public (string, TdmRelationshipObject) GetRelationshipObject()
    {
        return ("notifications", Notifications);
    }
}