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
public partial class Document  //
{


    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("documentCode")]
    public string? DocumentCode { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("documentReference")]
    public string? DocumentReference { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("documentStatus")]
    public string? DocumentStatus { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("documentControl")]
    public string? DocumentControl { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("documentQuantity")]
    public decimal? DocumentQuantity { get; set; }

	}


