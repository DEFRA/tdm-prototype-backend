
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// consignment checks
    /// </summary>
public partial class ConsignmentCheckDto  {


        /// <summary>
        /// Does it conform EU standards
        /// </summary>
        [Attr]
        [JsonProperty("euStandard", NullValueHandling = NullValueHandling.Ignore)]
        public string EuStandard { get; set; }
    
        /// <summary>
        /// Result of additional guarantees
        /// </summary>
        [Attr]
        [JsonProperty("additionalGuarantees", NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalGuarantees { get; set; }
    
        /// <summary>
        /// Result of document check
        /// </summary>
        [Attr]
        [JsonProperty("documentCheckResult", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentCheckResult { get; set; }
    
        /// <summary>
        /// Result of national requirements check
        /// </summary>
        [Attr]
        [JsonProperty("nationalRequirements", NullValueHandling = NullValueHandling.Ignore)]
        public string NationalRequirements { get; set; }
    
        /// <summary>
        /// Was identity check done
        /// </summary>
        [Attr]
        [JsonProperty("identityCheckDone", NullValueHandling = NullValueHandling.Ignore)]
        public bool IdentityCheckDone { get; set; }
    
        /// <summary>
        /// Type of identity check performed
        /// </summary>
        [Attr]
        [JsonProperty("identityCheckType", NullValueHandling = NullValueHandling.Ignore)]
        public string IdentityCheckType { get; set; }
    
        /// <summary>
        /// Result of identity check
        /// </summary>
        [Attr]
        [JsonProperty("identityCheckResult", NullValueHandling = NullValueHandling.Ignore)]
        public string IdentityCheckResult { get; set; }
    
        /// <summary>
        /// What was the reason for skipping identity check
        /// </summary>
        [Attr]
        [JsonProperty("identityCheckNotDoneReason", NullValueHandling = NullValueHandling.Ignore)]
        public string IdentityCheckNotDoneReason { get; set; }
    
        /// <summary>
        /// Was physical check done
        /// </summary>
        [Attr]
        [JsonProperty("physicalCheckDone", NullValueHandling = NullValueHandling.Ignore)]
        public bool PhysicalCheckDone { get; set; }
    
        /// <summary>
        /// Result of physical check
        /// </summary>
        [Attr]
        [JsonProperty("physicalCheckResult", NullValueHandling = NullValueHandling.Ignore)]
        public string PhysicalCheckResult { get; set; }
    
        /// <summary>
        /// What was the reason for skipping physical check
        /// </summary>
        [Attr]
        [JsonProperty("physicalCheckNotDoneReason", NullValueHandling = NullValueHandling.Ignore)]
        public string PhysicalCheckNotDoneReason { get; set; }
    
        /// <summary>
        /// Other reason to not do physical check
        /// </summary>
        [Attr]
        [JsonProperty("physicalCheckOtherText", NullValueHandling = NullValueHandling.Ignore)]
        public string PhysicalCheckOtherText { get; set; }
    
        /// <summary>
        /// Welfare check
        /// </summary>
        [Attr]
        [JsonProperty("welfareCheck", NullValueHandling = NullValueHandling.Ignore)]
        public string WelfareCheck { get; set; }
    
        /// <summary>
        /// Number of animals checked
        /// </summary>
        [Attr]
        [JsonProperty("numberOfAnimalsChecked", NullValueHandling = NullValueHandling.Ignore)]
        public int NumberOfAnimalsChecked { get; set; }
    
        /// <summary>
        /// Were laboratory tests done
        /// </summary>
        [Attr]
        [JsonProperty("laboratoryCheckDone", NullValueHandling = NullValueHandling.Ignore)]
        public bool LaboratoryCheckDone { get; set; }
    
        /// <summary>
        /// Result of laboratory tests
        /// </summary>
        [Attr]
        [JsonProperty("laboratoryCheckResult", NullValueHandling = NullValueHandling.Ignore)]
        public string LaboratoryCheckResult { get; set; }
    
}


