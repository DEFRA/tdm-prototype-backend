
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// 
    /// </summary>
public partial class IpaffsIdentificationDetails  {


        /// <summary>
        /// Identification detail
        /// </summary>
        [Attr]
        [JsonPropertyName("identificationDetail")]
        public string IdentificationDetail { get; set; }
    
        /// <summary>
        /// Identification description
        /// </summary>
        [Attr]
        [JsonPropertyName("identificationDescription")]
        public string IdentificationDescription { get; set; }
    
}


