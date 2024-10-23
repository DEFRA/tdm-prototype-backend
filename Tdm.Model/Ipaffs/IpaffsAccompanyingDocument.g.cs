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


namespace Tdm.Model.Ipaffs;

/// <summary>
/// Accompanying document
/// </summary>
public partial class IpaffsAccompanyingDocument  //
{


    /// <summary>
    /// Additional document type
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Additional document type")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsAccompanyingDocumentDocumentTypeEnum? DocumentType { get; set; }

	
    /// <summary>
    /// Additional document reference
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Additional document reference")]
    public string? DocumentReference { get; set; }

	
    /// <summary>
    /// Additional document issue date
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Additional document issue date")]
    public DateTime? DocumentIssueDate { get; set; }

	
    /// <summary>
    /// The UUID used for the uploaded file in blob storage
    /// </summary
    [Attr]
    [System.ComponentModel.Description("The UUID used for the uploaded file in blob storage")]
    public string? AttachmentId { get; set; }

	
    /// <summary>
    /// The original filename of the uploaded file
    /// </summary
    [Attr]
    [System.ComponentModel.Description("The original filename of the uploaded file")]
    public string? AttachmentFilename { get; set; }

	
    /// <summary>
    /// The MIME type of the uploaded file
    /// </summary
    [Attr]
    [System.ComponentModel.Description("The MIME type of the uploaded file")]
    public string? AttachmentContentType { get; set; }

	
    /// <summary>
    /// The UUID for the user that uploaded the file
    /// </summary
    [Attr]
    [System.ComponentModel.Description("The UUID for the user that uploaded the file")]
    public string? UploadUserId { get; set; }

	
    /// <summary>
    /// The UUID for the organisation that the upload user is associated with
    /// </summary
    [Attr]
    [System.ComponentModel.Description("The UUID for the organisation that the upload user is associated with")]
    public string? UploadOrganisationId { get; set; }

	
    /// <summary>
    /// External reference of accompanying document, which relates to a downstream service
    /// </summary
    [Attr]
    [System.ComponentModel.Description("External reference of accompanying document, which relates to a downstream service")]
    public IpaffsExternalReference? ExternalReference { get; set; }

	}


