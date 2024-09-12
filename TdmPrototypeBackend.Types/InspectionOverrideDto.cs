
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Details about the manual inspection override
    /// </summary>
public partial class InspectionOverrideDto  {


        /// <summary>
        /// Original inspection decision
        /// </summary>
        [Attr]
        [JsonProperty("originalDecision", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalDecision { get; set; }
    
        /// <summary>
        /// The time the risk decision is overridden
        /// </summary>
        [Attr]
        [JsonProperty("overriddenOn", NullValueHandling = NullValueHandling.Ignore)]
        public string OverriddenOn { get; set; }
    
        /// <summary>
        /// User entity who has manually overridden the inspection
        /// </summary>
        [Attr]
        [JsonProperty("overriddenBy", NullValueHandling = NullValueHandling.Ignore)]
        public UserInformationDto OverriddenBy { get; set; }
    
}


