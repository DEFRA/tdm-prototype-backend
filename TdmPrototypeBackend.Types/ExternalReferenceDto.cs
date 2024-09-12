
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Reference number from an external system which is related to this notification
    /// </summary>
public partial class ExternalReferenceDto  {


        /// <summary>
        /// Identifier of the external system to which the reference relates
        /// </summary>
        [Attr]
        [JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
        public string System { get; set; }
    
        /// <summary>
        /// Reference which is added to the notification when either sent to the downstream system or received from it
        /// </summary>
        [Attr]
        [JsonProperty("reference", NullValueHandling = NullValueHandling.Ignore)]
        public string Reference { get; set; }
    
        /// <summary>
        /// Details whether there&#x27;s an exact match between the external source and IPAFFS data
        /// </summary>
        [Attr]
        [JsonProperty("exactMatch", NullValueHandling = NullValueHandling.Ignore)]
        public bool ExactMatch { get; set; }
    
        /// <summary>
        /// Details whether an importer has verified the data from an external source
        /// </summary>
        [Attr]
        [JsonProperty("verifiedByImporter", NullValueHandling = NullValueHandling.Ignore)]
        public bool VerifiedByImporter { get; set; }
    
        /// <summary>
        /// Details whether an inspector has verified the data from an external source
        /// </summary>
        [Attr]
        [JsonProperty("verifiedByInspector", NullValueHandling = NullValueHandling.Ignore)]
        public bool VerifiedByInspector { get; set; }
    
}


