//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;

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
        public string? CertificateNumber { get; set; }
    
        /// <summary>
        /// The catch certificate weight number
        /// </summary>
        [Attr]
        [JsonPropertyName("weight")]
        public double? Weight { get; set; }
    
}


