using Json.Schema;
using TdmPrototypeBackend.Cli.Features.GenerateCSharpObjects.DescriptorModel;

namespace TdmPrototypeBackend.Cli.Features.GenerateCSharpObjects.Builders;

public class CSharpDescriptorBuilder(List<ISchemaVisitor> visitors)
{
    public CSharpDescriptor Build(string jsonSchema)
    {
        var mySchema = JsonSchema.FromText(jsonSchema);

        var csharpDescriptor = new CSharpDescriptor();

        var mainClassDescriptor = new ClassDescriptor("IpaffsNotification");
        mainClassDescriptor.IsResource = true;
        csharpDescriptor.AddClassDescriptor(mainClassDescriptor);
        foreach (var property in mySchema.GetProperties())
        {
            visitors.ForEach(x => x.OnProperty(new PropertyVisitorContext(csharpDescriptor, mainClassDescriptor, mySchema, property.Key, property.Value)));

        }


        foreach (var definition in mySchema.GetDefinitions())
        {
            visitors.ForEach(x => x.OnDefinition(new DefinitionVisitorContext(csharpDescriptor, mySchema, definition.Key, definition.Value)));

        }

        return csharpDescriptor;
    }


}