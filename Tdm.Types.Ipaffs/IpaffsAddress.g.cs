//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable

using System.Text.Json.Serialization;
using System.Dynamic;


namespace Tdm.Types.Ipaffs;

/// <summary>
/// Inspector Address
/// </summary>
public partial class IpaffsAddress  //
{


    /// <summary>
    /// Street
    /// </summary
    [JsonPropertyName("street")]
    [Tdm.SensitiveData.SensitiveData.SensitiveData]
    public string? Street { get; set; }

	
    /// <summary>
    /// City
    /// </summary
    [JsonPropertyName("city")]
    [Tdm.SensitiveData.SensitiveData.SensitiveData]
    public string? City { get; set; }

	
    /// <summary>
    /// Country
    /// </summary
    [JsonPropertyName("country")]
    public string? Country { get; set; }

	
    /// <summary>
    /// Postal Code
    /// </summary
    [JsonPropertyName("postalCode")]
    [Tdm.SensitiveData.SensitiveData.SensitiveData]
    public string? PostalCode { get; set; }

	
    /// <summary>
    /// 1st line of address
    /// </summary
    [JsonPropertyName("addressLine1")]
    [Tdm.SensitiveData.SensitiveData.SensitiveData]
    public string? AddressLine1 { get; set; }

	
    /// <summary>
    /// 2nd line of address
    /// </summary
    [JsonPropertyName("addressLine2")]
    [Tdm.SensitiveData.SensitiveData.SensitiveData]
    public string? AddressLine2 { get; set; }

	
    /// <summary>
    /// 3rd line of address
    /// </summary
    [JsonPropertyName("addressLine3")]
    [Tdm.SensitiveData.SensitiveData.SensitiveData]
    public string? AddressLine3 { get; set; }

	
    /// <summary>
    /// Post / zip code
    /// </summary
    [JsonPropertyName("postalZipCode")]
    [Tdm.SensitiveData.SensitiveData.SensitiveData]
    public string? PostalZipCode { get; set; }

	
    /// <summary>
    /// country 2-digits ISO code
    /// </summary
    [JsonPropertyName("countryISOCode")]
    public string? CountryIsoCode { get; set; }

	
    /// <summary>
    /// Email address
    /// </summary
    [JsonPropertyName("email")]
    [Tdm.SensitiveData.SensitiveData.SensitiveData]
    public string? Email { get; set; }

	
    /// <summary>
    /// UK phone number
    /// </summary
    [JsonPropertyName("ukTelephone")]
    [Tdm.SensitiveData.SensitiveData.SensitiveData]
    public string? UkTelephone { get; set; }

	
    /// <summary>
    /// Telephone number
    /// </summary
    [JsonPropertyName("telephone")]
    [Tdm.SensitiveData.SensitiveData.SensitiveData]
    public string? Telephone { get; set; }

	
    /// <summary>
    /// International phone number
    /// </summary
    [JsonPropertyName("internationalTelephone")]
    public IpaffsInternationalTelephone? InternationalTelephone { get; set; }

	}

