using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeDmpSynchroniser.Api.Models;

public static class NotificationExtensions
{
    
    public static Notification FromBlob(string s)
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            // PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };
        
        var r = JsonSerializer.Deserialize<Notification>(s, options)!;
        
        // r.Id = r.ReferenceNumber;
        
        return r;
    }
}