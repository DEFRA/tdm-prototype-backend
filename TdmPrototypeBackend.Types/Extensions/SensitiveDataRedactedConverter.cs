using System.Text.Json;
using System.Text.Json.Serialization;

namespace TdmPrototypeBackend.Types.Extensions;

public class SensitiveDataRedactedConverter(SensitiveDataOptions sensitiveDataOptions) : JsonConverter<string>
{
    /// <inheritdoc/>
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return sensitiveDataOptions.Getter();
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, string objectToWrite, JsonSerializerOptions options)
        => throw new NotImplementedException("Only for reading");
}