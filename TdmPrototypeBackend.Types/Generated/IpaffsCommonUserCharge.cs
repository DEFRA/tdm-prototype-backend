
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// 
    /// </summary>
public partial class IpaffsCommonUserCharge  {


        /// <summary>
        /// Indicates whether the last applicable change was successfully send over the interface to Trade Charge
        /// </summary>
        [Attr]
        [JsonPropertyName("wasSentToTradeCharge")]
        public bool WasSentToTradeCharge { get; set; }
    
}


