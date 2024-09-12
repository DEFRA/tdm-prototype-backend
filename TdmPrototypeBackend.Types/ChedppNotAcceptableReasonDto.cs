
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Information about not acceptable reason
    /// </summary>
public partial class ChedppNotAcceptableReasonDto  {


        /// <summary>
        /// reason for refusal
        /// </summary>
        [Attr]
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }
    
        /// <summary>
        /// commodity or package
        /// </summary>
        [Attr]
        [JsonProperty("commodityOrPackage", NullValueHandling = NullValueHandling.Ignore)]
        public string CommodityOrPackage { get; set; }
    
}


