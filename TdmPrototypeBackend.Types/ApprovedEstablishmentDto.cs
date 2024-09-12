
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Approved Establishment details
    /// </summary>
public partial class ApprovedEstablishmentDto  {


        /// <summary>
        /// ID
        /// </summary>
        [Attr]
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        /// <summary>
        /// Name of approved establishment
        /// </summary>
        [Attr]
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        /// <summary>
        /// Country of approved establishment
        /// </summary>
        [Attr]
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
    
        /// <summary>
        /// Types of approved establishment
        /// </summary>
        [Attr]
        [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
        public string[][] Types { get; set; }
    
        /// <summary>
        /// Approval number
        /// </summary>
        [Attr]
        [JsonProperty("approvalNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string ApprovalNumber { get; set; }
    
        /// <summary>
        /// Section of approved establishment
        /// </summary>
        [Attr]
        [JsonProperty("section", NullValueHandling = NullValueHandling.Ignore)]
        public string Section { get; set; }
    
}


