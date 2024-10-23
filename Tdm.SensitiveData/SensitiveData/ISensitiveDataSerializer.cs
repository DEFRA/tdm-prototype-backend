using System.Text.Json;

namespace Tdm.SensitiveData.SensitiveData;

public interface ISensitiveDataSerializer
{
    public T Deserialize<T>(string json, Action<JsonSerializerOptions> optionsOverride);
}