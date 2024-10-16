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
    /// </summary
    [Attr]
    [JsonPropertyName("itemNumber")]
    public int? ItemNumber { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("customsProcedureCode")]
    public string? CustomsProcedureCode { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("taricCommodityCode")]
    public string? TaricCommodityCode { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("goodsDescription")]
    public string? GoodsDescription { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("consigneeId")]
    public string? ConsigneeId { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("consigneeName")]
    public string? ConsigneeName { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("itemNetMass")]
    public decimal? ItemNetMass { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("itemSupplementaryUnits")]
    public decimal? ItemSupplementaryUnits { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("itemThirdQuantity")]
    public decimal? ItemThirdQuantity { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("itemOriginCountryCode")]
    public string? ItemOriginCountryCode { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("document")]
    public Document[]? Documents { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("checks")]
    public Check[]? Checks { get; set; }

	}


