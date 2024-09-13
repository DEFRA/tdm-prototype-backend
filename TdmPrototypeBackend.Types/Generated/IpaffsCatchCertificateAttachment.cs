
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Catch certificate attachment
    /// </summary>
public partial class IpaffsCatchCertificateAttachment  {


        /// <summary>
        /// The UUID of the uploaded catch certificate file in blob storage
        /// </summary>
        [Attr]
        [JsonPropertyName("attachmentId")]
        public string AttachmentId { get; set; }
    
        /// <summary>
        /// The total number of catch certificates on the attachment
        /// </summary>
        [Attr]
        [JsonPropertyName("numberOfCatchCertificates")]
        public int NumberOfCatchCertificates { get; set; }
    
        /// <summary>
        /// List of catch certificate details
        /// </summary>
        [Attr]
        [JsonPropertyName("CatchCertificateDetails")]
        public IpaffsCatchCertificateDetails[] CatchCertificateDetails { get; set; }
    
}


