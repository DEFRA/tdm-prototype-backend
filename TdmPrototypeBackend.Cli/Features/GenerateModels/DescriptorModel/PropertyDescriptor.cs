using System.Diagnostics;
using Humanizer;

namespace TdmPrototypeBackend.Cli.Features.GenerateModels.DescriptorModel
{
    [DebuggerDisplay("{Name}")]
    public class PropertyDescriptor
    {
        private readonly string _name;

        private readonly bool _isReferenceType;

        private readonly bool _isArray;

        private readonly string _classNamePrefix;

        public PropertyDescriptor(string name, string type, string description, bool isReferenceType, bool isArray, string classNamePrefix)
        {
            _name = name;
            _isReferenceType = isReferenceType;
            _isArray = isArray;
            _classNamePrefix = classNamePrefix;
            Name = name;
            Type = type;
            Description = description;
            IsReferenceType = isReferenceType;
            IsArray = isArray;
            Attributes = new List<string>() { "[Attr]", $"[JsonPropertyName(\"{Name}\")]" };
        }
        // private const string prefix = "Ipaffs";

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public List<string> Attributes { get; set; } = new();

        public bool IsReferenceType { get; set; }

        public bool IsNullable { get; set; }

        public bool IsArray { get; set; }

        public string GetPropertyName()
        {
            var n = Name.Dehumanize();
            if (_name.Equals("type", StringComparison.InvariantCultureIgnoreCase) || _name.Equals("id", StringComparison.InvariantCultureIgnoreCase))
            {
                return $"{_classNamePrefix}{_name.Dehumanize()}";
            }


            if (_isArray)
            {
                n = n.Pluralize();
            }

            return n;
        }

        public string GetPropertyType()
        {
            var t = Type;


            if (_isReferenceType && !Type.Equals("Result") && !Type.Equals("Unit") && !Type.Equals("string") && !Type.Equals("InspectionRequired"))
            {
                t = ClassDescriptor.BuildClassName(Type, _classNamePrefix);
            }

            if (IsArray && !t.Contains("[]"))
            {
                t = $"{t}[]";
            }
            return t;
        }

    }


}
