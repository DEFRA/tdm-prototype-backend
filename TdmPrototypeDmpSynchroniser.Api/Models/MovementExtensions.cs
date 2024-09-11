using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;

namespace TdmPrototypeDmpSynchroniser.Api.Models;

public static class MovementExtensions
{
    private class DateTimeConverterUsingDateTimeParse : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            var s = reader.GetString();
            var i = 0;
            var result = int.TryParse(s, out i);

            if (result)
            {
                var s_epoch = new DateTime(1970, 1, 1, 0, 0, 0);
                return s_epoch.AddSeconds(i);
            }
            
            return DateTime.Parse(s ?? string.Empty);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
    
    public static Movement FromClearanceRequest(string s)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.Converters.Add(new DateTimeConverterUsingDateTimeParse());
        
        var r = JsonSerializer.Deserialize<ClearanceRequestEnvelope>(s, options)!;
        var cr = r.Header;
        cr.Items = r.Items;
        
        return new Movement() {
            Id = r.Header.MasterUcr,
            ClearanceRequests = new ClearanceRequestEnvelope[]
            {
                r
            },
            Items = r.Items
        };
    }
}