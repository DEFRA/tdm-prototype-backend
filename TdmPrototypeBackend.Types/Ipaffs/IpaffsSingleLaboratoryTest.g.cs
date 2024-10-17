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
/// Information about single laboratory test
/// </summary>
public partial class IpaffsSingleLaboratoryTest  //
{


    /// <summary>
    /// Commodity code for which lab test was ordered
    /// </summary
    [Attr]
    [JsonPropertyName("commodityCode")]
    [System.ComponentModel.Description("Commodity code for which lab test was ordered")]
    public string? CommodityCode { get; set; }

	
    /// <summary>
    /// Species id of commodity for which lab test was ordered
    /// </summary
    [Attr]
    [JsonPropertyName("speciesID")]
    [System.ComponentModel.Description("Species id of commodity for which lab test was ordered")]
    public int? SpeciesID { get; set; }

	
    /// <summary>
    /// TRACES ID
    /// </summary
    [Attr]
    [JsonPropertyName("tracesID")]
    [System.ComponentModel.Description("TRACES ID")]
    public int? TracesID { get; set; }

	
    /// <summary>
    /// Test name
    /// </summary
    [Attr]
    [JsonPropertyName("testName")]
    [System.ComponentModel.Description("Test name")]
    public string? TestName { get; set; }

	
    /// <summary>
    /// Laboratory tests information details and information about laboratory
    /// </summary
    [Attr]
    [JsonPropertyName("applicant")]
    [System.ComponentModel.Description("Laboratory tests information details and information about laboratory")]
    public IpaffsApplicant? Applicant { get; set; }

	
    /// <summary>
    /// Information about results of test
    /// </summary
    [Attr]
    [JsonPropertyName("laboratoryTestResult")]
    [System.ComponentModel.Description("Information about results of test")]
    public IpaffsLaboratoryTestResult? LaboratoryTestResult { get; set; }

	}


