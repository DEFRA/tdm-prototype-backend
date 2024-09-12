
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Details of the seal check
    /// </summary>
public partial class SealCheckDto  {


        /// <summary>
        /// Is seal check satisfactory
        /// </summary>
        [Attr]
        [JsonPropertyName("satisfactory")]
        public bool Satisfactory { get; set; }
    
        /// <summary>
        /// reason for not satisfactory
        /// </summary>
        [Attr]
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    
        /// <summary>
        /// Official inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("officialInspector")]
        public OfficialInspectorDto OfficialInspector { get; set; }
    
        /// <summary>
        /// date and time of seal check
        /// </summary>
        [Attr]
        [JsonPropertyName("dateTimeOfCheck")]
        public string DateTimeOfCheck { get; set; }
    
}


