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
/// 
/// </summary>
public partial class IpaffsCommodityChecks  //
{


    /// <summary>
    /// UUID used to match the commodityChecks to the commodityComplement
    /// </summary
    [Attr]
    [JsonPropertyName("uniqueComplementId")]
    [System.ComponentModel.Description("UUID used to match the commodityChecks to the commodityComplement")]
    public string? UniqueComplementId { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("checks")]
    [System.ComponentModel.Description("")]
    public IpaffsInspectionCheck[]? Checks { get; set; }

	
    /// <summary>
    /// Manually entered validity period, allowed if risk decision is INSPECTION_REQUIRED and HMI check status &#x27;Compliant&#x27; or &#x27;Not inspected&#x27;
    /// </summary
    [Attr]
    [JsonPropertyName("validityPeriod")]
    [System.ComponentModel.Description("Manually entered validity period, allowed if risk decision is INSPECTION_REQUIRED and HMI check status 'Compliant' or 'Not inspected'")]
    public int? ValidityPeriod { get; set; }

	}


