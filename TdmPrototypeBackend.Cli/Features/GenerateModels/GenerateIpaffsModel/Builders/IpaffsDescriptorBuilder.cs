using Json.Schema;
using TdmPrototypeBackend.Cli.Features.GenerateModels.DescriptorModel;

namespace TdmPrototypeBackend.Cli.Features.GenerateModels.GenerateIpaffsModel.Builders;

public class IpaffsDescriptorBuilder(List<ISchemaVisitor> visitors)
{
    public const string Namespace = "TdmPrototypeBackend.Types.Ipaffs";
    public const string ClassNamePrefix = "Ipaffs";
    public CSharpDescriptor Build(string jsonSchema)
    {
        var mySchema = JsonSchema.FromText(jsonSchema);

        var csharpDescriptor = new CSharpDescriptor();

        var mainClassDescriptor = new ClassDescriptor("Notification", Namespace, ClassNamePrefix);
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