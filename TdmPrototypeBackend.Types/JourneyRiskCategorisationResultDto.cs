
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Details of the risk categorisation level for a notification
    /// </summary>
public partial class JourneyRiskCategorisationResultDto  {


        /// <summary>
        /// Risk Level is defined using enum values High,Medium,Low
        /// </summary>
        [Attr]
        [JsonProperty("riskLevel", NullValueHandling = NullValueHandling.Ignore)]
        public string RiskLevel { get; set; }
    
        /// <summary>
        /// Indicator of whether the risk level was determined by the system or by the user
        /// </summary>
        [Attr]
        [JsonProperty("riskLevelMethod", NullValueHandling = NullValueHandling.Ignore)]
        public string RiskLevelMethod { get; set; }
    
        /// <summary>
        /// The date and time the risk level has been set for a notification
        /// </summary>
        [Attr]
        [JsonProperty("riskLevelDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public string RiskLevelDateTime { get; set; }
    
}


