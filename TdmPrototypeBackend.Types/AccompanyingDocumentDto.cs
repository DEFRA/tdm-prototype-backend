
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Accompanying document
    /// </summary>
public partial class AccompanyingDocumentDto  {


        /// <summary>
        /// Additional document type
        /// </summary>
        [Attr]
        [JsonProperty("documentType", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentType { get; set; }
    
        /// <summary>
        /// Additional document reference
        /// </summary>
        [Attr]
        [JsonProperty("documentReference", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentReference { get; set; }
    
        /// <summary>
        /// Additional document issue date
        /// </summary>
        [Attr]
        [JsonProperty("documentIssueDate", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentIssueDate { get; set; }
    
        /// <summary>
        /// The UUID used for the uploaded file in blob storage
        /// </summary>
        [Attr]
        [JsonProperty("attachmentId", NullValueHandling = NullValueHandling.Ignore)]
        public string AttachmentId { get; set; }
    
        /// <summary>
        /// The original filename of the uploaded file
        /// </summary>
        [Attr]
        [JsonProperty("attachmentFilename", NullValueHandling = NullValueHandling.Ignore)]
        public string AttachmentFilename { get; set; }
    
        /// <summary>
        /// The MIME type of the uploaded file
        /// </summary>
        [Attr]
        [JsonProperty("attachmentContentType", NullValueHandling = NullValueHandling.Ignore)]
        public string AttachmentContentType { get; set; }
    
        /// <summary>
        /// The UUID for the user that uploaded the file
        /// </summary>
        [Attr]
        [JsonProperty("uploadUserId", NullValueHandling = NullValueHandling.Ignore)]
        public string UploadUserId { get; set; }
    
        /// <summary>
        /// The UUID for the organisation that the upload user is associated with
        /// </summary>
        [Attr]
        [JsonProperty("uploadOrganisationId", NullValueHandling = NullValueHandling.Ignore)]
        public string UploadOrganisationId { get; set; }
    
        /// <summary>
        /// External reference of accompanying document, which relates to a downstream service
        /// </summary>
        [Attr]
        [JsonProperty("externalReference", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalReferenceDto ExternalReference { get; set; }
    
}


