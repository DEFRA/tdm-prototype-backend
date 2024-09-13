
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// 
    /// </summary>
public partial class IpaffsBillingInformation  {


        /// <summary>
        /// Indicates whether user has confirmed their billing information
        /// </summary>
        [Attr]
        [JsonPropertyName("isConfirmed")]
        public bool IsConfirmed { get; set; }
    
        /// <summary>
        /// Billing email address
        /// </summary>
        [Attr]
        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }
    
        /// <summary>
        /// Billing phone number
        /// </summary>
        [Attr]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
    
        /// <summary>
        /// Billing Contact Name
        /// </summary>
        [Attr]
        [JsonPropertyName("contactName")]
        public string ContactName { get; set; }
    
        /// <summary>
        /// Billing postal address
        /// </summary>
        [Attr]
        [JsonPropertyName("postalAddress")]
        public IpaffsPostalAddress PostalAddress { get; set; }
    
}


