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
/// Inspector Address
/// </summary>
public partial class IpaffsAddress  //
{


    /// <summary>
    /// Street
    /// </summary
    [Attr]
    [JsonPropertyName("street")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? Street { get; set; }

	
    /// <summary>
    /// City
    /// </summary
    [Attr]
    [JsonPropertyName("city")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? City { get; set; }

	
    /// <summary>
    /// Country
    /// </summary
    [Attr]
    [JsonPropertyName("country")]
    public string? Country { get; set; }

	
    /// <summary>
    /// Postal Code
    /// </summary
    [Attr]
    [JsonPropertyName("postalCode")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? PostalCode { get; set; }

	
    /// <summary>
    /// 1st line of address
    /// </summary
    [Attr]
    [JsonPropertyName("addressLine1")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? AddressLine1 { get; set; }

	
    /// <summary>
    /// 2nd line of address
    /// </summary
    [Attr]
    [JsonPropertyName("addressLine2")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? AddressLine2 { get; set; }

	
    /// <summary>
    /// 3rd line of address
    /// </summary
    [Attr]
    [JsonPropertyName("addressLine3")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? AddressLine3 { get; set; }

	
    /// <summary>
    /// Post / zip code
    /// </summary
    [Attr]
    [JsonPropertyName("postalZipCode")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? PostalZipCode { get; set; }

	
    /// <summary>
    /// country 2-digits ISO code
    /// </summary
    [Attr]
    [JsonPropertyName("countryISOCode")]
    public string? CountryISOCode { get; set; }

	
    /// <summary>
    /// Email address
    /// </summary
    [Attr]
    [JsonPropertyName("email")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? Email { get; set; }

	
    /// <summary>
    /// UK phone number
    /// </summary
    [Attr]
    [JsonPropertyName("ukTelephone")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? UkTelephone { get; set; }

	
    /// <summary>
    /// Telephone number
    /// </summary
    [Attr]
    [JsonPropertyName("telephone")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? Telephone { get; set; }

	
    /// <summary>
    /// International phone number
    /// </summary
    [Attr]
    [JsonPropertyName("internationalTelephone")]
    public IpaffsInternationalTelephone? InternationalTelephone { get; set; }

	}


