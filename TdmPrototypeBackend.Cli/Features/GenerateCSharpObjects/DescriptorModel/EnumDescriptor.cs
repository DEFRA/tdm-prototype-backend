using System.Diagnostics;
using Humanizer;

namespace TdmPrototypeBackend.Cli.Features.GenerateCSharpObjects.DescriptorModel;

[DebuggerDisplay("{Name}")]
public class EnumDescriptor(string name, string parentName)
{
    private const string prefix = "Ipaffs";
    private const string suffix = "Enum";

    public string Name { get; set; } = name;

    public List<EnumValueDescriptor> Values { get; set; } = [];

    public string GetEnumName()
    {
        return BuildEnumName(Name, parentName);
    }

    public class EnumValueDescriptor(string value)
    {
        public string Value { get; set; } = value;

        public string GetCSharpValue()
        {
            if (Value.Contains(','))
            {
                try
                {
                    return Value.Replace(",", "").Dehumanize();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }

            if (Value.All(char.IsUpper))
            {
                return Value.Dehumanize().ToLower().Pascalize();
            }

            return Value.Dehumanize();
        }
    }

    public static string BuildEnumName(string name, string parentName)
    {
        if (string.IsNullOrEmpty(parentName))
        {
            return $"{prefix}{name.Dehumanize()}{suffix}";
        }

        return $"{prefix}{parentName}{name.Dehumanize()}{suffix}";
    }
}