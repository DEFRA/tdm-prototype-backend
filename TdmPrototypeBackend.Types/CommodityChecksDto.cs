
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// 
    /// </summary>
public partial class CommodityChecksDto  {


        /// <summary>
        /// UUID used to match the commodityChecks to the commodityComplement
        /// </summary>
        [Attr]
        [JsonProperty("uniqueComplementId", NullValueHandling = NullValueHandling.Ignore)]
        public string UniqueComplementId { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonProperty("checks", NullValueHandling = NullValueHandling.Ignore)]
        public InspectionCheckDto[] Checks { get; set; }
    
        /// <summary>
        /// Manually entered validity period, allowed if risk decision is INSPECTION_REQUIRED and HMI check status &#x27;Compliant&#x27; or &#x27;Not inspected&#x27;
        /// </summary>
        [Attr]
        [JsonProperty("validityPeriod", NullValueHandling = NullValueHandling.Ignore)]
        public int ValidityPeriod { get; set; }
    
}


