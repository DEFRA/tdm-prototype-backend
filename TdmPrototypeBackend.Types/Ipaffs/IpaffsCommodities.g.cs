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
public partial class IpaffsCommodities  //
{


    /// <summary>
    /// Flag to record when the GMS declaration has been accepted
    /// </summary
    [Attr]
    [JsonPropertyName("gmsDeclarationAccepted")]
    public bool? GmsDeclarationAccepted { get; set; }

	
    /// <summary>
    /// Flag to record whether the consigned country is in an ipaffs charge group
    /// </summary
    [Attr]
    [JsonPropertyName("consignedCountryInChargeGroup")]
    public bool? ConsignedCountryInChargeGroup { get; set; }

	
    /// <summary>
    /// The total gross weight of the consignment.  It must be bigger than the total net weight of the commodities
    /// </summary
    [Attr]
    [JsonPropertyName("totalGrossWeight")]
    public double? TotalGrossWeight { get; set; }

	
    /// <summary>
    /// The total net weight of the commodities within this consignment
    /// </summary
    [Attr]
    [JsonPropertyName("totalNetWeight")]
    public double? TotalNetWeight { get; set; }

	
    /// <summary>
    /// The total gross volume of the commodities within this consignment
    /// </summary
    [Attr]
    [JsonPropertyName("totalGrossVolume")]
    public double? TotalGrossVolume { get; set; }

	
    /// <summary>
    /// Unit used for specifying total gross volume of this consignment (litres or metres cubed)
    /// </summary
    [Attr]
    [JsonPropertyName("totalGrossVolumeUnit")]
    public string? TotalGrossVolumeUnit { get; set; }

	
    /// <summary>
    /// The total number of packages within this consignment
    /// </summary
    [Attr]
    [JsonPropertyName("numberOfPackages")]
    public int? NumberOfPackages { get; set; }

	
    /// <summary>
    /// Temperature (type) of commodity
    /// </summary
    [Attr]
    [JsonPropertyName("temperature")]
    public string? Temperature { get; set; }

	
    /// <summary>
    /// The total number of animals within this consignment
    /// </summary
    [Attr]
    [JsonPropertyName("numberOfAnimals")]
    public int? NumberOfAnimals { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("commodityComplement")]
    public IpaffsCommodityComplement[]? CommodityComplements { get; set; }

	
    /// <summary>
    /// Additional data for commodityComplement part containing such data as net weight
    /// </summary
    [Attr]
    [JsonPropertyName("complementParameterSet")]
    [MongoDB.Bson.Serialization.Attributes.BsonIgnore]
    public IpaffsComplementParameterSet[]? ComplementParameterSets { get; set; }

	
    /// <summary>
    /// Does consignment contain ablacted animals
    /// </summary
    [Attr]
    [JsonPropertyName("includeNonAblactedAnimals")]
    public bool? IncludeNonAblactedAnimals { get; set; }

	
    /// <summary>
    /// Consignments country of origin
    /// </summary
    [Attr]
    [JsonPropertyName("countryOfOrigin")]
    public string? CountryOfOrigin { get; set; }

	
    /// <summary>
    /// Flag to record whether country of origin is a temporary PoD country
    /// </summary
    [Attr]
    [JsonPropertyName("countryOfOriginIsPodCountry")]
    public bool? CountryOfOriginIsPodCountry { get; set; }

	
    /// <summary>
    /// Flag to record whether country of origin is a low risk article 72 country
    /// </summary
    [Attr]
    [JsonPropertyName("isLowRiskArticle72Country")]
    public bool? IsLowRiskArticle72Country { get; set; }

	
    /// <summary>
    /// Region of country
    /// </summary
    [Attr]
    [JsonPropertyName("regionOfOrigin")]
    public string? RegionOfOrigin { get; set; }

	
    /// <summary>
    /// Country from where commodity was sent
    /// </summary
    [Attr]
    [JsonPropertyName("consignedCountry")]
    public string? ConsignedCountry { get; set; }

	
    /// <summary>
    /// Certification of animals (Breeding, slaughter etc.)
    /// </summary
    [Attr]
    [JsonPropertyName("animalsCertifiedAs")]
    public string? AnimalsCertifiedAs { get; set; }

	
    /// <summary>
    /// What the commodity is intended for
    /// </summary
    [Attr]
    [JsonPropertyName("commodityIntendedFor")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsCommoditiesCommodityIntendedForEnum? CommodityIntendedFor { get; set; }

	}


