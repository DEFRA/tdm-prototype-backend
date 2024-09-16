using System.Diagnostics;
using Humanizer;

namespace TdmPrototypeBackend.Cli.Features.GenerateIpaffsModel.DescriptorModel;

[DebuggerDisplay("{Name}")]
public class ClassDescriptor(string name, string @namespace, string classNamePrefix)
{
   // private const string classPrefix = "Ipaffs";
    public string Name { get; set; } = name;
    public string Namespace { get; } = @namespace;

    public string Description { get; set; }

    public bool IsResource { get; set; }

    public List<PropertyDescriptor> Properties { get; set; } = [];

    public string GetClassName()
    {
        return BuildClassName(Name, classNamePrefix, IsResource);
    }

    public static string BuildClassName(string name, string classNamePrefix, bool isResource = false)
    {
        return isResource ? name.Dehumanize() : $"{classNamePrefix}{name.Dehumanize()}";
    }

}