using System.Diagnostics;
using Humanizer;

namespace TdmPrototypeBackend.Cli.Features.GenerateIpaffsModel.DescriptorModel
{
    [DebuggerDisplay("{Name}")]
    public class PropertyDescriptor(string name, string type, string description, bool isReferenceType, bool isArray, string classNamePrefix)
    {
       // private const string prefix = "Ipaffs";

        public string Name { get; set; } = name;

        public string Type { get; set; } = type;

        public string Description { get; set; } = description;

        public bool IsReferenceType { get; set; } = isReferenceType;

        public bool IsNullable { get; set; }

        public bool IsArray { get; set; } = isArray;

        public string GetPropertyName()
        {
            string n = Name.Dehumanize();
            if (name.Equals("type", StringComparison.InvariantCultureIgnoreCase) || name.Equals("id", StringComparison.InvariantCultureIgnoreCase))
            {
                return $"{classNamePrefix}{name.Dehumanize()}";
            }
            

            if (isArray)
            {
                n = n.Pluralize();
            }

            return n;
        }

        public string GetPropertyType()
        {
            var t = Type;

           
            if (isReferenceType && !Type.Equals("Result") && !Type.Equals("Unit") && !Type.Equals("string") && !Type.Equals("InspectionRequired"))
            {
               t =  ClassDescriptor.BuildClassName(Type, classNamePrefix);
            }

            if (IsArray && !t.Contains("[]"))
            {
                t = $"{t}[]";
            }
            return t;
        }
    }


}
