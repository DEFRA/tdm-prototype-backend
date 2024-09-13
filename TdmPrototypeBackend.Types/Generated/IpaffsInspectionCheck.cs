
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// 
    /// </summary>
public partial class IpaffsInspectionCheck  {


        /// <summary>
        /// Type of check
        /// </summary>
        [Attr]
        [JsonPropertyName("type")]
        public IpaffsTypeEnum IpaffsType { get; set; }
    
        /// <summary>
        /// Status of the check
        /// </summary>
        [Attr]
        [JsonPropertyName("status")]
        public IpaffsStatusEnum Status { get; set; }
    
        /// <summary>
        /// Reason for the status if applicable
        /// </summary>
        [Attr]
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    
        /// <summary>
        /// Other reason text when selected reason is &#x27;Other&#x27;
        /// </summary>
        [Attr]
        [JsonPropertyName("otherReason")]
        public string OtherReason { get; set; }
    
        /// <summary>
        /// Has commodity been selected for checks?
        /// </summary>
        [Attr]
        [JsonPropertyName("isSelectedForChecks")]
        public bool IsSelectedForChecks { get; set; }
    
        /// <summary>
        /// Has commodity completed this type of check
        /// </summary>
        [Attr]
        [JsonPropertyName("hasChecksComplete")]
        public bool HasChecksComplete { get; set; }
    
}


