using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;

namespace TdmPrototypeDmpSynchroniser.Api.Models;

public static class IpaffsNotificationExtensions
{
    
    public static IpaffsNotification FromBlob(string s)
    {
        JsonSerializerOptions options = new JsonSerializerOptions();
        
        var r = JsonSerializer.Deserialize<IpaffsNotification>(s, options)!;
        // var cr = r.Header;
        // cr.Items = r.Items;

        return r;
        // {
        //     Id = r.Header.MasterUcr,
        //     ClearanceRequests = new ClearanceRequestEnvelope[]
        //     {
        //         r
        //     },
        //     Items = r.Items
        // };
    }
}