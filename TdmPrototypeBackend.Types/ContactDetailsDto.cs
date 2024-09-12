
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Person to be contacted if there is an issue with the consignment
    /// </summary>
public partial class ContactDetailsDto  {


        /// <summary>
        /// Name of designated contact
        /// </summary>
        [Attr]
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        /// <summary>
        /// Telephone number of designated contact
        /// </summary>
        [Attr]
        [JsonProperty("telephone", NullValueHandling = NullValueHandling.Ignore)]
        public string Telephone { get; set; }
    
        /// <summary>
        /// Email address of designated contact
        /// </summary>
        [Attr]
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    
        /// <summary>
        /// Name of agent representing designated contact
        /// </summary>
        [Attr]
        [JsonProperty("agent", NullValueHandling = NullValueHandling.Ignore)]
        public string Agent { get; set; }
    
}


