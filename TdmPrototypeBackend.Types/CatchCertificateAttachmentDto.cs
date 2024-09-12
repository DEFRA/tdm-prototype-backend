
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Catch certificate attachment
    /// </summary>
public partial class CatchCertificateAttachmentDto  {


        /// <summary>
        /// The UUID of the uploaded catch certificate file in blob storage
        /// </summary>
        [Attr]
        [JsonProperty("attachmentId", NullValueHandling = NullValueHandling.Ignore)]
        public string AttachmentId { get; set; }
    
        /// <summary>
        /// The total number of catch certificates on the attachment
        /// </summary>
        [Attr]
        [JsonProperty("numberOfCatchCertificates", NullValueHandling = NullValueHandling.Ignore)]
        public int NumberOfCatchCertificates { get; set; }
    
        /// <summary>
        /// List of catch certificate details
        /// </summary>
        [Attr]
        [JsonProperty("CatchCertificateDetails", NullValueHandling = NullValueHandling.Ignore)]
        public CatchCertificateDetailsDto[] CatchCertificateDetails { get; set; }
    
}


