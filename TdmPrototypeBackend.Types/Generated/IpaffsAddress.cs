
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Inspector Address
    /// </summary>
public partial class IpaffsAddress  {


        /// <summary>
        /// Street
        /// </summary>
        [Attr]
        [JsonPropertyName("street")]
        public string Street { get; set; }
    
        /// <summary>
        /// City
        /// </summary>
        [Attr]
        [JsonPropertyName("city")]
        public string City { get; set; }
    
        /// <summary>
        /// Country
        /// </summary>
        [Attr]
        [JsonPropertyName("country")]
        public string Country { get; set; }
    
        /// <summary>
        /// Postal Code
        /// </summary>
        [Attr]
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
    
}


