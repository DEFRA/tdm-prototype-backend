
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Result of risk assessment by the risk scorer
    /// </summary>
public partial class RiskAssessmentResultDto  {


        /// <summary>
        /// List of risk assessed commodities
        /// </summary>
        [Attr]
        [JsonProperty("commodityResults", NullValueHandling = NullValueHandling.Ignore)]
        public CommodityRiskResultDto[] CommodityResults { get; set; }
    
        /// <summary>
        /// Date and time of assessment
        /// </summary>
        [Attr]
        [JsonProperty("assessmentDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public string AssessmentDateTime { get; set; }
    
}


