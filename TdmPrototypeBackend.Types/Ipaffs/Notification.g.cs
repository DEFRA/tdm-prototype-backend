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
     [Resource] 
    public partial class Notification  //: CustomStringMongoIdentifiable
{


    /// <summary>
    /// The IPAFFS ID number for this notification.
    /// </summary
    [Attr]
    [JsonPropertyName("id")]
    [System.ComponentModel.Description("The IPAFFS ID number for this notification.")]
    public int? IpaffsId { get; set; }

	
    /// <summary>
    /// The etag for this notification.
    /// </summary
    [Attr]
    [JsonPropertyName("etag")]
    [System.ComponentModel.Description("The etag for this notification.")]
    public string? Etag { get; set; }

	
    /// <summary>
    /// List of external references, which relate to downstream services
    /// </summary
    [Attr]
    [JsonPropertyName("externalReferences")]
    [System.ComponentModel.Description("List of external references, which relate to downstream services")]
    public IpaffsExternalReference[]? ExternalReferences { get; set; }

	
    /// <summary>
    /// Reference number of the notification
    /// </summary
    [Attr]
    [JsonPropertyName("referenceNumber")]
    [System.ComponentModel.Description("Reference number of the notification")]
    [MongoDB.Bson.Serialization.Attributes.BsonIgnore]
    public string? ReferenceNumber { get; set; }

	
    /// <summary>
    /// Current version of the notification
    /// </summary
    [Attr]
    [JsonPropertyName("version")]
    [System.ComponentModel.Description("Current version of the notification")]
    public int? Version { get; set; }

	
    /// <summary>
    /// Date when the notification was last updated.
    /// </summary
    [Attr]
    [JsonPropertyName("lastUpdated")]
    [System.ComponentModel.Description("Date when the notification was last updated.")]
    public DateTime? LastUpdated { get; set; }

	
    /// <summary>
    /// User entity whose update was last
    /// </summary
    [Attr]
    [JsonPropertyName("lastUpdatedBy")]
    [System.ComponentModel.Description("User entity whose update was last")]
    public IpaffsUserInformation? LastUpdatedBy { get; set; }

	
    /// <summary>
    /// The Type of notification that has been submitted
    /// </summary
    [Attr]
    [JsonPropertyName("type")]
    [System.ComponentModel.Description("The Type of notification that has been submitted")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsNotificationTypeEnum? IpaffsType { get; set; }

	
    /// <summary>
    /// Reference number of notification that was replaced by this one
    /// </summary
    [Attr]
    [JsonPropertyName("replaces")]
    [System.ComponentModel.Description("Reference number of notification that was replaced by this one")]
    public string? Replaces { get; set; }

	
    /// <summary>
    /// Reference number of notification that replaced this one
    /// </summary
    [Attr]
    [JsonPropertyName("replacedBy")]
    [System.ComponentModel.Description("Reference number of notification that replaced this one")]
    public string? ReplacedBy { get; set; }

	
    /// <summary>
    /// Current status of the notification. When created by an importer, the notification has the status &#x27;SUBMITTED&#x27;. Before submission of the notification it has the status &#x27;DRAFT&#x27;. When the BIP starts validation of the notification it has the status &#x27;IN PROGRESS&#x27; Once the BIP validates the notification, it gets the status &#x27;VALIDATED&#x27;. &#x27;AMEND&#x27; is set when the Part-1 user is modifying the notification. &#x27;MODIFY&#x27; is set when Part-2 user is modifying the notification. Replaced - When the notification is replaced by another notification. Rejected - Notification moves to Rejected status when rejected by a Part-2 user. 
    /// </summary
    [Attr]
    [JsonPropertyName("status")]
    [System.ComponentModel.Description("Current status of the notification. When created by an importer, the notification has the status 'SUBMITTED'. Before submission of the notification it has the status 'DRAFT'. When the BIP starts validation of the notification it has the status 'IN PROGRESS' Once the BIP validates the notification, it gets the status 'VALIDATED'. 'AMEND' is set when the Part-1 user is modifying the notification. 'MODIFY' is set when Part-2 user is modifying the notification. Replaced - When the notification is replaced by another notification. Rejected - Notification moves to Rejected status when rejected by a Part-2 user. ")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsNotificationStatusEnum? Status { get; set; }

	
    /// <summary>
    /// Present if the consignment has been split
    /// </summary
    [Attr]
    [JsonPropertyName("splitConsignment")]
    [System.ComponentModel.Description("Present if the consignment has been split")]
    public IpaffsSplitConsignment? SplitConsignment { get; set; }

	
    /// <summary>
    /// Is this notification a child of a split consignment?
    /// </summary
    [Attr]
    [JsonPropertyName("childNotification")]
    [System.ComponentModel.Description("Is this notification a child of a split consignment?")]
    public bool? ChildNotification { get; set; }

	
    /// <summary>
    /// Result of risk assessment by the risk scorer
    /// </summary
    [Attr]
    [JsonPropertyName("riskAssessment")]
    [System.ComponentModel.Description("Result of risk assessment by the risk scorer")]
    public IpaffsRiskAssessmentResult? RiskAssessment { get; set; }

	
    /// <summary>
    /// Details of the risk categorisation level for a notification
    /// </summary
    [Attr]
    [JsonPropertyName("journeyRiskCategorisation")]
    [System.ComponentModel.Description("Details of the risk categorisation level for a notification")]
    public IpaffsJourneyRiskCategorisationResult? JourneyRiskCategorisation { get; set; }

	
    /// <summary>
    /// Is this notification a high risk notification from the EU/EEA?
    /// </summary
    [Attr]
    [JsonPropertyName("isHighRiskEuImport")]
    [System.ComponentModel.Description("Is this notification a high risk notification from the EU/EEA?")]
    public bool? IsHighRiskEuImport { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("partOne")]
    [System.ComponentModel.Description("")]
    public IpaffsPartOne? PartOne { get; set; }

	
    /// <summary>
    /// Information about the user who set the decision in Part 2
    /// </summary
    [Attr]
    [JsonPropertyName("decisionBy")]
    [System.ComponentModel.Description("Information about the user who set the decision in Part 2")]
    public IpaffsUserInformation? DecisionBy { get; set; }

	
    /// <summary>
    /// Date when the notification was validated or rejected
    /// </summary
    [Attr]
    [JsonPropertyName("decisionDate")]
    [System.ComponentModel.Description("Date when the notification was validated or rejected")]
    public DateTime? DecisionDate { get; set; }

	
    /// <summary>
    /// Part of the notification which contains information filled by inspector at BIP/DPE
    /// </summary
    [Attr]
    [JsonPropertyName("partTwo")]
    [System.ComponentModel.Description("Part of the notification which contains information filled by inspector at BIP/DPE")]
    public IpaffsPartTwo? PartTwo { get; set; }

	
    /// <summary>
    /// Part of the notification which contains information filled by LVU if control of consignment is needed.
    /// </summary
    [Attr]
    [JsonPropertyName("partThree")]
    [System.ComponentModel.Description("Part of the notification which contains information filled by LVU if control of consignment is needed.")]
    public IpaffsPartThree? PartThree { get; set; }

	
    /// <summary>
    /// Official veterinarian
    /// </summary
    [Attr]
    [JsonPropertyName("officialVeterinarian")]
    [System.ComponentModel.Description("Official veterinarian")]
    public string? OfficialVeterinarian { get; set; }

	
    /// <summary>
    /// Validation messages for whole notification
    /// </summary
    [Attr]
    [JsonPropertyName("consignmentValidation")]
    [System.ComponentModel.Description("Validation messages for whole notification")]
    public IpaffsValidationMessageCode[]? ConsignmentValidations { get; set; }

	
    /// <summary>
    /// Organisation id which the agent user belongs to, stored against each notification which has been raised on behalf of another organisation
    /// </summary
    [Attr]
    [JsonPropertyName("agencyOrganisationId")]
    [System.ComponentModel.Description("Organisation id which the agent user belongs to, stored against each notification which has been raised on behalf of another organisation")]
    public string? AgencyOrganisationId { get; set; }

	
    /// <summary>
    /// Date and Time when risk decision was locked
    /// </summary
    [Attr]
    [JsonPropertyName("riskDecisionLockingTime")]
    [System.ComponentModel.Description("Date and Time when risk decision was locked")]
    public DateTime? RiskDecisionLockingTime { get; set; }

	
    /// <summary>
    /// is the risk decision locked?
    /// </summary
    [Attr]
    [JsonPropertyName("isRiskDecisionLocked")]
    [System.ComponentModel.Description("is the risk decision locked?")]
    public bool? IsRiskDecisionLocked { get; set; }

	
    /// <summary>
    /// Boolean flag that indicates whether a bulk upload is in progress
    /// </summary
    [Attr]
    [JsonPropertyName("isBulkUploadInProgress")]
    [System.ComponentModel.Description("Boolean flag that indicates whether a bulk upload is in progress")]
    public bool? IsBulkUploadInProgress { get; set; }

	
    /// <summary>
    /// Request UUID to trace bulk upload
    /// </summary
    [Attr]
    [JsonPropertyName("requestId")]
    [System.ComponentModel.Description("Request UUID to trace bulk upload")]
    public string? RequestId { get; set; }

	
    /// <summary>
    /// Have all commodities been matched with corresponding CDS declaration(s)
    /// </summary
    [Attr]
    [JsonPropertyName("isCdsFullMatched")]
    [System.ComponentModel.Description("Have all commodities been matched with corresponding CDS declaration(s)")]
    public bool? IsCdsFullMatched { get; set; }

	
    /// <summary>
    /// The version of the ched type the notification was created with
    /// </summary
    [Attr]
    [JsonPropertyName("chedTypeVersion")]
    [System.ComponentModel.Description("The version of the ched type the notification was created with")]
    public int? ChedTypeVersion { get; set; }

	
    /// <summary>
    /// Indicates whether a CHED has been matched with a GVMS GMR via DMP
    /// </summary
    [Attr]
    [JsonPropertyName("isGMRMatched")]
    [System.ComponentModel.Description("Indicates whether a CHED has been matched with a GVMS GMR via DMP")]
    public bool? IsGMRMatched { get; set; }

	}


