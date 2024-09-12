
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// 
    /// </summary>
     [Resource] 
    public partial class IpaffsNotification  : CustomStringMongoIdentifiable{

        // This field is used by the jsonapi-consumer to control the correct casing in the type field
        public string Type { get; set; } = "notification-schema";
    

        // /// <summary>
        // /// The IPAFFS ID number for this notification.
        // /// </summary>
        // [Attr]
        // [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        // public int Id { get; set; }
    
        /// <summary>
        /// The etag for this notification.
        /// </summary>
        [Attr]
        [JsonProperty("etag", NullValueHandling = NullValueHandling.Ignore)]
        public string Etag { get; set; }
    
        /// <summary>
        /// List of external references, which relate to downstream services
        /// </summary>
        [Attr]
        [JsonProperty("externalReferences", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalReferenceDto[] ExternalReferences { get; set; }
    
        /// <summary>
        /// Reference number of the notification
        /// </summary>
        [Attr]
        [JsonProperty("referenceNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceNumber { get; set; }
    
        /// <summary>
        /// Current version of the notification
        /// </summary>
        [Attr]
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int Version { get; set; }
    
        /// <summary>
        /// Date when the notification was last updated.
        /// </summary>
        [Attr]
        [JsonProperty("lastUpdated", NullValueHandling = NullValueHandling.Ignore)]
        public string LastUpdated { get; set; }
    
        /// <summary>
        /// User entity whose update was last
        /// </summary>
        [Attr]
        [JsonProperty("lastUpdatedBy", NullValueHandling = NullValueHandling.Ignore)]
        public UserInformationDto LastUpdatedBy { get; set; }
    
        /// <summary>
        /// The Type of notification that has been submitted
        /// </summary>
        [Attr]
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string _Type { get; set; }
    
        /// <summary>
        /// Reference number of notification that was replaced by this one
        /// </summary>
        [Attr]
        [JsonProperty("replaces", NullValueHandling = NullValueHandling.Ignore)]
        public string Replaces { get; set; }
    
        /// <summary>
        /// Reference number of notification that replaced this one
        /// </summary>
        [Attr]
        [JsonProperty("replacedBy", NullValueHandling = NullValueHandling.Ignore)]
        public string ReplacedBy { get; set; }
    
        /// <summary>
        /// Current status of the notification. When created by an importer, the notification has the status &#x27;SUBMITTED&#x27;. Before submission of the notification it has the status &#x27;DRAFT&#x27;. When the BIP starts validation of the notification it has the status &#x27;IN PROGRESS&#x27; Once the BIP validates the notification, it gets the status &#x27;VALIDATED&#x27;. &#x27;AMEND&#x27; is set when the Part-1 user is modifying the notification. &#x27;MODIFY&#x27; is set when Part-2 user is modifying the notification. Replaced - When the notification is replaced by another notification. Rejected - Notification moves to Rejected status when rejected by a Part-2 user. 
        /// </summary>
        [Attr]
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    
        /// <summary>
        /// Present if the consignment has been split
        /// </summary>
        [Attr]
        [JsonProperty("splitConsignment", NullValueHandling = NullValueHandling.Ignore)]
        public object SplitConsignment { get; set; }
    
        /// <summary>
        /// Is this notification a child of a split consignment?
        /// </summary>
        [Attr]
        [JsonProperty("childNotification", NullValueHandling = NullValueHandling.Ignore)]
        public bool ChildNotification { get; set; }
    
        /// <summary>
        /// Result of risk assessment by the risk scorer
        /// </summary>
        [Attr]
        [JsonProperty("riskAssessment", NullValueHandling = NullValueHandling.Ignore)]
        public RiskAssessmentResultDto RiskAssessment { get; set; }
    
        /// <summary>
        /// Details of the risk categorisation level for a notification
        /// </summary>
        [Attr]
        [JsonProperty("journeyRiskCategorisation", NullValueHandling = NullValueHandling.Ignore)]
        public JourneyRiskCategorisationResultDto JourneyRiskCategorisation { get; set; }
    
        /// <summary>
        /// Is this notification a high risk notification from the EU/EEA?
        /// </summary>
        [Attr]
        [JsonProperty("isHighRiskEuImport", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsHighRiskEuImport { get; set; }
    
        /// <summary>
        /// Information about the user who set the decision in Part 2
        /// </summary>
        [Attr]
        [JsonProperty("decisionBy", NullValueHandling = NullValueHandling.Ignore)]
        public UserInformationDto DecisionBy { get; set; }
    
        /// <summary>
        /// Date when the notification was validated or rejected
        /// </summary>
        [Attr]
        [JsonProperty("decisionDate", NullValueHandling = NullValueHandling.Ignore)]
        public string DecisionDate { get; set; }
    
        /// <summary>
        /// Part of the notification which contains information filled by inspector at BIP/DPE
        /// </summary>
        [Attr]
        [JsonProperty("partTwo", NullValueHandling = NullValueHandling.Ignore)]
        public PartTwoDto PartTwo { get; set; }
    
        /// <summary>
        /// Part of the notification which contains information filled by LVU if control of consignment is needed.
        /// </summary>
        [Attr]
        [JsonProperty("partThree", NullValueHandling = NullValueHandling.Ignore)]
        public PartThreeDto PartThree { get; set; }
    
        /// <summary>
        /// Official veterinarian
        /// </summary>
        [Attr]
        [JsonProperty("officialVeterinarian", NullValueHandling = NullValueHandling.Ignore)]
        public string OfficialVeterinarian { get; set; }
    
        /// <summary>
        /// Validation messages for whole notification
        /// </summary>
        [Attr]
        [JsonProperty("consignmentValidation", NullValueHandling = NullValueHandling.Ignore)]
        public ValidationMessageCodeDto[] ConsignmentValidation { get; set; }
    
        /// <summary>
        /// Organisation id which the agent user belongs to, stored against each notification which has been raised on behalf of another organisation
        /// </summary>
        [Attr]
        [JsonProperty("agencyOrganisationId", NullValueHandling = NullValueHandling.Ignore)]
        public string AgencyOrganisationId { get; set; }
    
        /// <summary>
        /// Date and Time when risk decision was locked
        /// </summary>
        [Attr]
        [JsonProperty("riskDecisionLockingTime", NullValueHandling = NullValueHandling.Ignore)]
        public string RiskDecisionLockingTime { get; set; }
    
        /// <summary>
        /// is the risk decision locked?
        /// </summary>
        [Attr]
        [JsonProperty("isRiskDecisionLocked", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsRiskDecisionLocked { get; set; }
    
        /// <summary>
        /// Boolean flag that indicates whether a bulk upload is in progress
        /// </summary>
        [Attr]
        [JsonProperty("isBulkUploadInProgress", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsBulkUploadInProgress { get; set; }
    
        /// <summary>
        /// Request UUID to trace bulk upload
        /// </summary>
        [Attr]
        [JsonProperty("requestId", NullValueHandling = NullValueHandling.Ignore)]
        public string RequestId { get; set; }
    
        /// <summary>
        /// Have all commodities been matched with corresponding CDS declaration(s)
        /// </summary>
        [Attr]
        [JsonProperty("isCdsFullMatched", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCdsFullMatched { get; set; }
    
        /// <summary>
        /// The version of the ched type the notification was created with
        /// </summary>
        [Attr]
        [JsonProperty("chedTypeVersion", NullValueHandling = NullValueHandling.Ignore)]
        public int ChedTypeVersion { get; set; }
    
        /// <summary>
        /// Indicates whether a CHED has been matched with a GVMS GMR via DMP
        /// </summary>
        [Attr]
        [JsonProperty("isGMRMatched", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsGMRMatched { get; set; }
    
}