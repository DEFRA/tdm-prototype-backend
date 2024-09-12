
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Details of transport
    /// </summary>
public partial class MeansOfTransportDto  {


        /// <summary>
        /// Type of transport
        /// </summary>
        [Attr]
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string _Type { get; set; }
    
        /// <summary>
        /// Document for transport
        /// </summary>
        [Attr]
        [JsonProperty("document", NullValueHandling = NullValueHandling.Ignore)]
        public string Document { get; set; }
    
        /// <summary>
        /// ID of transport
        /// </summary>
        [Attr]
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    
}


