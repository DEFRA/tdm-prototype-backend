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
/// Tests results corresponding to LaboratoryTests
/// </summary>
public partial class IpaffsLaboratoryTestResult  //
{


    /// <summary>
    /// When sample was used
    /// </summary
    [Attr]
    [JsonPropertyName("sampleUseByDate")]
    public string? SampleUseByDate { get; set; }

	
    /// <summary>
    /// When it was released
    /// </summary
    [Attr]
    [JsonPropertyName("releasedDate")]
    public string? ReleasedDate { get; set; }

	
    /// <summary>
    /// Laboratory test method
    /// </summary
    [Attr]
    [JsonPropertyName("laboratoryTestMethod")]
    public string? LaboratoryTestMethod { get; set; }

	
    /// <summary>
    /// Result of test
    /// </summary
    [Attr]
    [JsonPropertyName("results")]
    public string? Results { get; set; }

	
    /// <summary>
    /// Conclusion of laboratory test
    /// </summary
    [Attr]
    [JsonPropertyName("conclusion")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsLaboratoryTestResultConclusionEnum? Conclusion { get; set; }

	
    /// <summary>
    /// Date of lab test created in IPAFFS
    /// </summary
    [Attr]
    [JsonPropertyName("labTestCreatedDate")]
    public string? LabTestCreatedDate { get; set; }

	}


