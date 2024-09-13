namespace TdmPrototypeBackend.Cli.Features.GenerateCSharpObjects.DescriptorModel;

public class CSharpDescriptor
{
	public List<ClassDescriptor> Classes { get; set; } = [];

	public List<EnumDescriptor> Enums { get; set; } = [];

	public void AddEnumDescriptor(EnumDescriptor enumDescriptor)
	{
		if (Enums.All(x => x.GetEnumName() != enumDescriptor.GetEnumName()))
		{
			Enums.Add(enumDescriptor);
		}
	}

	public void AddClassDescriptor(ClassDescriptor classDescriptor)
	{
		if (Classes.All(x => x.Name != classDescriptor.Name))
		{
			Classes.Add(classDescriptor);
		}
	}
}