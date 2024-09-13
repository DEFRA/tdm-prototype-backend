
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Validation field code-message representation
    /// </summary>
public partial class IpaffsValidationMessageCode  {


        /// <summary>
        /// Field
        /// </summary>
        [Attr]
        [JsonPropertyName("field")]
        public string Field { get; set; }
    
        /// <summary>
        /// Code
        /// </summary>
        [Attr]
        [JsonPropertyName("code")]
        public string Code { get; set; }
    
}


