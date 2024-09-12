
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// inspector
    /// </summary>
public partial class InspectorDto  {


        /// <summary>
        /// Name of inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    
        /// <summary>
        /// Phone number of inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    
        /// <summary>
        /// Email address of inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    
}


