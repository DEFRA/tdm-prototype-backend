
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Official inspector details
    /// </summary>
public partial class OfficialInspectorDto  {


        /// <summary>
        /// First name of inspector
        /// </summary>
        [Attr]
        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }
    
        /// <summary>
        /// Last name of inspector
        /// </summary>
        [Attr]
        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }
    
        /// <summary>
        /// Email of inspector
        /// </summary>
        [Attr]
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    
        /// <summary>
        /// Phone number of inspector
        /// </summary>
        [Attr]
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }
    
        /// <summary>
        /// Fax number of inspector
        /// </summary>
        [Attr]
        [JsonProperty("fax", NullValueHandling = NullValueHandling.Ignore)]
        public string Fax { get; set; }
    
        /// <summary>
        /// Address of inspector
        /// </summary>
        [Attr]
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public AddressDto Address { get; set; }
    
        /// <summary>
        /// Date of sign
        /// </summary>
        [Attr]
        [JsonProperty("signed", NullValueHandling = NullValueHandling.Ignore)]
        public string Signed { get; set; }
    
}


