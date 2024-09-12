
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// 
    /// </summary>
public partial class InspectionCheckDto  {


        /// <summary>
        /// Type of check
        /// </summary>
        [Attr]
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string _Type { get; set; }
    
        /// <summary>
        /// Status of the check
        /// </summary>
        [Attr]
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
    
        /// <summary>
        /// Reason for the status if applicable
        /// </summary>
        [Attr]
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }
    
        /// <summary>
        /// Other reason text when selected reason is &#x27;Other&#x27;
        /// </summary>
        [Attr]
        [JsonProperty("otherReason", NullValueHandling = NullValueHandling.Ignore)]
        public string OtherReason { get; set; }
    
        /// <summary>
        /// Has commodity been selected for checks?
        /// </summary>
        [Attr]
        [JsonProperty("isSelectedForChecks", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSelectedForChecks { get; set; }
    
        /// <summary>
        /// Has commodity completed this type of check
        /// </summary>
        [Attr]
        [JsonProperty("hasChecksComplete", NullValueHandling = NullValueHandling.Ignore)]
        public bool HasChecksComplete { get; set; }
    
}


