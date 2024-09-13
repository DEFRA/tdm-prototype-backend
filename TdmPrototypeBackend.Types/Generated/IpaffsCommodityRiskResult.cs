
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Result of the risk assessment of a commodity
    /// </summary>
public partial class IpaffsCommodityRiskResult  {


        /// <summary>
        /// CHED-A, CHED-D, CHED-P - what is the commodity complement risk decision
        /// </summary>
        [Attr]
        [JsonPropertyName("riskDecision")]
        public IpaffsRiskDecisionEnum RiskDecision { get; set; }
    
        /// <summary>
        /// Transit CHED - what is the commodity complement exit risk decision
        /// </summary>
        [Attr]
        [JsonPropertyName("exitRiskDecision")]
        public IpaffsExitRiskDecisionEnum ExitRiskDecision { get; set; }
    
        /// <summary>
        /// HMI decision required
        /// </summary>
        [Attr]
        [JsonPropertyName("hmiDecision")]
        public IpaffsHmiDecisionEnum HmiDecision { get; set; }
    
        /// <summary>
        /// PHSI decision required
        /// </summary>
        [Attr]
        [JsonPropertyName("phsiDecision")]
        public IpaffsPhsiDecisionEnum PhsiDecision { get; set; }
    
        /// <summary>
        /// PHSI classification
        /// </summary>
        [Attr]
        [JsonPropertyName("phsiClassification")]
        public IpaffsPhsiClassificationEnum PhsiClassification { get; set; }
    
        /// <summary>
        /// PHSI Decision Breakdown
        /// </summary>
        [Attr]
        [JsonPropertyName("phsi")]
        public IpaffsPhsi Phsi { get; set; }
    
        /// <summary>
        /// UUID used to match to the complement parameter set
        /// </summary>
        [Attr]
        [JsonPropertyName("uniqueId")]
        public string UniqueId { get; set; }
    
        /// <summary>
        /// EPPO Code for the species
        /// </summary>
        [Attr]
        [JsonPropertyName("eppoCode")]
        public string EppoCode { get; set; }
    
        /// <summary>
        /// Name or ID of the variety
        /// </summary>
        [Attr]
        [JsonPropertyName("variety")]
        public string Variety { get; set; }
    
        /// <summary>
        /// Whether or not a plant is woody
        /// </summary>
        [Attr]
        [JsonPropertyName("isWoody")]
        public bool IsWoody { get; set; }
    
        /// <summary>
        /// Indoor or Outdoor for a plant
        /// </summary>
        [Attr]
        [JsonPropertyName("indoorOutdoor")]
        public string IndoorOutdoor { get; set; }
    
        /// <summary>
        /// Whether the propagation is considered a Plant, Bulb, Seed or None
        /// </summary>
        [Attr]
        [JsonPropertyName("propagation")]
        public string Propagation { get; set; }
    
        /// <summary>
        /// Rule type for PHSI checks
        /// </summary>
        [Attr]
        [JsonPropertyName("phsiRuleType")]
        public string PhsiRuleType { get; set; }
    
}

