
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Person to be nominated for text and email contact for the consignment
    /// </summary>
public partial class NominatedContactDto  {


        /// <summary>
        /// Name of nominated contact
        /// </summary>
        [Attr]
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        /// <summary>
        /// Email address of nominated contact
        /// </summary>
        [Attr]
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    
        /// <summary>
        /// Telephone number of nominated contact
        /// </summary>
        [Attr]
        [JsonProperty("telephone", NullValueHandling = NullValueHandling.Ignore)]
        public string Telephone { get; set; }
    
}


