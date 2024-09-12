
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Seal container details
    /// </summary>
public partial class SealContainerDto  {


        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("sealNumber")]
        public string SealNumber { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("containerNumber")]
        public string ContainerNumber { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("officialSeal")]
        public bool OfficialSeal { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("resealedSealNumber")]
        public string ResealedSealNumber { get; set; }
    
}


