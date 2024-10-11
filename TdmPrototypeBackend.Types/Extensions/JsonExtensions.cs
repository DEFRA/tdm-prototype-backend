using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TdmPrototypeBackend.Types.Extensions
{
    public static class JsonExtensions
    {
        public static SensitiveDataOptions SensitiveDataOptions = new() { Include = true };

        public static JsonSerializerOptions Default = new ()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public static JsonSerializerOptions CreateIngestSerializerOptions()
        {
            return new() { TypeInfoResolver = new SensitiveDataTypeInfoResolver(SensitiveDataOptions) };
        }

        public static string ToJsonString<T>(this T value, JsonSerializerOptions? options = null)
        {
            if (value is string s) return s;

            return JsonSerializer.Serialize(value, options ?? Default);
        }
    }
}
