using Json.Schema;
using TdmPrototypeBackend.Cli.Features.GenerateModels.DescriptorModel;

namespace TdmPrototypeBackend.Cli.Features.GenerateModels.GenerateIpaffsModel.Builders;

public class DefinitionVisitorContext(
    CSharpDescriptor cSharpDescriptor,
    JsonSchema rootJsonSchema,
    string key,
    JsonSchema jsonSchema)
{
    public CSharpDescriptor CSharpDescriptor { get; set; } = cSharpDescriptor;

    public JsonSchema RootJsonSchema { get; set; } = rootJsonSchema;

    public string Key { get; set; } = key;

    public JsonSchema JsonSchema { get; set; } = jsonSchema;
}