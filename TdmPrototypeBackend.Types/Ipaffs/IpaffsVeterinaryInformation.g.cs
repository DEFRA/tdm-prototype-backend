//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable

using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using System.Dynamic;


namespace TdmPrototypeBackend.Types.Ipaffs;

    /// <summary>
    /// Part 1 - Holds the information related to veterinary checks and details
    /// </summary>
public partial class IpaffsVeterinaryInformation  //
{


		/// <summary>
        /// External reference of approved establishments, which relates to a downstream service
        /// </summary>
        [Attr]
        [JsonPropertyName("establishmentsOfOriginExternalReference")]
		public  IpaffsExternalReference? EstablishmentsOfOriginExternalReference { get; set; }
    
		/// <summary>
        /// List of establishments which were approved by UK to issue veterinary documents
        /// </summary>
        [Attr]
        [JsonPropertyName("establishmentsOfOrigin")]
		public  IpaffsApprovedEstablishment[]? EstablishmentsOfOrigins { get; set; }
    
		/// <summary>
        /// Veterinary document identification
        /// </summary>
        [Attr]
        [JsonPropertyName("veterinaryDocument")]
		public  string? VeterinaryDocument { get; set; }
    
		/// <summary>
        /// Veterinary document issue date
        /// </summary>
        [Attr]
        [JsonPropertyName("veterinaryDocumentIssueDate")]
		public  string? VeterinaryDocumentIssueDate { get; set; }
    
		/// <summary>
        /// Additional documents
        /// </summary>
        [Attr]
        [JsonPropertyName("accompanyingDocumentNumbers")]
		public  string[]? AccompanyingDocumentNumbers { get; set; }
    
		/// <summary>
        /// Accompanying documents
        /// </summary>
        [Attr]
        [JsonPropertyName("accompanyingDocuments")]
		public  IpaffsAccompanyingDocument[]? AccompanyingDocuments { get; set; }
    
		/// <summary>
        /// Catch certificate attachments
        /// </summary>
        [Attr]
        [JsonPropertyName("catchCertificateAttachments")]
		public  IpaffsCatchCertificateAttachment[]? CatchCertificateAttachments { get; set; }
    
		/// <summary>
        /// Details helpful for identification
        /// </summary>
        [Attr]
        [JsonPropertyName("identificationDetails")]
		public  IpaffsIdentificationDetails[]? IdentificationDetails { get; set; }
    
}


