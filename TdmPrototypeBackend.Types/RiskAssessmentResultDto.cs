
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Result of risk assessment by the risk scorer
    /// </summary>
public partial class RiskAssessmentResultDto  {


        /// <summary>
        /// List of risk assessed commodities
        /// </summary>
        [Attr]
        [JsonPropertyName("commodityResults")]
        public CommodityRiskResultDto[] CommodityResults { get; set; }
    
        /// <summary>
        /// Date and time of assessment
        /// </summary>
        [Attr]
        [JsonPropertyName("assessmentDateTime")]
        public string AssessmentDateTime { get; set; }
    
}


