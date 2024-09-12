
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Inspector Address
    /// </summary>
public partial class AddressDto  {


        /// <summary>
        /// Street
        /// </summary>
        [Attr]
        [JsonProperty("street", NullValueHandling = NullValueHandling.Ignore)]
        public string Street { get; set; }
    
        /// <summary>
        /// City
        /// </summary>
        [Attr]
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }
    
        /// <summary>
        /// Country
        /// </summary>
        [Attr]
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
    
        /// <summary>
        /// Postal Code
        /// </summary>
        [Attr]
        [JsonProperty("postalCode", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }
    
}


