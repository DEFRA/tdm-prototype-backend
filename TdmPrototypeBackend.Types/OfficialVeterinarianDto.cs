
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Official veterinarian information
    /// </summary>
public partial class OfficialVeterinarianDto  {


        /// <summary>
        /// First name of official veterinarian
        /// </summary>
        [Attr]
        [JsonProperty("firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }
    
        /// <summary>
        /// Last name of official veterinarian
        /// </summary>
        [Attr]
        [JsonProperty("lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }
    
        /// <summary>
        /// Email address of official veterinarian
        /// </summary>
        [Attr]
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    
        /// <summary>
        /// Phone number of official veterinarian
        /// </summary>
        [Attr]
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }
    
        /// <summary>
        /// Fax number of official veterinarian
        /// </summary>
        [Attr]
        [JsonProperty("fax", NullValueHandling = NullValueHandling.Ignore)]
        public string Fax { get; set; }
    
        /// <summary>
        /// Date of sign
        /// </summary>
        [Attr]
        [JsonProperty("signed", NullValueHandling = NullValueHandling.Ignore)]
        public string Signed { get; set; }
    
}


