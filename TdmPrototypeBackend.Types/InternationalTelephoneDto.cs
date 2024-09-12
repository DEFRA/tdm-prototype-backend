
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// International phone number
    /// </summary>
public partial class InternationalTelephoneDto  {


        /// <summary>
        /// Country code of phone number
        /// </summary>
        [Attr]
        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }
    
        /// <summary>
        /// Phone number
        /// </summary>
        [Attr]
        [JsonPropertyName("subscriberNumber")]
        public string SubscriberNumber { get; set; }
    
}


