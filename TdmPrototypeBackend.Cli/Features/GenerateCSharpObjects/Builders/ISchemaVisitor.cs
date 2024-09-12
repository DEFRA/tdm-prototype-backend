namespace TdmPrototypeBackend.Cli.Features.GenerateCSharpObjects.Builders;

public interface ISchemaVisitor
{
    void OnProperty(PropertyVisitorContext context);

    void OnDefinition(DefinitionVisitorContext context);
}