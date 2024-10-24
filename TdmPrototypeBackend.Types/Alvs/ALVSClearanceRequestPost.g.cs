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
/// Message sent to the server to send an ALVSClearanceRequest.
/// </summary>
public partial class ALVSClearanceRequestPost  //
{


    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("xmlSchemaVersion")]
    public string? XmlSchemaVersion { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("userIdentification")]
    public string? UserIdentification { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("userPassword")]
    public string? UserPassword { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("sendingDate")]
    public string? SendingDate { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("alvsClearanceRequest")]
    public AlvsClearanceRequest? AlvsClearanceRequest { get; set; }

	}


