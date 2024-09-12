
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Details of transport
    /// </summary>
public partial class MeansOfTransportDto  {


        /// <summary>
        /// Type of transport
        /// </summary>
        [Attr]
        [JsonPropertyName("type")]
        public string _Type { get; set; }
    
        /// <summary>
        /// Document for transport
        /// </summary>
        [Attr]
        [JsonPropertyName("document")]
        public string Document { get; set; }
    
        /// <summary>
        /// ID of transport
        /// </summary>
        [Attr]
        [JsonPropertyName("id")]
        public string Id { get; set; }
    
}


