using TdmPrototypeBackend.Cli.Features.GenerateModels.DescriptorModel;

namespace TdmPrototypeBackend.Cli.Features.GenerateModels.ClassMaps;

internal class GeneratorEnumMap
{
    private static readonly Dictionary<string, GeneratorEnumMap> classMaps = new Dictionary<string, GeneratorEnumMap>();

   
    public GeneratorEnumMap(string className, Action<GeneratorEnumMap> classMapInitializer)
    {
        Name = className;
        classMapInitializer(this);
    }

    public string Name { get; set; }

    public List<EnumDescriptor.EnumValueDescriptor> EnumValues = new List<EnumDescriptor.EnumValueDescriptor>();

    public GeneratorEnumMap AddEnumValue(string value)
    {
        EnumValues.Add(new EnumDescriptor.EnumValueDescriptor(value));
        return this;
    }

    public static GeneratorEnumMap RegisterEnumMap(string name, Action<GeneratorEnumMap> classMapInitializer)
    {
        var classMap = new GeneratorEnumMap(name, classMapInitializer);
        classMaps.Add(classMap.Name, classMap);
        return classMap;
    }

    public static GeneratorEnumMap LookupEnumMap(string name)
    {
        classMaps.TryGetValue(name, out var classMap);
        return classMap;
    }
}