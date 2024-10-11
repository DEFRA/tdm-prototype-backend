using System.Text.Json;
using System.Text.Json.Serialization;
using TdmPrototypeDmpSynchroniser.Api.SensitiveData;

namespace TdmPrototypeDmpSynchroniser.Api.SensitiveData;

public class SensitiveDataRedactedConverter(ISensitiveDataOptions sensitiveDataOptions) : JsonConverter<string>
{
    /// <inheritdoc/>
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return sensitiveDataOptions.Getter(reader.GetString());
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, string objectToWrite, JsonSerializerOptions options)
        => throw new NotImplementedException("Only for reading");
}