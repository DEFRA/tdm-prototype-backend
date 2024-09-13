
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Part 2 of notification - Decision at inspection
    /// </summary>
public partial class IpaffsPartTwo  {


        /// <summary>
        /// Decision on the consignment
        /// </summary>
        [Attr]
        [JsonPropertyName("decision")]
        public IpaffsDecision Decision { get; set; }
    
        /// <summary>
        /// Consignment check
        /// </summary>
        [Attr]
        [JsonPropertyName("consignmentCheck")]
        public IpaffsConsignmentCheck ConsignmentCheck { get; set; }
    
        /// <summary>
        /// Checks of impact of transport on animals
        /// </summary>
        [Attr]
        [JsonPropertyName("impactOfTransportOnAnimals")]
        public IpaffsImpactOfTransportOnAnimals ImpactOfTransportOnAnimals { get; set; }
    
        /// <summary>
        /// Are laboratory tests required
        /// </summary>
        [Attr]
        [JsonPropertyName("laboratoryTestsRequired")]
        public bool LaboratoryTestsRequired { get; set; }
    
        /// <summary>
        /// Laboratory tests information details
        /// </summary>
        [Attr]
        [JsonPropertyName("laboratoryTests")]
        public IpaffsLaboratoryTests LaboratoryTests { get; set; }
    
        /// <summary>
        /// Are the containers resealed
        /// </summary>
        [Attr]
        [JsonPropertyName("resealedContainersIncluded")]
        public bool ResealedContainersIncluded { get; set; }
    
        /// <summary>
        /// (Deprecated - To be removed as part of IMTA-6256) Resealed containers information details
        /// </summary>
        [Attr]
        [JsonPropertyName("resealedContainers")]
        public string[][] ResealedContainers { get; set; }
    
        /// <summary>
        /// Resealed containers information details
        /// </summary>
        [Attr]
        [JsonPropertyName("resealedContainersMapping")]
        public IpaffsSealContainer[] ResealedContainersMappings { get; set; }
    
        /// <summary>
        /// Control Authority information details
        /// </summary>
        [Attr]
        [JsonPropertyName("controlAuthority")]
        public IpaffsControlAuthority ControlAuthority { get; set; }
    
        /// <summary>
        /// Controlled destination
        /// </summary>
        [Attr]
        [JsonPropertyName("controlledDestination")]
        public IpaffsEconomicOperator ControlledDestination { get; set; }
    
        /// <summary>
        /// Local reference number at BIP
        /// </summary>
        [Attr]
        [JsonPropertyName("bipLocalReferenceNumber")]
        public string BipLocalReferenceNumber { get; set; }
    
        /// <summary>
        /// Part 2 - Sometimes other user can sign decision on behalf of another user
        /// </summary>
        [Attr]
        [JsonPropertyName("signedOnBehalfOf")]
        public string SignedOnBehalfOf { get; set; }
    
        /// <summary>
        /// Onward transportation
        /// </summary>
        [Attr]
        [JsonPropertyName("onwardTransportation")]
        public string OnwardTransportation { get; set; }
    
        /// <summary>
        /// Validation messages for Part 2 - Decision
        /// </summary>
        [Attr]
        [JsonPropertyName("consignmentValidation")]
        public IpaffsValidationMessageCode[] ConsignmentValidations { get; set; }
    
        /// <summary>
        /// User entered date when the checks were completed
        /// </summary>
        [Attr]
        [JsonPropertyName("checkDate")]
        public string CheckDate { get; set; }
    
        /// <summary>
        /// Accompanying documents
        /// </summary>
        [Attr]
        [JsonPropertyName("accompanyingDocuments")]
        public IpaffsAccompanyingDocument[] AccompanyingDocuments { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("commodityChecks")]
        public IpaffsCommodityChecks[] CommodityChecks { get; set; }
    
        /// <summary>
        /// Have the PHSI regulated commodities been auto cleared?
        /// </summary>
        [Attr]
        [JsonPropertyName("phsiAutoCleared")]
        public bool PhsiAutoCleared { get; set; }
    
        /// <summary>
        /// Have the HMI regulated commodities been auto cleared?
        /// </summary>
        [Attr]
        [JsonPropertyName("hmiAutoCleared")]
        public bool HmiAutoCleared { get; set; }
    
        /// <summary>
        /// Inspection required
        /// </summary>
        [Attr]
        [JsonPropertyName("inspectionRequired")]
        public string InspectionRequired { get; set; }
    
        /// <summary>
        /// Details about the manual inspection override
        /// </summary>
        [Attr]
        [JsonPropertyName("inspectionOverride")]
        public IpaffsInspectionOverride InspectionOverride { get; set; }
    
        /// <summary>
        /// Date of autoclearance
        /// </summary>
        [Attr]
        [JsonPropertyName("autoClearedDateTime")]
        public string AutoClearedDateTime { get; set; }
    
}

