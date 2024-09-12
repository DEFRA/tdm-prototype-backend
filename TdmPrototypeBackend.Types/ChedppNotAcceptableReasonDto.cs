
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Information about not acceptable reason
    /// </summary>
public partial class ChedppNotAcceptableReasonDto  {


        /// <summary>
        /// reason for refusal
        /// </summary>
        [Attr]
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    
        /// <summary>
        /// commodity or package
        /// </summary>
        [Attr]
        [JsonPropertyName("commodityOrPackage")]
        public string CommodityOrPackage { get; set; }
    
}


