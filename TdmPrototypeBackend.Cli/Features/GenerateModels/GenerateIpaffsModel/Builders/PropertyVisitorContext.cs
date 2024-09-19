using Json.Schema;
using TdmPrototypeBackend.Cli.Features.GenerateModels.DescriptorModel;

namespace TdmPrototypeBackend.Cli.Features.GenerateModels.GenerateIpaffsModel.Builders;

public class PropertyVisitorContext(
    CSharpDescriptor cSharpDescriptor,
    ClassDescriptor classDescriptor,
    JsonSchema rootJsonSchema,
    string key,
    JsonSchema jsonSchema)
{
    public CSharpDescriptor CSharpDescriptor { get; set; } = cSharpDescriptor;

    public ClassDescriptor ClassDescriptor { get; } = classDescriptor;

    public JsonSchema RootJsonSchema { get; } = rootJsonSchema;

    public string Key { get; } = key;

    public JsonSchema JsonSchema { get; } = jsonSchema;
}