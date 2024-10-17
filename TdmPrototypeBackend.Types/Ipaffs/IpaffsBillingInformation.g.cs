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
/// 
/// </summary>
public partial class IpaffsBillingInformation  //
{


    /// <summary>
    /// Indicates whether user has confirmed their billing information
    /// </summary
    [Attr]
    [JsonPropertyName("isConfirmed")]
    [System.ComponentModel.Description("Indicates whether user has confirmed their billing information")]
    public bool? IsConfirmed { get; set; }

	
    /// <summary>
    /// Billing email address
    /// </summary
    [Attr]
    [JsonPropertyName("emailAddress")]
    [System.ComponentModel.Description("Billing email address")]
    public string? EmailAddress { get; set; }

	
    /// <summary>
    /// Billing phone number
    /// </summary
    [Attr]
    [JsonPropertyName("phoneNumber")]
    [System.ComponentModel.Description("Billing phone number")]
    public string? PhoneNumber { get; set; }

	
    /// <summary>
    /// Billing Contact Name
    /// </summary
    [Attr]
    [JsonPropertyName("contactName")]
    [System.ComponentModel.Description("Billing Contact Name")]
    public string? ContactName { get; set; }

	
    /// <summary>
    /// Billing postal address
    /// </summary
    [Attr]
    [JsonPropertyName("postalAddress")]
    [System.ComponentModel.Description("Billing postal address")]
    public IpaffsPostalAddress? PostalAddress { get; set; }

	}


