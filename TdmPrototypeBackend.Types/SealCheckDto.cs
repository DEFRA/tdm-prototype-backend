
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Details of the seal check
    /// </summary>
public partial class SealCheckDto  {


        /// <summary>
        /// Is seal check satisfactory
        /// </summary>
        [Attr]
        [JsonProperty("satisfactory", NullValueHandling = NullValueHandling.Ignore)]
        public bool Satisfactory { get; set; }
    
        /// <summary>
        /// reason for not satisfactory
        /// </summary>
        [Attr]
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; set; }
    
        /// <summary>
        /// Official inspector
        /// </summary>
        [Attr]
        [JsonProperty("officialInspector", NullValueHandling = NullValueHandling.Ignore)]
        public OfficialInspectorDto OfficialInspector { get; set; }
    
        /// <summary>
        /// date and time of seal check
        /// </summary>
        [Attr]
        [JsonProperty("dateTimeOfCheck", NullValueHandling = NullValueHandling.Ignore)]
        public string DateTimeOfCheck { get; set; }
    
}


