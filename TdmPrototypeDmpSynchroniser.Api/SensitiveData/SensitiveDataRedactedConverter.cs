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

public class StringArraySensitiveDataRedactedConverter(ISensitiveDataOptions sensitiveDataOptions) : JsonConverter<string[]>
{
    /// <inheritdoc/>
    public override string[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException();
        }


        var items = new List<string>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                return items.ToArray();
            }

            // Get the key.
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            string? value = sensitiveDataOptions.Getter(reader.GetString());

          items.Add(value);
        }

        return items.ToArray();
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, string[] objectToWrite, JsonSerializerOptions options)
        => throw new NotImplementedException("Only for reading");
}