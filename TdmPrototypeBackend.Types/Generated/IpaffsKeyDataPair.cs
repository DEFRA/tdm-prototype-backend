
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// 
    /// </summary>
public partial class IpaffsKeyDataPair  {


        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("key")]
        public string Key { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("data")]
        public string Data { get; set; }
    
}


