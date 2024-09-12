
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Reference number from an external system which is related to this notification
    /// </summary>
public partial class ExternalReferenceDto  {


        /// <summary>
        /// Identifier of the external system to which the reference relates
        /// </summary>
        [Attr]
        [JsonPropertyName("system")]
        public string System { get; set; }
    
        /// <summary>
        /// Reference which is added to the notification when either sent to the downstream system or received from it
        /// </summary>
        [Attr]
        [JsonPropertyName("reference")]
        public string Reference { get; set; }
    
        /// <summary>
        /// Details whether there&#x27;s an exact match between the external source and IPAFFS data
        /// </summary>
        [Attr]
        [JsonPropertyName("exactMatch")]
        public bool ExactMatch { get; set; }
    
        /// <summary>
        /// Details whether an importer has verified the data from an external source
        /// </summary>
        [Attr]
        [JsonPropertyName("verifiedByImporter")]
        public bool VerifiedByImporter { get; set; }
    
        /// <summary>
        /// Details whether an inspector has verified the data from an external source
        /// </summary>
        [Attr]
        [JsonPropertyName("verifiedByInspector")]
        public bool VerifiedByInspector { get; set; }
    
}


