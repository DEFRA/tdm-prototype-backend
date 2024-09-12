
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// consignment checks
    /// </summary>
public partial class ConsignmentCheckDto  {


        /// <summary>
        /// Does it conform EU standards
        /// </summary>
        [Attr]
        [JsonPropertyName("euStandard")]
        public string EuStandard { get; set; }
    
        /// <summary>
        /// Result of additional guarantees
        /// </summary>
        [Attr]
        [JsonPropertyName("additionalGuarantees")]
        public string AdditionalGuarantees { get; set; }
    
        /// <summary>
        /// Result of document check
        /// </summary>
        [Attr]
        [JsonPropertyName("documentCheckResult")]
        public string DocumentCheckResult { get; set; }
    
        /// <summary>
        /// Result of national requirements check
        /// </summary>
        [Attr]
        [JsonPropertyName("nationalRequirements")]
        public string NationalRequirements { get; set; }
    
        /// <summary>
        /// Was identity check done
        /// </summary>
        [Attr]
        [JsonPropertyName("identityCheckDone")]
        public bool IdentityCheckDone { get; set; }
    
        /// <summary>
        /// Type of identity check performed
        /// </summary>
        [Attr]
        [JsonPropertyName("identityCheckType")]
        public string IdentityCheckType { get; set; }
    
        /// <summary>
        /// Result of identity check
        /// </summary>
        [Attr]
        [JsonPropertyName("identityCheckResult")]
        public string IdentityCheckResult { get; set; }
    
        /// <summary>
        /// What was the reason for skipping identity check
        /// </summary>
        [Attr]
        [JsonPropertyName("identityCheckNotDoneReason")]
        public string IdentityCheckNotDoneReason { get; set; }
    
        /// <summary>
        /// Was physical check done
        /// </summary>
        [Attr]
        [JsonPropertyName("physicalCheckDone")]
        public bool PhysicalCheckDone { get; set; }
    
        /// <summary>
        /// Result of physical check
        /// </summary>
        [Attr]
        [JsonPropertyName("physicalCheckResult")]
        public string PhysicalCheckResult { get; set; }
    
        /// <summary>
        /// What was the reason for skipping physical check
        /// </summary>
        [Attr]
        [JsonPropertyName("physicalCheckNotDoneReason")]
        public string PhysicalCheckNotDoneReason { get; set; }
    
        /// <summary>
        /// Other reason to not do physical check
        /// </summary>
        [Attr]
        [JsonPropertyName("physicalCheckOtherText")]
        public string PhysicalCheckOtherText { get; set; }
    
        /// <summary>
        /// Welfare check
        /// </summary>
        [Attr]
        [JsonPropertyName("welfareCheck")]
        public string WelfareCheck { get; set; }
    
        /// <summary>
        /// Number of animals checked
        /// </summary>
        [Attr]
        [JsonPropertyName("numberOfAnimalsChecked")]
        public int NumberOfAnimalsChecked { get; set; }
    
        /// <summary>
        /// Were laboratory tests done
        /// </summary>
        [Attr]
        [JsonPropertyName("laboratoryCheckDone")]
        public bool LaboratoryCheckDone { get; set; }
    
        /// <summary>
        /// Result of laboratory tests
        /// </summary>
        [Attr]
        [JsonPropertyName("laboratoryCheckResult")]
        public string LaboratoryCheckResult { get; set; }
    
}


