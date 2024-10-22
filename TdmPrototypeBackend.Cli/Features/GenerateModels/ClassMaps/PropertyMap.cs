namespace TdmPrototypeBackend.Cli.Features.GenerateModels.ClassMaps;

public enum Model
{
    Source,
    Internal,
    Both
}

internal class PropertyMap(string name)
{
    public string Name { get; set; } = name;

    public string Type { get; set; }

    public bool TypeOverwritten { get; set; }

    public List<string> SourceAttributes { get; set; } = new();

    public List<string> InternalAttributes { get; set; } = new();

    public bool AttributesOverwritten { get; set; }

    public string OverriddenSourceName { get; set; }

    public string OverriddenInternalName { get; set; }

    public bool SourceNameOverwritten { get; set; }

    public bool InternalNameOverwritten { get; set; }

    public bool NoAttributes { get; set; }

    public bool ExcludedFromApi { get; set; } = false;

    public PropertyMap SetType(string type)
    {
        Type = type ?? throw new ArgumentNullException("type");
        TypeOverwritten = true;
        return this;
    }

    public PropertyMap IsDateTime()
    {
        SetType("DateTime");
        return this;
    }

    public PropertyMap IsDate()
    {
        SetType("DateOnly");
        return this;
    }

    public PropertyMap IsTime()
    {
        SetType("TimeOnly");
        return this;
    }

    public PropertyMap SetName(string name)
    {
        SetSourceName(name);
        SetInternalName(name);
        return this;
    }

    public PropertyMap SetSourceName(string name)
    {
        OverriddenSourceName = name ?? throw new ArgumentNullException("name");
        SourceNameOverwritten = true;
        return this;
    }

    public PropertyMap SetInternalName(string name)
    {
        OverriddenInternalName = name ?? throw new ArgumentNullException("name");
        InternalNameOverwritten = true;
        return this;
    }

    public PropertyMap IsSensitive()
    {
        AddAttribute("[TdmPrototypeBackend.Types.Extensions.SensitiveData()]", Model.Source);
        return this;
    }

    public PropertyMap SetBsonIgnore()
    {
        AddAttribute("[MongoDB.Bson.Serialization.Attributes.BsonIgnore]", Model.Internal);
        return this;
    }

    public PropertyMap ExcludeFromApi()
    {
        ExcludedFromApi = true;
        return this;
    }


    public PropertyMap AddAttribute(string attribute, Model model)
    {
        if (string.IsNullOrEmpty(attribute))
        {
            throw new ArgumentNullException("attribute");
        }

        switch (model)
        {
            case Model.Source:
                SourceAttributes.Add(attribute);
                break;
            case Model.Internal:
                InternalAttributes.Add(attribute);
                break;
            case Model.Both:
                SourceAttributes.Add(attribute);
                InternalAttributes.Add(attribute);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(model), model, null);
        }

        AttributesOverwritten = true;
        return this;
    }

    public PropertyMap NoAttribute(Model model)
    {
        switch (model)
        {
            case Model.Source:
                SourceAttributes.Clear();
                break;
            case Model.Internal:
                InternalAttributes.Clear();
                break;
            case Model.Both:
                SourceAttributes.Clear();
                InternalAttributes.Clear();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(model), model, null);
        }
        AttributesOverwritten = true;
        NoAttributes = true;
        return this;
    }
}