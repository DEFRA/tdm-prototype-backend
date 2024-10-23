using JsonApiDotNetCore.Resources.Annotations;

namespace Tdm.Model.Relationships;

public sealed class ResourceLink
{
    [Attr]
    public string Self { get; set; }
}