
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Person to be contacted if there is an issue with the consignment
    /// </summary>
public partial class IpaffsContactDetails  {


        /// <summary>
        /// Name of designated contact
        /// </summary>
        [Attr]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    
        /// <summary>
        /// Telephone number of designated contact
        /// </summary>
        [Attr]
        [JsonPropertyName("telephone")]
        public string Telephone { get; set; }
    
        /// <summary>
        /// Email address of designated contact
        /// </summary>
        [Attr]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    
        /// <summary>
        /// Name of agent representing designated contact
        /// </summary>
        [Attr]
        [JsonPropertyName("agent")]
        public string Agent { get; set; }
    
}


