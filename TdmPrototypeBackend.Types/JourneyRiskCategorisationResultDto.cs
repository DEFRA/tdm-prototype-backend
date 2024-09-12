
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Details of the risk categorisation level for a notification
    /// </summary>
public partial class JourneyRiskCategorisationResultDto  {


        /// <summary>
        /// Risk Level is defined using enum values High,Medium,Low
        /// </summary>
        [Attr]
        [JsonPropertyName("riskLevel")]
        public string RiskLevel { get; set; }
    
        /// <summary>
        /// Indicator of whether the risk level was determined by the system or by the user
        /// </summary>
        [Attr]
        [JsonPropertyName("riskLevelMethod")]
        public string RiskLevelMethod { get; set; }
    
        /// <summary>
        /// The date and time the risk level has been set for a notification
        /// </summary>
        [Attr]
        [JsonPropertyName("riskLevelDateTime")]
        public string RiskLevelDateTime { get; set; }
    
}


