using System.Text.Json;
using System.Text.Json.Serialization;

namespace TdmPrototypeDmpSynchroniser.Api.SensitiveData;

public class SensitiveDataSerializer(ISensitiveDataOptions options) : ISensitiveDataSerializer
{
    private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
    {
        TypeInfoResolver = new SensitiveDataTypeInfoResolver(options),
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    public T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, jsonOptions);
    }
}