using System.Diagnostics;
using Humanizer;

namespace TdmPrototypeBackend.Cli.Features.GenerateCSharpObjects.DescriptorModel;

[DebuggerDisplay("{Name}")]
public class EnumDescriptor(string name)
{
    public string Name { get; set; } = name;

    public List<EnumValueDescriptor> Values { get; set; } = [];

    public string GetEnumName()
    {
        return Name.Dehumanize();
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

            return Value.Dehumanize().ToLower().Pascalize();
        }
    }
}