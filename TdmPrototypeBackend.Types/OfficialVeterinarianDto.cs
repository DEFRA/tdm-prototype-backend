
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Official veterinarian information
    /// </summary>
public partial class OfficialVeterinarianDto  {


        /// <summary>
        /// First name of official veterinarian
        /// </summary>
        [Attr]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
    
        /// <summary>
        /// Last name of official veterinarian
        /// </summary>
        [Attr]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
    
        /// <summary>
        /// Email address of official veterinarian
        /// </summary>
        [Attr]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    
        /// <summary>
        /// Phone number of official veterinarian
        /// </summary>
        [Attr]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    
        /// <summary>
        /// Fax number of official veterinarian
        /// </summary>
        [Attr]
        [JsonPropertyName("fax")]
        public string Fax { get; set; }
    
        /// <summary>
        /// Date of sign
        /// </summary>
        [Attr]
        [JsonPropertyName("signed")]
        public string Signed { get; set; }
    
}


