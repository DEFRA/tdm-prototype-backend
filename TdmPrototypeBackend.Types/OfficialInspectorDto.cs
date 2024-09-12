
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Official inspector details
    /// </summary>
public partial class OfficialInspectorDto  {


        /// <summary>
        /// First name of inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
    
        /// <summary>
        /// Last name of inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
    
        /// <summary>
        /// Email of inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    
        /// <summary>
        /// Phone number of inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    
        /// <summary>
        /// Fax number of inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("fax")]
        public string Fax { get; set; }
    
        /// <summary>
        /// Address of inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("address")]
        public AddressDto Address { get; set; }
    
        /// <summary>
        /// Date of sign
        /// </summary>
        [Attr]
        [JsonPropertyName("signed")]
        public string Signed { get; set; }
    
}


