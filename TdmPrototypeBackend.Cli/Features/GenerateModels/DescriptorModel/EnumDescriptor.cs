using System.Diagnostics;
using System.Text;
using Humanizer;

namespace TdmPrototypeBackend.Cli.Features.GenerateModels.DescriptorModel;

[DebuggerDisplay("{Name}")]
public class EnumDescriptor(string name, string parentName, string @namespace, string classNamePrefix)
{
    //private const string prefix = "Ipaffs";
    private const string suffix = "Enum";

    public string Name { get; set; } = name;

    public string Namespace { get; } = @namespace;

    public List<EnumValueDescriptor> Values { get; set; } = [];

    public void AddValues(List<EnumValueDescriptor> values)
    {
        Values.AddRange(values);
    }

    public string GetEnumName()
    {
        return BuildEnumName(Name, parentName, classNamePrefix);
    }

    public class EnumValueDescriptor(string value)
    {
        public string Value { get; set; } = value;

        public string GetCSharpValue()
        {
            if (value.Contains("_"))
            {
                var values = value.Split("_");

                var sb = new StringBuilder();
                foreach (var s in values)
                {
                    var v = s.Dehumanize();
                    if (v.All(char.IsUpper))
                    {
                        sb.Append(v.ToLower().Pascalize());
                    }
                }
                return sb.ToString();
            }
            else
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

                var v = Value.Dehumanize();
                if (v.All(char.IsUpper))
                {
                    return v.ToLower().Pascalize();
                }

                return v;
            }
        }
    }

    public static string BuildEnumName(string name, string parentName, string classNamePrefix)
    {
        if (string.IsNullOrEmpty(parentName))
        {
            return $"{classNamePrefix}{name.Dehumanize()}{suffix}";
        }

        return $"{classNamePrefix}{parentName}{name.Dehumanize()}{suffix}";
    }
}