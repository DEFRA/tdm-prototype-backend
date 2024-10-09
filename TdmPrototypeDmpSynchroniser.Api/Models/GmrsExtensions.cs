using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Alvs;
using TdmPrototypeBackend.Types.VehicleMovement;

namespace TdmPrototypeDmpSynchroniser.Api.Models;

public static class GmrsExtensions
{
    public static SearchGmrsForDeclarationIdsResponse FromBlob(string s)
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            // PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        var r = JsonSerializer.Deserialize<SearchGmrsForDeclarationIdsResponse>(s, options)!;
        return r;
    }
}