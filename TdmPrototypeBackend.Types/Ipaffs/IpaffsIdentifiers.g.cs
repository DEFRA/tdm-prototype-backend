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
public partial class IpaffsIdentifiers  //
{


    /// <summary>
    /// Number used to identify which item the identifiers are related to
    /// </summary
    [Attr]
    [JsonPropertyName("speciesNumber")]
    public int? SpeciesNumber { get; set; }

	
    /// <summary>
    /// List of identifiers and their keys
    /// </summary
    [Attr]
    [JsonPropertyName("data")]
    public IDictionary<string, string>? Data { get; set; }

	
    /// <summary>
    /// Is the place of destination the permanent address?
    /// </summary
    [Attr]
    [JsonPropertyName("isPlaceOfDestinationThePermanentAddress")]
    public bool? IsPlaceOfDestinationThePermanentAddress { get; set; }

	
    /// <summary>
    /// Permanent address of the species
    /// </summary
    [Attr]
    [JsonPropertyName("permanentAddress")]
    public IpaffsEconomicOperator? PermanentAddress { get; set; }

	}


