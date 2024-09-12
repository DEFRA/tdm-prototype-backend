
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Part 2 of notification - Decision at inspection
    /// </summary>
public partial class PartTwoDto  {


        /// <summary>
        /// Decision on the consignment
        /// </summary>
        [Attr]
        [JsonProperty("decision", NullValueHandling = NullValueHandling.Ignore)]
        public DecisionDto Decision { get; set; }
    
        /// <summary>
        /// Consignment check
        /// </summary>
        [Attr]
        [JsonProperty("consignmentCheck", NullValueHandling = NullValueHandling.Ignore)]
        public ConsignmentCheckDto ConsignmentCheck { get; set; }
    
        /// <summary>
        /// Checks of impact of transport on animals
        /// </summary>
        [Attr]
        [JsonProperty("impactOfTransportOnAnimals", NullValueHandling = NullValueHandling.Ignore)]
        public ImpactOfTransportOnAnimalsDto ImpactOfTransportOnAnimals { get; set; }
    
        /// <summary>
        /// Are laboratory tests required
        /// </summary>
        [Attr]
        [JsonProperty("laboratoryTestsRequired", NullValueHandling = NullValueHandling.Ignore)]
        public bool LaboratoryTestsRequired { get; set; }
    
        /// <summary>
        /// Laboratory tests information details
        /// </summary>
        [Attr]
        [JsonProperty("laboratoryTests", NullValueHandling = NullValueHandling.Ignore)]
        public LaboratoryTestsDto LaboratoryTests { get; set; }
    
        /// <summary>
        /// Are the containers resealed
        /// </summary>
        [Attr]
        [JsonProperty("resealedContainersIncluded", NullValueHandling = NullValueHandling.Ignore)]
        public bool ResealedContainersIncluded { get; set; }
    
        /// <summary>
        /// (Deprecated - To be removed as part of IMTA-6256) Resealed containers information details
        /// </summary>
        [Attr]
        [JsonProperty("resealedContainers", NullValueHandling = NullValueHandling.Ignore)]
        public string[][] ResealedContainers { get; set; }
    
        /// <summary>
        /// Resealed containers information details
        /// </summary>
        [Attr]
        [JsonProperty("resealedContainersMapping", NullValueHandling = NullValueHandling.Ignore)]
        public SealContainerDto[] ResealedContainersMapping { get; set; }
    
        /// <summary>
        /// Control Authority information details
        /// </summary>
        [Attr]
        [JsonProperty("controlAuthority", NullValueHandling = NullValueHandling.Ignore)]
        public ControlAuthorityDto ControlAuthority { get; set; }
    
        /// <summary>
        /// Controlled destination
        /// </summary>
        [Attr]
        [JsonProperty("controlledDestination", NullValueHandling = NullValueHandling.Ignore)]
        public EconomicOperatorDto ControlledDestination { get; set; }
    
        /// <summary>
        /// Local reference number at BIP
        /// </summary>
        [Attr]
        [JsonProperty("bipLocalReferenceNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string BipLocalReferenceNumber { get; set; }
    
        /// <summary>
        /// Part 2 - Sometimes other user can sign decision on behalf of another user
        /// </summary>
        [Attr]
        [JsonProperty("signedOnBehalfOf", NullValueHandling = NullValueHandling.Ignore)]
        public string SignedOnBehalfOf { get; set; }
    
        /// <summary>
        /// Onward transportation
        /// </summary>
        [Attr]
        [JsonProperty("onwardTransportation", NullValueHandling = NullValueHandling.Ignore)]
        public string OnwardTransportation { get; set; }
    
        /// <summary>
        /// Validation messages for Part 2 - Decision
        /// </summary>
        [Attr]
        [JsonProperty("consignmentValidation", NullValueHandling = NullValueHandling.Ignore)]
        public ValidationMessageCodeDto[] ConsignmentValidation { get; set; }
    
        /// <summary>
        /// User entered date when the checks were completed
        /// </summary>
        [Attr]
        [JsonProperty("checkDate", NullValueHandling = NullValueHandling.Ignore)]
        public string CheckDate { get; set; }
    
        /// <summary>
        /// Accompanying documents
        /// </summary>
        [Attr]
        [JsonProperty("accompanyingDocuments", NullValueHandling = NullValueHandling.Ignore)]
        public AccompanyingDocumentDto[] AccompanyingDocuments { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonProperty("commodityChecks", NullValueHandling = NullValueHandling.Ignore)]
        public CommodityChecksDto[] CommodityChecks { get; set; }
    
        /// <summary>
        /// Have the PHSI regulated commodities been auto cleared?
        /// </summary>
        [Attr]
        [JsonProperty("phsiAutoCleared", NullValueHandling = NullValueHandling.Ignore)]
        public bool PhsiAutoCleared { get; set; }
    
        /// <summary>
        /// Have the HMI regulated commodities been auto cleared?
        /// </summary>
        [Attr]
        [JsonProperty("hmiAutoCleared", NullValueHandling = NullValueHandling.Ignore)]
        public bool HmiAutoCleared { get; set; }
    
        /// <summary>
        /// Inspection required
        /// </summary>
        [Attr]
        [JsonProperty("inspectionRequired", NullValueHandling = NullValueHandling.Ignore)]
        public string InspectionRequired { get; set; }
    
        /// <summary>
        /// Details about the manual inspection override
        /// </summary>
        [Attr]
        [JsonProperty("inspectionOverride", NullValueHandling = NullValueHandling.Ignore)]
        public InspectionOverrideDto InspectionOverride { get; set; }
    
        /// <summary>
        /// Date of autoclearance
        /// </summary>
        [Attr]
        [JsonProperty("autoClearedDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public string AutoClearedDateTime { get; set; }
    
}


