
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Details about the manual inspection override
    /// </summary>
public partial class InspectionOverrideDto  {


        /// <summary>
        /// Original inspection decision
        /// </summary>
        [Attr]
        [JsonPropertyName("originalDecision")]
        public string OriginalDecision { get; set; }
    
        /// <summary>
        /// The time the risk decision is overridden
        /// </summary>
        [Attr]
        [JsonPropertyName("overriddenOn")]
        public string OverriddenOn { get; set; }
    
        /// <summary>
        /// User entity who has manually overridden the inspection
        /// </summary>
        [Attr]
        [JsonPropertyName("overriddenBy")]
        public UserInformationDto OverriddenBy { get; set; }
    
}


