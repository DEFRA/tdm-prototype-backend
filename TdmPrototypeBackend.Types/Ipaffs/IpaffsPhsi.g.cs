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
/// PHSI Decision Breakdown
/// </summary>
public partial class IpaffsPhsi  //
{


    /// <summary>
    /// Whether or not a documentary check is required for PHSI
    /// </summary
    [Attr]
    [JsonPropertyName("documentCheck")]
    [System.ComponentModel.Description("Whether or not a documentary check is required for PHSI")]
    public bool? DocumentCheck { get; set; }

	
    /// <summary>
    /// Whether or not an identity check is required for PHSI
    /// </summary
    [Attr]
    [JsonPropertyName("identityCheck")]
    [System.ComponentModel.Description("Whether or not an identity check is required for PHSI")]
    public bool? IdentityCheck { get; set; }

	
    /// <summary>
    /// Whether or not a physical check is required for PHSI
    /// </summary
    [Attr]
    [JsonPropertyName("physicalCheck")]
    [System.ComponentModel.Description("Whether or not a physical check is required for PHSI")]
    public bool? PhysicalCheck { get; set; }

	}


