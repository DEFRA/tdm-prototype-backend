using System.Diagnostics;
using Humanizer;

namespace TdmPrototypeBackend.Cli.Features.GenerateModels.DescriptorModel;

[DebuggerDisplay("{Name}")]
public class ClassDescriptor(string name, string sourceNamespace, string internalNamespace, string classNamePrefix)
{
    // private const string classPrefix = "Ipaffs";
    public string Name { get; set; } = name;

    public bool IgnoreInternalClass { get; set; }
    public string SourceNamespace { get; } = sourceNamespace;

    public string InternalNamespace { get; } = internalNamespace;

    public string Description { get; set; }

    public bool IsResource { get; set; }

    public List<PropertyDescriptor> Properties { get; set; } = [];

    public void AddPropertyDescriptor(PropertyDescriptor propertyDescriptor)
    {
        if (Properties.All(x => x.SourceName != propertyDescriptor.SourceName))
        {
            Properties.Add(propertyDescriptor);
        }
    }

    public string GetClassName()
    {
        return BuildClassName(Name, classNamePrefix, IsResource);
    }

    public string GetSourceFullClassName()
    {
        return $"{sourceNamespace}.{BuildClassName(Name, classNamePrefix, IsResource)}";
    }

    public string GetInternalFullClassName()
    {
        return $"{internalNamespace}.{BuildClassName(Name, classNamePrefix, IsResource)}";
    }

    public static string BuildClassName(string name, string classNamePrefix, bool isResource = false)
    {
        if (name.StartsWith(classNamePrefix))
        {
            return name.Dehumanize();
        }
        return isResource ? name.Dehumanize() : $"{classNamePrefix}{name.Dehumanize()}";
    }

}