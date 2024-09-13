
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Billing postal address
    /// </summary>
public partial class IpaffsPostalAddress  {


        /// <summary>
        /// 1st line of address
        /// </summary>
        [Attr]
        [JsonPropertyName("addressLine1")]
        public string AddressLine1 { get; set; }
    
        /// <summary>
        /// 2nd line of address
        /// </summary>
        [Attr]
        [JsonPropertyName("addressLine2")]
        public string AddressLine2 { get; set; }
    
        /// <summary>
        /// 3rd line of address
        /// </summary>
        [Attr]
        [JsonPropertyName("addressLine3")]
        public string AddressLine3 { get; set; }
    
        /// <summary>
        /// 4th line of address
        /// </summary>
        [Attr]
        [JsonPropertyName("addressLine4")]
        public string AddressLine4 { get; set; }
    
        /// <summary>
        /// 3rd line of address
        /// </summary>
        [Attr]
        [JsonPropertyName("county")]
        public string County { get; set; }
    
        /// <summary>
        /// City or town name
        /// </summary>
        [Attr]
        [JsonPropertyName("cityOrTown")]
        public string CityOrTown { get; set; }
    
        /// <summary>
        /// Post code
        /// </summary>
        [Attr]
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
    
}


