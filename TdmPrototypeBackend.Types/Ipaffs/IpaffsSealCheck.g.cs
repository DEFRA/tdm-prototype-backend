//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable

using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using System.Dynamic;


namespace TdmPrototypeBackend.Types.Ipaffs;

/// <summary>
/// Details of the seal check
/// </summary>
public partial class IpaffsSealCheck  //
{


    /// <summary>
    /// Is seal check satisfactory
    /// </summary
    [Attr]
    [JsonPropertyName("satisfactory")]
    public bool? Satisfactory { get; set; }

	
    /// <summary>
    /// reason for not satisfactory
    /// </summary
    [Attr]
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

	
    /// <summary>
    /// Official inspector
    /// </summary
    [Attr]
    [JsonPropertyName("officialInspector")]
    public IpaffsOfficialInspector? OfficialInspector { get; set; }

	
    /// <summary>
    /// date and time of seal check
    /// </summary
    [Attr]
    [JsonPropertyName("dateTimeOfCheck")]
    public string? DateTimeOfCheck { get; set; }

	}


