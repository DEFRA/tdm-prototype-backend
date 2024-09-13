
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// 
    /// </summary>
public partial class IpaffsCommodityChecks  {


        /// <summary>
        /// UUID used to match the commodityChecks to the commodityComplement
        /// </summary>
        [Attr]
        [JsonPropertyName("uniqueComplementId")]
        public string UniqueComplementId { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("checks")]
        public IpaffsInspectionCheck[] Checks { get; set; }
    
        /// <summary>
        /// Manually entered validity period, allowed if risk decision is INSPECTION_REQUIRED and HMI check status &#x27;Compliant&#x27; or &#x27;Not inspected&#x27;
        /// </summary>
        [Attr]
        [JsonPropertyName("validityPeriod")]
        public int ValidityPeriod { get; set; }
    
}


