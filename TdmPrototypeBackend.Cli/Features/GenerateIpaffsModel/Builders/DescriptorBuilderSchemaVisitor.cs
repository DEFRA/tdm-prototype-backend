using Humanizer;
using Json.Schema;
using TdmPrototypeBackend.Cli.Features.GenerateIpaffsModel.DescriptorModel;

namespace TdmPrototypeBackend.Cli.Features.GenerateIpaffsModel.Builders;

public class DescriptorBuilderSchemaVisitor : ISchemaVisitor
{
    public void OnProperty(PropertyVisitorContext context)
    {
        var typeKeyword = context.JsonSchema.GetKeyword<TypeKeyword>();
        var description = context.JsonSchema.GetDescription();

        if (typeKeyword is not null)
        {
            if (typeKeyword.Type == SchemaValueType.Array)
            {
                var itemsKeyword = context.JsonSchema.GetKeyword<ItemsKeyword>();
                if (itemsKeyword is not null)
                {
                    if (itemsKeyword.SingleSchema.IsReferenceType())
                    {
                        var refKeyword = itemsKeyword.SingleSchema.GetKeyword<RefKeyword>();
                        var value = refKeyword.Reference.ToString().Split('/').Last();

                        context.ClassDescriptor.Properties.Add(new PropertyDescriptor(context.Key,
                            $"{value}",
                            description,
                            true, true));
                    }
                    else
                    {
                        var itemType = itemsKeyword.SingleSchema.GetKeyword<TypeKeyword>().Type;
                        if (itemType != SchemaValueType.Object)
                        {
                            context.ClassDescriptor.Properties.Add(new PropertyDescriptor(context.Key,
                                itemType.ToCSharpArrayType(),
                                description,
                                false, true));
                        }
                        else
                        {
                            OnDefinition(new DefinitionVisitorContext(context.CSharpDescriptor, context.RootJsonSchema, context.Key, itemsKeyword.SingleSchema));
                            context.ClassDescriptor.Properties.Add(new PropertyDescriptor(context.Key,
                                context.Key,
                                description,
                                true, true));
                        }
                    }

                }
            }
            else
            {
                if (context.JsonSchema.IsClassAndHasProperties())
                {
                    var propertiesKeyword = context.JsonSchema.GetKeyword<PropertiesKeyword>();
                    var classDescriptor = new ClassDescriptor(context.Key.Dehumanize());
                    classDescriptor.Description = context.JsonSchema.GetDescription();
                    context.CSharpDescriptor.AddClassDescriptor(classDescriptor);

                    foreach (var property in propertiesKeyword.Properties)
                    {
                        OnProperty(new PropertyVisitorContext(context.CSharpDescriptor, classDescriptor, context.RootJsonSchema, property.Key,
                            property.Value));
                    }

                    context.ClassDescriptor.Properties.Add(new PropertyDescriptor(context.Key, context.Key,
                        description,
                        true, false));
                }
                else
                {
                    var t = typeKeyword.Type.ToCSharpType();
                    if (context.JsonSchema.IsEnum())
                    {
                        t = EnumDescriptor.BuildEnumName(context.Key, context.ClassDescriptor.Name);
                    }

                    context.ClassDescriptor.Properties.Add(new PropertyDescriptor(context.Key, t,
                        description,
                        false, false));
                }
               
            }

        }
        else
        {
            var refKeyword = context.JsonSchema.GetKeyword<RefKeyword>();
            if (refKeyword is not null)
            {
                var value = refKeyword.Reference.ToString().Split('/').Last();
                var definition = context.RootJsonSchema.GetDefinitions().FirstOrDefault(x =>
                    x.Key.Equals(value, StringComparison.InvariantCultureIgnoreCase));

                var defType = definition.Value.GetKeyword<TypeKeyword>().Type;

                if (defType == SchemaValueType.Object)
                {
                    context.ClassDescriptor.Properties.Add(new PropertyDescriptor(context.Key, value,
                        description, true, false));
                }
                else if (defType == SchemaValueType.Array)
                {
                    var itemsKeyword = definition.Value.GetKeyword<ItemsKeyword>();
                    if (itemsKeyword is not null)
                    {
                        var itemType = itemsKeyword.SingleSchema.GetKeyword<TypeKeyword>().Type;
                        if (itemType != SchemaValueType.Object)
                        {
                            context.ClassDescriptor.Properties.Add(new PropertyDescriptor(context.Key,
                                itemType.ToCSharpArrayType(),
                                description,
                                false, true));
                        }
                    }
                }
                else
                {
                    context.ClassDescriptor.Properties.Add(new PropertyDescriptor(context.Key, defType.ToCSharpType(),
                        description,
                        true, false));
                }
            }
            else
            {
                var propertiesKeyword = context.JsonSchema.GetKeyword<PropertiesKeyword>();
                var classDescriptor = new ClassDescriptor(context.Key.Dehumanize());
                classDescriptor.Description = context.JsonSchema.GetDescription();
                context.CSharpDescriptor.AddClassDescriptor(classDescriptor);

                foreach (var property in propertiesKeyword.Properties)
                {
                    OnProperty(new PropertyVisitorContext(context.CSharpDescriptor, classDescriptor, context.RootJsonSchema, property.Key,
                        property.Value));
                }

                context.ClassDescriptor.Properties.Add(new PropertyDescriptor(context.Key, context.Key,
                    description,
                    true, false));
            }
        }

        if (context.JsonSchema.IsEnum())
        {
            OnEnum(context.CSharpDescriptor, context.JsonSchema, context.ClassDescriptor, context.Key);
        }
    }

    public void OnDefinition(DefinitionVisitorContext context)
    {
        if (context.JsonSchema.IsEnum())
        {
            OnEnum(context.CSharpDescriptor, context.JsonSchema, null, context.Key);

        }
        else if (context.JsonSchema.IsClass())
        {
            var classDescriptor = new ClassDescriptor(context.Key.Dehumanize());
            classDescriptor.Description = context.JsonSchema.GetDescription();
            context.CSharpDescriptor.AddClassDescriptor(classDescriptor);

            var propertiesKeyword = context.JsonSchema.GetKeyword<PropertiesKeyword>();

            foreach (var property in propertiesKeyword.Properties)
            {
                OnProperty(new PropertyVisitorContext(context.CSharpDescriptor, classDescriptor, context.RootJsonSchema, property.Key,
                    property.Value));
            }
        }
    }

    private void OnEnum(CSharpDescriptor cSharpDescriptor, JsonSchema schema, ClassDescriptor classDescriptor, string name)
    {
        var enumKeyword = schema.GetKeyword<EnumKeyword>();

        if (enumKeyword is not null)
        {
            var values = enumKeyword.Values.Select(x => new EnumDescriptor.EnumValueDescriptor(x.ToString()))
                .ToList();
            cSharpDescriptor.AddEnumDescriptor(new EnumDescriptor(name, classDescriptor?.Name) { Values = values });
        }
    }
}