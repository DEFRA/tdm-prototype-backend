using System.Text.Json;
using System.Text.Json.Serialization;

namespace TdmPrototypeDmpSynchroniser.Api.SensitiveData;

public interface ISensitiveDataSerializer
{
    public T Deserialize<T>(string json, Action<JsonSerializerOptions> optionsOverride);
}