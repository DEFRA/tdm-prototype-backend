
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Accompanying document
    /// </summary>
public partial class AccompanyingDocumentDto  {


        /// <summary>
        /// Additional document type
        /// </summary>
        [Attr]
        [JsonPropertyName("documentType")]
        public string DocumentType { get; set; }
    
        /// <summary>
        /// Additional document reference
        /// </summary>
        [Attr]
        [JsonPropertyName("documentReference")]
        public string DocumentReference { get; set; }
    
        /// <summary>
        /// Additional document issue date
        /// </summary>
        [Attr]
        [JsonPropertyName("documentIssueDate")]
        public string DocumentIssueDate { get; set; }
    
        /// <summary>
        /// The UUID used for the uploaded file in blob storage
        /// </summary>
        [Attr]
        [JsonPropertyName("attachmentId")]
        public string AttachmentId { get; set; }
    
        /// <summary>
        /// The original filename of the uploaded file
        /// </summary>
        [Attr]
        [JsonPropertyName("attachmentFilename")]
        public string AttachmentFilename { get; set; }
    
        /// <summary>
        /// The MIME type of the uploaded file
        /// </summary>
        [Attr]
        [JsonPropertyName("attachmentContentType")]
        public string AttachmentContentType { get; set; }
    
        /// <summary>
        /// The UUID for the user that uploaded the file
        /// </summary>
        [Attr]
        [JsonPropertyName("uploadUserId")]
        public string UploadUserId { get; set; }
    
        /// <summary>
        /// The UUID for the organisation that the upload user is associated with
        /// </summary>
        [Attr]
        [JsonPropertyName("uploadOrganisationId")]
        public string UploadOrganisationId { get; set; }
    
        /// <summary>
        /// External reference of accompanying document, which relates to a downstream service
        /// </summary>
        [Attr]
        [JsonPropertyName("externalReference")]
        public ExternalReferenceDto ExternalReference { get; set; }
    
}


