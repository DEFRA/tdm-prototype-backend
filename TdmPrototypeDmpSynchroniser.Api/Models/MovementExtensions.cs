using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using ALVSClearanceRequest = TdmPrototypeBackend.Types.Alvs.ALVSClearanceRequest;
using Type = System.Type;

namespace TdmPrototypeDmpSynchroniser.Api.Models;

public static class MovementExtensions
{
    private class DateTimeConverterUsingDateTimeParse : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));

            ulong number = 0;

            if (reader.TokenType == JsonTokenType.Number)
            {
                reader.TryGetUInt64(out number);
            }
            else
            {
                var s = reader.GetString();
                if (!ulong.TryParse(s, out number))
                {
                    return DateTime.Parse(s!);
                }    
            }
            var s_epoch = new DateTime(1970, 1, 1, 0, 0, 0);
            
            // 1723127967 - DEV
            // 1712851200000 - SND
            if (number > 10000000000)
            {
                return s_epoch.AddMilliseconds(number);
            }
            else if (number > 0)
            {
                return s_epoch.AddSeconds(number);
            }

            return s_epoch;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
    
    public static Movement FromClearanceRequest(string s)
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };
        
        options.Converters.Add(new DateTimeConverterUsingDateTimeParse());
        
        var r = JsonSerializer.Deserialize<ALVSClearanceRequest>(s, options)!;
        var cr = r.Header;
       // cr.Items = r.Items;
       foreach (var rItem in r.Items)
       {
           
       }
        
        return new Movement() {
            Id = r.Header.EntryReference,
            LastUpdated = r.ServiceHeader?.ServiceCallTimestamp,
            ClearanceRequests = new List<ALVSClearanceRequest>()
            {
                r
            },
            Items = r.Items?.Select(x =>
            {
                x.ClearanceRequestReference = r.Header.EntryReference;
                return x;
            }).ToList(),
        };
    }
}