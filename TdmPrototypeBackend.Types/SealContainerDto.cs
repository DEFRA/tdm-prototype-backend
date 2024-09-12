
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Seal container details
    /// </summary>
public partial class SealContainerDto  {


        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonProperty("sealNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string SealNumber { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonProperty("containerNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string ContainerNumber { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonProperty("officialSeal", NullValueHandling = NullValueHandling.Ignore)]
        public bool OfficialSeal { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonProperty("resealedSealNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string ResealedSealNumber { get; set; }
    
}


