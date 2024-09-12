
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Validation field code-message representation
    /// </summary>
public partial class ValidationMessageCodeDto  {


        /// <summary>
        /// Field
        /// </summary>
        [Attr]
        [JsonProperty("field", NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }
    
        /// <summary>
        /// Code
        /// </summary>
        [Attr]
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
    
}


