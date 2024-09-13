
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Catch certificate details for uploaded attachment
    /// </summary>
public partial class IpaffsCatchCertificateDetails  {


        /// <summary>
        /// The UUID of the catch certificate
        /// </summary>
        [Attr]
        [JsonPropertyName("catchCertificateId")]
        public string CatchCertificateId { get; set; }
    
        /// <summary>
        /// Catch certificate reference
        /// </summary>
        [Attr]
        [JsonPropertyName("catchCertificateReference")]
        public string CatchCertificateReference { get; set; }
    
        /// <summary>
        /// Catch certificate date of issue
        /// </summary>
        [Attr]
        [JsonPropertyName("dateOfIssue")]
        public string DateOfIssue { get; set; }
    
        /// <summary>
        /// Catch certificate flag state of catching vessel(s)
        /// </summary>
        [Attr]
        [JsonPropertyName("flagState")]
        public string FlagState { get; set; }
    
        /// <summary>
        /// List of species imported under this catch certificate
        /// </summary>
        [Attr]
        [JsonPropertyName("species")]
        public string[][] Species { get; set; }
    
}


