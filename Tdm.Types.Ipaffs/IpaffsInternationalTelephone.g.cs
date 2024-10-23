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
/// International phone number
/// </summary>
public partial class IpaffsInternationalTelephone  //
{


    /// <summary>
    /// Country code of phone number
    /// </summary
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

	
    /// <summary>
    /// Phone number
    /// </summary
    [JsonPropertyName("subscriberNumber")]
    public string? SubscriberNumber { get; set; }

	}

