
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Part 1 - Holds the information related to veterinary checks and details
    /// </summary>
public partial class VeterinaryInformationDto  {


        /// <summary>
        /// External reference of approved establishments, which relates to a downstream service
        /// </summary>
        [Attr]
        [JsonPropertyName("establishmentsOfOriginExternalReference")]
        public ExternalReferenceDto EstablishmentsOfOriginExternalReference { get; set; }
    
        /// <summary>
        /// List of establishments which were approved by UK to issue veterinary documents
        /// </summary>
        [Attr]
        [JsonPropertyName("establishmentsOfOrigin")]
        public ApprovedEstablishmentDto[] EstablishmentsOfOrigin { get; set; }
    
        /// <summary>
        /// Veterinary document identification
        /// </summary>
        [Attr]
        [JsonPropertyName("veterinaryDocument")]
        public string VeterinaryDocument { get; set; }
    
        /// <summary>
        /// Veterinary document issue date
        /// </summary>
        [Attr]
        [JsonPropertyName("veterinaryDocumentIssueDate")]
        public string VeterinaryDocumentIssueDate { get; set; }
    
        /// <summary>
        /// Additional documents
        /// </summary>
        [Attr]
        [JsonPropertyName("accompanyingDocumentNumbers")]
        public string[][] AccompanyingDocumentNumbers { get; set; }
    
        /// <summary>
        /// Accompanying documents
        /// </summary>
        [Attr]
        [JsonPropertyName("accompanyingDocuments")]
        public AccompanyingDocumentDto[] AccompanyingDocuments { get; set; }
    
        /// <summary>
        /// Catch certificate attachments
        /// </summary>
        [Attr]
        [JsonPropertyName("catchCertificateAttachments")]
        public CatchCertificateAttachmentDto[] CatchCertificateAttachments { get; set; }
    
        /// <summary>
        /// Details helpful for identification
        /// </summary>
        [Attr]
        [JsonPropertyName("identificationDetails")]
        public IdentificationDetailsDto[] IdentificationDetails { get; set; }
    
}


