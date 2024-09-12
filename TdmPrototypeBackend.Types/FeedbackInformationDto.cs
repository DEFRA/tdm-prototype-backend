
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Feedback information from control
    /// </summary>
public partial class FeedbackInformationDto  {


        /// <summary>
        /// Type of authority
        /// </summary>
        [Attr]
        [JsonProperty("authorityType", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorityType { get; set; }
    
        /// <summary>
        /// Did the consignment arrive
        /// </summary>
        [Attr]
        [JsonProperty("consignmentArrival", NullValueHandling = NullValueHandling.Ignore)]
        public bool ConsignmentArrival { get; set; }
    
        /// <summary>
        /// Does the consignment conform
        /// </summary>
        [Attr]
        [JsonProperty("consignmentConformity", NullValueHandling = NullValueHandling.Ignore)]
        public bool ConsignmentConformity { get; set; }
    
        /// <summary>
        /// Reason for consignment not arriving at the entry point
        /// </summary>
        [Attr]
        [JsonProperty("consignmentNoArrivalReason", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsignmentNoArrivalReason { get; set; }
    
        /// <summary>
        /// Date of consignment destruction
        /// </summary>
        [Attr]
        [JsonProperty("destructionDate", NullValueHandling = NullValueHandling.Ignore)]
        public string DestructionDate { get; set; }
    
}


