using System.Text.Json;

namespace TdmPrototypeBackend.Types.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJsonString<T>(this T value, JsonSerializerOptions? options = null)
        {
            if (value is string s) return s;

            return JsonSerializer.Serialize(value, options);
        }
    }
}
