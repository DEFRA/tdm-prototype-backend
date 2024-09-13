
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Information about not acceptable reason
    /// </summary>
public partial class IpaffsChedppNotAcceptableReason  {


        /// <summary>
        /// reason for refusal
        /// </summary>
        [Attr]
        [JsonPropertyName("reason")]
        public IpaffsReasonEnum Reason { get; set; }
    
        /// <summary>
        /// commodity or package
        /// </summary>
        [Attr]
        [JsonPropertyName("commodityOrPackage")]
        public IpaffsCommodityOrPackageEnum CommodityOrPackage { get; set; }
    
}


