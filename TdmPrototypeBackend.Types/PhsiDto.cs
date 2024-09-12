
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// PHSI Decision Breakdown
    /// </summary>
public partial class PhsiDto  {


        /// <summary>
        /// Whether or not a documentary check is required for PHSI
        /// </summary>
        [Attr]
        [JsonPropertyName("documentCheck")]
        public bool DocumentCheck { get; set; }
    
        /// <summary>
        /// Whether or not an identity check is required for PHSI
        /// </summary>
        [Attr]
        [JsonPropertyName("identityCheck")]
        public bool IdentityCheck { get; set; }
    
        /// <summary>
        /// Whether or not a physical check is required for PHSI
        /// </summary>
        [Attr]
        [JsonPropertyName("physicalCheck")]
        public bool PhysicalCheck { get; set; }
    
}


