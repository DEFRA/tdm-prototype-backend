using System.Text.Json.Serialization;
using JsonApiDotNetCore.Resources.Annotations;

namespace TdmPrototypeBackend.Types.Ipaffs;

/// <summary>
/// Added manual class to include message, which isn't part of the schema, but a lot of data includes it
/// </summary>
public partial class IpaffsValidationMessageCode  //
{


    /// <summary>
    /// Field
    /// </summary>
    [Attr]
    [JsonPropertyName("message")]
    public string? Message { get; set; }
   
}