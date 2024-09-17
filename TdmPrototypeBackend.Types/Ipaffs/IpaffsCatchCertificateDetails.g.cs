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
    /// Catch certificate details for uploaded attachment
    /// </summary>
public partial class IpaffsCatchCertificateDetails  //
{


		/// <summary>
        /// The UUID of the catch certificate
        /// </summary>
        [Attr]
        [JsonPropertyName("catchCertificateId")]
		public  string? CatchCertificateId { get; set; }
    
		/// <summary>
        /// Catch certificate reference
        /// </summary>
        [Attr]
        [JsonPropertyName("catchCertificateReference")]
		public  string? CatchCertificateReference { get; set; }
    
		/// <summary>
        /// Catch certificate date of issue
        /// </summary>
        [Attr]
        [JsonPropertyName("dateOfIssue")]
		public  string? DateOfIssue { get; set; }
    
		/// <summary>
        /// Catch certificate flag state of catching vessel(s)
        /// </summary>
        [Attr]
        [JsonPropertyName("flagState")]
		public  string? FlagState { get; set; }
    
		/// <summary>
        /// List of species imported under this catch certificate
        /// </summary>
        [Attr]
        [JsonPropertyName("species")]
		public  string[]? Species { get; set; }
    
}

