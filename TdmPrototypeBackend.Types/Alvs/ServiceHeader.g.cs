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
public partial class ServiceHeader  //
{


    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("sourceSystem")]
    public string? SourceSystem { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("destinationSystem")]
    public string? DestinationSystem { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("serviceCallTimestamp")]
    public DateTime? ServiceCallTimestamp { get; set; }

	}


