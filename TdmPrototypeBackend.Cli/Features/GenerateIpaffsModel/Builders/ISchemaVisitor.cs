namespace TdmPrototypeBackend.Cli.Features.GenerateIpaffsModel.Builders;

public interface ISchemaVisitor
{
    void OnProperty(PropertyVisitorContext context);

    void OnDefinition(DefinitionVisitorContext context);
}