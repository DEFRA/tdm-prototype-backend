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
/// Official veterinarian information
/// </summary>
public partial class IpaffsOfficialVeterinarian  //
{


    /// <summary>
    /// First name of official veterinarian
    /// </summary
    [Attr]
    [JsonPropertyName("firstName")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? FirstName { get; set; }

	
    /// <summary>
    /// Last name of official veterinarian
    /// </summary
    [Attr]
    [JsonPropertyName("lastName")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? LastName { get; set; }

	
    /// <summary>
    /// Email address of official veterinarian
    /// </summary
    [Attr]
    [JsonPropertyName("email")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? Email { get; set; }

	
    /// <summary>
    /// Phone number of official veterinarian
    /// </summary
    [Attr]
    [JsonPropertyName("phone")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? Phone { get; set; }

	
    /// <summary>
    /// Fax number of official veterinarian
    /// </summary
    [Attr]
    [JsonPropertyName("fax")]
    [TdmPrototypeBackend.Types.Extensions.SensitiveData()]
    public string? Fax { get; set; }

	
    /// <summary>
    /// Date of sign
    /// </summary
    [Attr]
    [JsonPropertyName("signed")]
    public string? Signed { get; set; }

	}


