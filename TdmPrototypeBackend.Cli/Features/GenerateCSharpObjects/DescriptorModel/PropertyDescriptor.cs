using System.Diagnostics;
using Humanizer;
using Json.Schema;
using System.Runtime;

namespace TdmPrototypeBackend.Cli.Features.GenerateCSharpObjects.DescriptorModel
{
    [DebuggerDisplay("{Name}")]
    public class PropertyDescriptor(string name, string type, string description, bool isReferenceType, bool isArray)
    {
        public string Name { get; set; } = name;

        public string Type { get; set; } = type;

        public string Description { get; set; } = description;

        public bool IsReferenceType { get; set; } = isReferenceType;

        public bool IsNullable { get; set; }

        public bool IsArray { get; set; } = isArray;

        public string GetPropertyName()
        {
            if (name.Equals("type", StringComparison.InvariantCultureIgnoreCase))
            {
                return $"_{name.Dehumanize()}";
            }
            return Name.Dehumanize();
        }

        public string GetPropertyType()
        {
            var t = Type;

           
            if (isReferenceType && !Type.Equals("Result") && !Type.Equals("Unit") && !Type.Equals("string") && !Type.Equals("InspectionRequired"))
            {
                t = $"{Type}Dto".Dehumanize();
            }

            if (IsArray)
            {
                t = $"{t}[]";
            }
            return t;
        }
    }


}
