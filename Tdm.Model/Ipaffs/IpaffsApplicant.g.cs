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


namespace Tdm.Model.Ipaffs;

/// <summary>
/// Laboratory tests information details and information about laboratory that did the test
/// </summary>
public partial class IpaffsApplicant  //
{


    /// <summary>
    /// Name of laboratory
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Name of laboratory")]
    public string? Laboratory { get; set; }

	
    /// <summary>
    /// Laboratory address
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Laboratory address")]
    public string? LaboratoryAddress { get; set; }

	
    /// <summary>
    /// Laboratory identification
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Laboratory identification")]
    public string? LaboratoryIdentification { get; set; }

	
    /// <summary>
    /// Laboratory phone number
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Laboratory phone number")]
    public string? LaboratoryPhoneNumber { get; set; }

	
    /// <summary>
    /// Laboratory email
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Laboratory email")]
    public string? LaboratoryEmail { get; set; }

	
    /// <summary>
    /// Sample batch number
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Sample batch number")]
    public string? SampleBatchNumber { get; set; }

	
    /// <summary>
    /// Type of analysis
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Type of analysis")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsApplicantAnalysisTypeEnum? AnalysisType { get; set; }

	
    /// <summary>
    /// Number of samples analysed
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Number of samples analysed")]
    public int? NumberOfSamples { get; set; }

	
    /// <summary>
    /// Type of sample
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Type of sample")]
    public string? SampleType { get; set; }

	
    /// <summary>
    /// Conservation of sample
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Conservation of sample")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsApplicantConservationOfSampleEnum? ConservationOfSample { get; set; }

	
    /// <summary>
    /// inspector
    /// </summary
    [Attr]
    [System.ComponentModel.Description("inspector")]
    public IpaffsInspector? Inspector { get; set; }

	
    /// <summary>
    /// Date the sample is taken
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Date the sample is taken")]
    public DateOnly? SampleDate { get; set; }

	
    /// <summary>
    /// Time the sample is taken
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Time the sample is taken")]
    public TimeOnly? SampleTime { get; set; }

	}


