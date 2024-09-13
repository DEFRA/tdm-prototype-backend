
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// 
    /// </summary>
     [Resource] 
    public partial class IpaffsNotification  : CustomStringMongoIdentifiable{

        // This field is used by the jsonapi-consumer to control the correct casing in the type field
        public string Type { get; set; } = "IpaffsNotification";
    

        /// <summary>
        /// The IPAFFS ID number for this notification.
        /// </summary>
        [Attr]
        [JsonPropertyName("id")]
        public int IpaffsId { get; set; }
    
        /// <summary>
        /// The etag for this notification.
        /// </summary>
        [Attr]
        [JsonPropertyName("etag")]
        public string Etag { get; set; }
    
        /// <summary>
        /// List of external references, which relate to downstream services
        /// </summary>
        [Attr]
        [JsonPropertyName("externalReferences")]
        public IpaffsExternalReference[] ExternalReferences { get; set; }
    
        /// <summary>
        /// Reference number of the notification
        /// </summary>
        [Attr]
        [JsonPropertyName("referenceNumber")]
        public string ReferenceNumber { get; set; }
    
        /// <summary>
        /// Current version of the notification
        /// </summary>
        [Attr]
        [JsonPropertyName("version")]
        public int Version { get; set; }
    
        /// <summary>
        /// Date when the notification was last updated.
        /// </summary>
        [Attr]
        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }
    
        /// <summary>
        /// User entity whose update was last
        /// </summary>
        [Attr]
        [JsonPropertyName("lastUpdatedBy")]
        public IpaffsUserInformation LastUpdatedBy { get; set; }
    
        /// <summary>
        /// The Type of notification that has been submitted
        /// </summary>
        [Attr]
        [JsonPropertyName("type")]
        public IpaffsTypeEnum IpaffsType { get; set; }
    
        /// <summary>
        /// Reference number of notification that was replaced by this one
        /// </summary>
        [Attr]
        [JsonPropertyName("replaces")]
        public string Replaces { get; set; }
    
        /// <summary>
        /// Reference number of notification that replaced this one
        /// </summary>
        [Attr]
        [JsonPropertyName("replacedBy")]
        public string ReplacedBy { get; set; }
    
        /// <summary>
        /// Current status of the notification. When created by an importer, the notification has the status &#x27;SUBMITTED&#x27;. Before submission of the notification it has the status &#x27;DRAFT&#x27;. When the BIP starts validation of the notification it has the status &#x27;IN PROGRESS&#x27; Once the BIP validates the notification, it gets the status &#x27;VALIDATED&#x27;. &#x27;AMEND&#x27; is set when the Part-1 user is modifying the notification. &#x27;MODIFY&#x27; is set when Part-2 user is modifying the notification. Replaced - When the notification is replaced by another notification. Rejected - Notification moves to Rejected status when rejected by a Part-2 user. 
        /// </summary>
        [Attr]
        [JsonPropertyName("status")]
        public IpaffsStatusEnum Status { get; set; }
    
        /// <summary>
        /// Present if the consignment has been split
        /// </summary>
        [Attr]
        [JsonPropertyName("splitConsignment")]
        public IpaffsSplitConsignment SplitConsignment { get; set; }
    
        /// <summary>
        /// Is this notification a child of a split consignment?
        /// </summary>
        [Attr]
        [JsonPropertyName("childNotification")]
        public bool ChildNotification { get; set; }
    
        /// <summary>
        /// Result of risk assessment by the risk scorer
        /// </summary>
        [Attr]
        [JsonPropertyName("riskAssessment")]
        public IpaffsRiskAssessmentResult RiskAssessment { get; set; }
    
        /// <summary>
        /// Details of the risk categorisation level for a notification
        /// </summary>
        [Attr]
        [JsonPropertyName("journeyRiskCategorisation")]
        public IpaffsJourneyRiskCategorisationResult JourneyRiskCategorisation { get; set; }
    
        /// <summary>
        /// Is this notification a high risk notification from the EU/EEA?
        /// </summary>
        [Attr]
        [JsonPropertyName("isHighRiskEuImport")]
        public bool IsHighRiskEuImport { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("partOne")]
        public IpaffsPartOne PartOne { get; set; }
    
        /// <summary>
        /// Information about the user who set the decision in Part 2
        /// </summary>
        [Attr]
        [JsonPropertyName("decisionBy")]
        public IpaffsUserInformation DecisionBy { get; set; }
    
        /// <summary>
        /// Date when the notification was validated or rejected
        /// </summary>
        [Attr]
        [JsonPropertyName("decisionDate")]
        public string DecisionDate { get; set; }
    
        /// <summary>
        /// Part of the notification which contains information filled by inspector at BIP/DPE
        /// </summary>
        [Attr]
        [JsonPropertyName("partTwo")]
        public IpaffsPartTwo PartTwo { get; set; }
    
        /// <summary>
        /// Part of the notification which contains information filled by LVU if control of consignment is needed.
        /// </summary>
        [Attr]
        [JsonPropertyName("partThree")]
        public IpaffsPartThree PartThree { get; set; }
    
        /// <summary>
        /// Official veterinarian
        /// </summary>
        [Attr]
        [JsonPropertyName("officialVeterinarian")]
        public string OfficialVeterinarian { get; set; }
    
        /// <summary>
        /// Validation messages for whole notification
        /// </summary>
        [Attr]
        [JsonPropertyName("consignmentValidation")]
        public IpaffsValidationMessageCode[] ConsignmentValidations { get; set; }
    
        /// <summary>
        /// Organisation id which the agent user belongs to, stored against each notification which has been raised on behalf of another organisation
        /// </summary>
        [Attr]
        [JsonPropertyName("agencyOrganisationId")]
        public string AgencyOrganisationId { get; set; }
    
        /// <summary>
        /// Date and Time when risk decision was locked
        /// </summary>
        [Attr]
        [JsonPropertyName("riskDecisionLockingTime")]
        public string RiskDecisionLockingTime { get; set; }
    
        /// <summary>
        /// is the risk decision locked?
        /// </summary>
        [Attr]
        [JsonPropertyName("isRiskDecisionLocked")]
        public bool IsRiskDecisionLocked { get; set; }
    
        /// <summary>
        /// Boolean flag that indicates whether a bulk upload is in progress
        /// </summary>
        [Attr]
        [JsonPropertyName("isBulkUploadInProgress")]
        public bool IsBulkUploadInProgress { get; set; }
    
        /// <summary>
        /// Request UUID to trace bulk upload
        /// </summary>
        [Attr]
        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }
    
        /// <summary>
        /// Have all commodities been matched with corresponding CDS declaration(s)
        /// </summary>
        [Attr]
        [JsonPropertyName("isCdsFullMatched")]
        public bool IsCdsFullMatched { get; set; }
    
        /// <summary>
        /// The version of the ched type the notification was created with
        /// </summary>
        [Attr]
        [JsonPropertyName("chedTypeVersion")]
        public int ChedTypeVersion { get; set; }
    
        /// <summary>
        /// Indicates whether a CHED has been matched with a GVMS GMR via DMP
        /// </summary>
        [Attr]
        [JsonPropertyName("isGMRMatched")]
        public bool IsGMRMatched { get; set; }
    
}

