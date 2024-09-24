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


namespace TdmPrototypeBackend.Types.Alvs;

    /// <summary>
    /// 
    /// </summary>
public partial class Header  //
{


		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("entryReference")]
		public  string? EntryReference { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("entryVersionNumber")]
		public  int? EntryVersionNumber { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("previousVersionNumber")]
		public  int? PreviousVersionNumber { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("declarationUCR")]
		public  string? DeclarationUCR { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("declarationPartNumber")]
		public  string? DeclarationPartNumber { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("declarationType")]
		public  string? DeclarationType { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("arrivalDateTime")]
		public  DateTime? ArrivalDateTime { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("submitterTURN")]
		public  string? SubmitterTURN { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("declarantId")]
		public  string? DeclarantId { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("declarantName")]
		public  string? DeclarantName { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("dispatchCountryCode")]
		public  string? DispatchCountryCode { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("goodsLocationCode")]
		public  string? GoodsLocationCode { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("masterUCR")]
		public  string? MasterUCR { get; set; }
    
}


