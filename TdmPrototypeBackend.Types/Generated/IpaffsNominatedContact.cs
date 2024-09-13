
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Person to be nominated for text and email contact for the consignment
    /// </summary>
public partial class IpaffsNominatedContact  {


        /// <summary>
        /// Name of nominated contact
        /// </summary>
        [Attr]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    
        /// <summary>
        /// Email address of nominated contact
        /// </summary>
        [Attr]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    
        /// <summary>
        /// Telephone number of nominated contact
        /// </summary>
        [Attr]
        [JsonPropertyName("telephone")]
        public string Telephone { get; set; }
    
}


