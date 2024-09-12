
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Feedback information from control
    /// </summary>
public partial class FeedbackInformationDto  {


        /// <summary>
        /// Type of authority
        /// </summary>
        [Attr]
        [JsonPropertyName("authorityType")]
        public string AuthorityType { get; set; }
    
        /// <summary>
        /// Did the consignment arrive
        /// </summary>
        [Attr]
        [JsonPropertyName("consignmentArrival")]
        public bool ConsignmentArrival { get; set; }
    
        /// <summary>
        /// Does the consignment conform
        /// </summary>
        [Attr]
        [JsonPropertyName("consignmentConformity")]
        public bool ConsignmentConformity { get; set; }
    
        /// <summary>
        /// Reason for consignment not arriving at the entry point
        /// </summary>
        [Attr]
        [JsonPropertyName("consignmentNoArrivalReason")]
        public string ConsignmentNoArrivalReason { get; set; }
    
        /// <summary>
        /// Date of consignment destruction
        /// </summary>
        [Attr]
        [JsonPropertyName("destructionDate")]
        public string DestructionDate { get; set; }
    
}


