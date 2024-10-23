namespace Tdm.Model.Relationships;

public interface ITdmRelationships
{
    public (string, TdmRelationshipObject) GetRelationshipObject();
}