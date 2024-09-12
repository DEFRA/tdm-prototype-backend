using System.Diagnostics;
using Humanizer;

namespace TdmPrototypeBackend.Cli.Features.GenerateCSharpObjects.DescriptorModel;

[DebuggerDisplay("{Name}")]
public class ClassDescriptor(string name)
{
    public string Name { get; set; } = name;

    public string Description { get; set; }

    public List<PropertyDescriptor> Properties { get; set; } = [];

    public string GetClassName()
    {
        return $"{Name}Dto".Dehumanize();
    }
}