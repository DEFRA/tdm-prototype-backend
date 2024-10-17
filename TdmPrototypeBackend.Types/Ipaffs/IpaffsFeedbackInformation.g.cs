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
/// Feedback information from control
/// </summary>
public partial class IpaffsFeedbackInformation  //
{


    /// <summary>
    /// Type of authority
    /// </summary
    [Attr]
    [JsonPropertyName("authorityType")]
    [System.ComponentModel.Description("Type of authority")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsFeedbackInformationAuthorityTypeEnum? AuthorityType { get; set; }

	
    /// <summary>
    /// Did the consignment arrive
    /// </summary
    [Attr]
    [JsonPropertyName("consignmentArrival")]
    [System.ComponentModel.Description("Did the consignment arrive")]
    public bool? ConsignmentArrival { get; set; }

	
    /// <summary>
    /// Does the consignment conform
    /// </summary
    [Attr]
    [JsonPropertyName("consignmentConformity")]
    [System.ComponentModel.Description("Does the consignment conform")]
    public bool? ConsignmentConformity { get; set; }

	
    /// <summary>
    /// Reason for consignment not arriving at the entry point
    /// </summary
    [Attr]
    [JsonPropertyName("consignmentNoArrivalReason")]
    [System.ComponentModel.Description("Reason for consignment not arriving at the entry point")]
    public string? ConsignmentNoArrivalReason { get; set; }

	
    /// <summary>
    /// Date of consignment destruction
    /// </summary
    [Attr]
    [JsonPropertyName("destructionDate")]
    [System.ComponentModel.Description("Date of consignment destruction")]
    public string? DestructionDate { get; set; }

	}


