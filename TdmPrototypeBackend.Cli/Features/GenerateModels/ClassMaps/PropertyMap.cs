namespace TdmPrototypeBackend.Cli.Features.GenerateModels.ClassMaps;

internal class PropertyMap(string name)
{
    public string Name { get; set; } = name;

    public string Type { get; set; }

    public bool TypeOverwritten { get; set; }

    public List<string> Attributes { get; set; } = new();

    public bool AttributesOverwritten { get; set; }

    public bool NoAttributes { get; set; }

    public PropertyMap SetType(string type)
    {
        Type = type ?? throw new ArgumentNullException("type");
        TypeOverwritten = true;
        return this;
    }

    public PropertyMap IsSensitive()
    {
        AddAttribute("[TdmPrototypeBackend.Types.Extensions.SensitiveData()]");
        return this;
    }


    public PropertyMap AddAttribute(string attribute)
    {
        if (string.IsNullOrEmpty(attribute))
        {
            throw new ArgumentNullException("attribute");
        }

        Attributes.Add(attribute);
        AttributesOverwritten = true;
        return this;
    }

    public PropertyMap NoAttribute()
    {
        Attributes.Clear();
        AttributesOverwritten = true;
        NoAttributes = true;
        return this;
    }
}