
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// 
    /// </summary>
public partial class IpaffsCatchCertificates  {


        /// <summary>
        /// The catch certificate number
        /// </summary>
        [Attr]
        [JsonPropertyName("certificateNumber")]
        public string CertificateNumber { get; set; }
    
        /// <summary>
        /// The catch certificate weight number
        /// </summary>
        [Attr]
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
    
}


