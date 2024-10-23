using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tdm.Model.Extensions
{
    public static class JsonExtensions
    {
        public static JsonSerializerOptions Default = new ()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public static string ToJsonString<T>(this T value, JsonSerializerOptions? options = null)
        {
            if (value is string s) return s;

            return JsonSerializer.Serialize(value, options ?? Default);
        }
    }
}
