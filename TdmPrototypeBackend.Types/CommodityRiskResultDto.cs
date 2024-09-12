
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Result of the risk assessment of a commodity
    /// </summary>
public partial class CommodityRiskResultDto  {


        /// <summary>
        /// CHED-A, CHED-D, CHED-P - what is the commodity complement risk decision
        /// </summary>
        [Attr]
        [JsonProperty("riskDecision", NullValueHandling = NullValueHandling.Ignore)]
        public string RiskDecision { get; set; }
    
        /// <summary>
        /// Transit CHED - what is the commodity complement exit risk decision
        /// </summary>
        [Attr]
        [JsonProperty("exitRiskDecision", NullValueHandling = NullValueHandling.Ignore)]
        public string ExitRiskDecision { get; set; }
    
        /// <summary>
        /// HMI decision required
        /// </summary>
        [Attr]
        [JsonProperty("hmiDecision", NullValueHandling = NullValueHandling.Ignore)]
        public string HmiDecision { get; set; }
    
        /// <summary>
        /// PHSI decision required
        /// </summary>
        [Attr]
        [JsonProperty("phsiDecision", NullValueHandling = NullValueHandling.Ignore)]
        public string PhsiDecision { get; set; }
    
        /// <summary>
        /// PHSI classification
        /// </summary>
        [Attr]
        [JsonProperty("phsiClassification", NullValueHandling = NullValueHandling.Ignore)]
        public string PhsiClassification { get; set; }
    
        /// <summary>
        /// PHSI Decision Breakdown
        /// </summary>
        [Attr]
        [JsonProperty("phsi", NullValueHandling = NullValueHandling.Ignore)]
        public object Phsi { get; set; }
    
        /// <summary>
        /// UUID used to match to the complement parameter set
        /// </summary>
        [Attr]
        [JsonProperty("uniqueId", NullValueHandling = NullValueHandling.Ignore)]
        public string UniqueId { get; set; }
    
        /// <summary>
        /// EPPO Code for the species
        /// </summary>
        [Attr]
        [JsonProperty("eppoCode", NullValueHandling = NullValueHandling.Ignore)]
        public string EppoCode { get; set; }
    
        /// <summary>
        /// Name or ID of the variety
        /// </summary>
        [Attr]
        [JsonProperty("variety", NullValueHandling = NullValueHandling.Ignore)]
        public string Variety { get; set; }
    
        /// <summary>
        /// Whether or not a plant is woody
        /// </summary>
        [Attr]
        [JsonProperty("isWoody", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsWoody { get; set; }
    
        /// <summary>
        /// Indoor or Outdoor for a plant
        /// </summary>
        [Attr]
        [JsonProperty("indoorOutdoor", NullValueHandling = NullValueHandling.Ignore)]
        public string IndoorOutdoor { get; set; }
    
        /// <summary>
        /// Whether the propagation is considered a Plant, Bulb, Seed or None
        /// </summary>
        [Attr]
        [JsonProperty("propagation", NullValueHandling = NullValueHandling.Ignore)]
        public string Propagation { get; set; }
    
        /// <summary>
        /// Rule type for PHSI checks
        /// </summary>
        [Attr]
        [JsonProperty("phsiRuleType", NullValueHandling = NullValueHandling.Ignore)]
        public string PhsiRuleType { get; set; }
    
}


