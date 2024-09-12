
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Approved Establishment details
    /// </summary>
public partial class ApprovedEstablishmentDto  {


        /// <summary>
        /// ID
        /// </summary>
        [Attr]
        [JsonPropertyName("id")]
        public string Id { get; set; }
    
        /// <summary>
        /// Name of approved establishment
        /// </summary>
        [Attr]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    
        /// <summary>
        /// Country of approved establishment
        /// </summary>
        [Attr]
        [JsonPropertyName("country")]
        public string Country { get; set; }
    
        /// <summary>
        /// Types of approved establishment
        /// </summary>
        [Attr]
        [JsonPropertyName("types")]
        public string[][] Types { get; set; }
    
        /// <summary>
        /// Approval number
        /// </summary>
        [Attr]
        [JsonPropertyName("approvalNumber")]
        public string ApprovalNumber { get; set; }
    
        /// <summary>
        /// Section of approved establishment
        /// </summary>
        [Attr]
        [JsonPropertyName("section")]
        public string Section { get; set; }
    
}


