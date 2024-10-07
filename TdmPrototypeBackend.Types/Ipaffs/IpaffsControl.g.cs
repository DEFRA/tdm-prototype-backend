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
/// Details of Control (Part 3)
/// </summary>
public partial class IpaffsControl  //
{


    /// <summary>
    /// Feedback information of Control
    /// </summary
    [Attr]
    [JsonPropertyName("feedbackInformation")]
    public IpaffsFeedbackInformation? FeedbackInformation { get; set; }

	
    /// <summary>
    /// Details on re-export
    /// </summary
    [Attr]
    [JsonPropertyName("detailsOnReExport")]
    public IpaffsDetailsOnReExport? DetailsOnReExport { get; set; }

	
    /// <summary>
    /// Official inspector
    /// </summary
    [Attr]
    [JsonPropertyName("officialInspector")]
    public IpaffsOfficialInspector? OfficialInspector { get; set; }

	
    /// <summary>
    /// Is the consignment leaving UK borders?
    /// </summary
    [Attr]
    [JsonPropertyName("consignmentLeave")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsControlConsignmentLeaveEnum? ConsignmentLeave { get; set; }

	}


