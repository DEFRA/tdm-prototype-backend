namespace TdmPrototypeBackend.Api.Swagger;

public class ResourceData<T>
{
    public string Type { get; set; }
    public string Id { get; set; }
    public T Attributes { get; set; }
}