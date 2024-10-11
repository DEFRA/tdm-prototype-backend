namespace TdmPrototypeBackend.Cli.Features.GenerateModels.ClassMaps
{
    internal class GeneratorClassMap
    {
        private static readonly Dictionary<string, GeneratorClassMap> classMaps = new Dictionary<string, GeneratorClassMap>();

        public GeneratorClassMap(string className, Action<GeneratorClassMap> classMapInitializer)
        {
            Name = className;
            ClassName = className;
            classMapInitializer(this);
        }

        public string Name { get; set; }

        public string ClassName { get; private set; }

        public List<PropertyMap> Properties { get; private set; } = new List<PropertyMap>();

        public GeneratorClassMap SetClassName(string className)
        {
            if (string.IsNullOrEmpty(className))
            {
                throw new ArgumentNullException("className");
            }

            ClassName = className;
            return this;
        }

        public PropertyMap MapProperty(string propertyName)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName");
            }
            var propertyMap = new PropertyMap(propertyName);
            Properties.Add(propertyMap);
            return propertyMap;
        }

        public static GeneratorClassMap RegisterClassMap(string name, Action<GeneratorClassMap> classMapInitializer)
        {
            var classMap = new GeneratorClassMap(name, classMapInitializer);
            classMaps.Add(classMap.Name, classMap);
            return classMap;
        }

        public static GeneratorClassMap LookupClassMap(string name)
        {
            classMaps.TryGetValue(name, out var classMap);
            return classMap;
        }
    }
}


