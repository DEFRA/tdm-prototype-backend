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


namespace Tdm.Model.Ipaffs;

/// <summary>
/// 
/// </summary>
public partial class IpaffsCommodities  //
{


    /// <summary>
    /// Flag to record when the GMS declaration has been accepted
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Flag to record when the GMS declaration has been accepted")]
    public bool? GmsDeclarationAccepted { get; set; }

	
    /// <summary>
    /// Flag to record whether the consigned country is in an ipaffs charge group
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Flag to record whether the consigned country is in an ipaffs charge group")]
    public bool? ConsignedCountryInChargeGroup { get; set; }

	
    /// <summary>
    /// The total gross weight of the consignment.  It must be bigger than the total net weight of the commodities
    /// </summary
    [Attr]
    [System.ComponentModel.Description("The total gross weight of the consignment.  It must be bigger than the total net weight of the commodities")]
    public double? TotalGrossWeight { get; set; }

	
    /// <summary>
    /// The total net weight of the commodities within this consignment
    /// </summary
    [Attr]
    [System.ComponentModel.Description("The total net weight of the commodities within this consignment")]
    public double? TotalNetWeight { get; set; }

	
    /// <summary>
    /// The total gross volume of the commodities within this consignment
    /// </summary
    [Attr]
    [System.ComponentModel.Description("The total gross volume of the commodities within this consignment")]
    public double? TotalGrossVolume { get; set; }

	
    /// <summary>
    /// Unit used for specifying total gross volume of this consignment (litres or metres cubed)
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Unit used for specifying total gross volume of this consignment (litres or metres cubed)")]
    public string? TotalGrossVolumeUnit { get; set; }

	
    /// <summary>
    /// The total number of packages within this consignment
    /// </summary
    [Attr]
    [System.ComponentModel.Description("The total number of packages within this consignment")]
    public int? NumberOfPackages { get; set; }

	
    /// <summary>
    /// Temperature (type) of commodity
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Temperature (type) of commodity")]
    public string? Temperature { get; set; }

	
    /// <summary>
    /// The total number of animals within this consignment
    /// </summary
    [Attr]
    [System.ComponentModel.Description("The total number of animals within this consignment")]
    public int? NumberOfAnimals { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [System.ComponentModel.Description("")]
    [MongoDB.Bson.Serialization.Attributes.BsonIgnore]
    public IpaffsCommodityComplement[]? CommodityComplements { get; set; }

	
    /// <summary>
    /// Additional data for commodityComplement part containing such data as net weight
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Additional data for commodityComplement part containing such data as net weight")]
    [MongoDB.Bson.Serialization.Attributes.BsonIgnore]
    public IpaffsComplementParameterSet[]? ComplementParameterSets { get; set; }

	
    /// <summary>
    /// Does consignment contain ablacted animals
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Does consignment contain ablacted animals")]
    public bool? IncludeNonAblactedAnimals { get; set; }

	
    /// <summary>
    /// Consignments country of origin
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Consignments country of origin")]
    public string? CountryOfOrigin { get; set; }

	
    /// <summary>
    /// Flag to record whether country of origin is a temporary PoD country
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Flag to record whether country of origin is a temporary PoD country")]
    public bool? CountryOfOriginIsPodCountry { get; set; }

	
    /// <summary>
    /// Flag to record whether country of origin is a low risk article 72 country
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Flag to record whether country of origin is a low risk article 72 country")]
    public bool? IsLowRiskArticle72Country { get; set; }

	
    /// <summary>
    /// Region of country
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Region of country")]
    public string? RegionOfOrigin { get; set; }

	
    /// <summary>
    /// Country from where commodity was sent
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Country from where commodity was sent")]
    public string? ConsignedCountry { get; set; }

	
    /// <summary>
    /// Certification of animals (Breeding, slaughter etc.)
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Certification of animals (Breeding, slaughter etc.)")]
    public string? AnimalsCertifiedAs { get; set; }

	
    /// <summary>
    /// What the commodity is intended for
    /// </summary
    [Attr]
    [System.ComponentModel.Description("What the commodity is intended for")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsCommoditiesCommodityIntendedForEnum? CommodityIntendedFor { get; set; }

	}

