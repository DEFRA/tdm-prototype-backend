
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Holder for additional parameters of a commodity
    /// </summary>
public partial class IpaffsCommodityComplement  {


        /// <summary>
        /// UUID used to match commodityComplement to its complementParameter set. CHEDPP only
        /// </summary>
        [Attr]
        [JsonPropertyName("uniqueComplementID")]
        public string UniqueComplementID { get; set; }
    
        /// <summary>
        /// Description of the commodity
        /// </summary>
        [Attr]
        [JsonPropertyName("commodityDescription")]
        public string CommodityDescription { get; set; }
    
        /// <summary>
        /// The unique commodity ID
        /// </summary>
        [Attr]
        [JsonPropertyName("commodityID")]
        public string CommodityID { get; set; }
    
        /// <summary>
        /// Identifier of complement chosen from speciesFamily,speciesClass and speciesType&#x27;. This is also used to link to the complementParameterSet
        /// </summary>
        [Attr]
        [JsonPropertyName("complementID")]
        public int ComplementID { get; set; }
    
        /// <summary>
        /// Represents the lowest granularity - either type, class, family or species name - for the commodity selected.  This is also used to drive behaviour for EU Import journeys
        /// </summary>
        [Attr]
        [JsonPropertyName("complementName")]
        public string ComplementName { get; set; }
    
        /// <summary>
        /// EPPO Code related to plant commodities and wood packaging
        /// </summary>
        [Attr]
        [JsonPropertyName("eppoCode")]
        public string EppoCode { get; set; }
    
        /// <summary>
        /// (Deprecated in IMTA-11832) Is this commodity wood packaging?
        /// </summary>
        [Attr]
        [JsonPropertyName("isWoodPackaging")]
        public bool IsWoodPackaging { get; set; }
    
        /// <summary>
        /// The species ID of the commodity that is imported. Not every commodity has a species ID. This is also used to link to the complementParameterSet. The species ID can change over time
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesID")]
        public string SpeciesID { get; set; }
    
        /// <summary>
        /// Species name
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesName")]
        public string SpeciesName { get; set; }
    
        /// <summary>
        /// Species nomination
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesNomination")]
        public string SpeciesNomination { get; set; }
    
        /// <summary>
        /// Species type name
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesTypeName")]
        public string SpeciesTypeName { get; set; }
    
        /// <summary>
        /// Species type identifier of commodity
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesType")]
        public string SpeciesType { get; set; }
    
        /// <summary>
        /// Species class name
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesClassName")]
        public string SpeciesClassName { get; set; }
    
        /// <summary>
        /// Species class identifier of commodity
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesClass")]
        public string SpeciesClass { get; set; }
    
        /// <summary>
        /// Species family name of commodity
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesFamilyName")]
        public string SpeciesFamilyName { get; set; }
    
        /// <summary>
        /// Species family identifier of commodity
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesFamily")]
        public string SpeciesFamily { get; set; }
    
        /// <summary>
        /// Species common name of commodity for IMP notification simple commodity selection
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesCommonName")]
        public string SpeciesCommonName { get; set; }
    
        /// <summary>
        /// Has commodity been matched with corresponding CDS declaration
        /// </summary>
        [Attr]
        [JsonPropertyName("isCdsMatched")]
        public bool IsCdsMatched { get; set; }
    
}


