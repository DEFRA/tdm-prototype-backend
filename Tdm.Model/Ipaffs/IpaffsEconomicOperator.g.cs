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
/// An organisation as part of the DEFRA system
/// </summary>
public partial class IpaffsEconomicOperator  //
{


    /// <summary>
    /// The unique identifier of this organisation
    /// </summary
    [Attr]
    [System.ComponentModel.Description("The unique identifier of this organisation")]
    public string? IpaffsId { get; set; }

	
    /// <summary>
    /// Type of organisation
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Type of organisation")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsEconomicOperatorTypeEnum? IpaffsType { get; set; }

	
    /// <summary>
    /// Status of organisation
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Status of organisation")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsEconomicOperatorStatusEnum? Status { get; set; }

	
    /// <summary>
    /// Name of organisation
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Name of organisation")]
    public string? CompanyName { get; set; }

	
    /// <summary>
    /// Individual name
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Individual name")]
    public string? IndividualName { get; set; }

	
    /// <summary>
    /// Address of economic operator
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Address of economic operator")]
    public IpaffsAddress? Address { get; set; }

	
    /// <summary>
    /// Approval Number which identifies an Economic Operator unambiguously per type of organisation per country.
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Approval Number which identifies an Economic Operator unambiguously per type of organisation per country.")]
    public string? ApprovalNumber { get; set; }

	
    /// <summary>
    /// Optional Business General Number, often named Aggregation Code, which identifies an Economic Operator.
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Optional Business General Number, often named Aggregation Code, which identifies an Economic Operator.")]
    public string? OtherIdentifier { get; set; }

	
    /// <summary>
    /// Traces Id of the economic operator generated by IPAFFS
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Traces Id of the economic operator generated by IPAFFS")]
    public int? TracesId { get; set; }

	}


