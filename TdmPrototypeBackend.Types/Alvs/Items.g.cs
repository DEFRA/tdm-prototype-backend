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
public partial class Items  //
{


		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("ItemNumber")]
		public  int? ItemNumber { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("CustomsProcedureCode")]
		public  string? CustomsProcedureCode { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("TaricCommodityCode")]
		public  string? TaricCommodityCode { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("GoodsDescription")]
		public  string? GoodsDescription { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("ConsigneeId")]
		public  string? ConsigneeId { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("ConsigneeName")]
		public  string? ConsigneeName { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("ItemNetMass")]
		public  decimal? ItemNetMass { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("ItemSupplementaryUnits")]
		public  decimal? ItemSupplementaryUnits { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("ItemThirdQuantity")]
		public  decimal? ItemThirdQuantity { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("ItemOriginCountryCode")]
		public  string? ItemOriginCountryCode { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("Document")]
		public  Document[]? Documents { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("Check")]
		public  Check[]? Checks { get; set; }
    
}


