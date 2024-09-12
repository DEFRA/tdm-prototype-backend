
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Decision if the consignment can be imported
    /// </summary>
public partial class DecisionDto  {


        /// <summary>
        /// Is consignment acceptable or not
        /// </summary>
        [Attr]
        [JsonProperty("consignmentAcceptable", NullValueHandling = NullValueHandling.Ignore)]
        public bool ConsignmentAcceptable { get; set; }
    
        /// <summary>
        /// Filled if consignmentAcceptable is set to false
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableAction", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableAction { get; set; }
    
        /// <summary>
        /// Filled if not acceptable action is set to destruction
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableActionDestructionReason", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableActionDestructionReason { get; set; }
    
        /// <summary>
        /// Filled if not acceptable action is set to entry refusal
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableActionEntryRefusalReason", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableActionEntryRefusalReason { get; set; }
    
        /// <summary>
        /// Filled if not acceptable action is set to quarantine imposed
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableActionQuarantineImposedReason", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableActionQuarantineImposedReason { get; set; }
    
        /// <summary>
        /// Filled if not acceptable action is set to special treatment
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableActionSpecialTreatmentReason", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableActionSpecialTreatmentReason { get; set; }
    
        /// <summary>
        /// Filled if not acceptable action is set to industrial processing
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableActionIndustrialProcessingReason", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableActionIndustrialProcessingReason { get; set; }
    
        /// <summary>
        /// Filled if not acceptable action is set to re-dispatch
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableActionReDispatchReason", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableActionReDispatchReason { get; set; }
    
        /// <summary>
        /// Filled if not acceptable action is set to use for other purposes
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableActionUseForOtherPurposesReason", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableActionUseForOtherPurposesReason { get; set; }
    
        /// <summary>
        /// Filled when notAcceptableAction is equal to destruction
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableDestructionReason", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableDestructionReason { get; set; }
    
        /// <summary>
        /// Filled when notAcceptableAction is equal to other
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableActionOtherReason", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableActionOtherReason { get; set; }
    
        /// <summary>
        /// Filled when consignmentAcceptable is set to false
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableActionByDate", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableActionByDate { get; set; }
    
        /// <summary>
        /// List of details for individual chedpp not acceptable reasons
        /// </summary>
        [Attr]
        [JsonProperty("chedppNotAcceptableReasons", NullValueHandling = NullValueHandling.Ignore)]
        public ChedppNotAcceptableReasonDto[] ChedppNotAcceptableReasons { get; set; }
    
        /// <summary>
        /// If the consignment was not accepted what was the reason
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableReasons", NullValueHandling = NullValueHandling.Ignore)]
        public string[][] NotAcceptableReasons { get; set; }
    
        /// <summary>
        /// 2 digits ISO code of country (not acceptable country can be empty)
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableCountry { get; set; }
    
        /// <summary>
        /// Filled if consignmentAcceptable is set to false
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableEstablishment", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableEstablishment { get; set; }
    
        /// <summary>
        /// Filled if consignmentAcceptable is set to false
        /// </summary>
        [Attr]
        [JsonProperty("notAcceptableOtherReason", NullValueHandling = NullValueHandling.Ignore)]
        public string NotAcceptableOtherReason { get; set; }
    
        /// <summary>
        /// Details of controlled destinations
        /// </summary>
        [Attr]
        [JsonProperty("detailsOfControlledDestinations", NullValueHandling = NullValueHandling.Ignore)]
        public PartyDto DetailsOfControlledDestinations { get; set; }
    
        /// <summary>
        /// Filled if consignment is set to acceptable and decision type is Specific Warehouse
        /// </summary>
        [Attr]
        [JsonProperty("specificWarehouseNonConformingConsignment", NullValueHandling = NullValueHandling.Ignore)]
        public string SpecificWarehouseNonConformingConsignment { get; set; }
    
        /// <summary>
        /// Deadline when consignment has to leave borders
        /// </summary>
        [Attr]
        [JsonProperty("temporaryDeadline", NullValueHandling = NullValueHandling.Ignore)]
        public string TemporaryDeadline { get; set; }
    
        /// <summary>
        /// Detailed decision for consignment
        /// </summary>
        [Attr]
        [JsonProperty("decision", NullValueHandling = NullValueHandling.Ignore)]
        public string Decision { get; set; }
    
        /// <summary>
        /// Decision over purpose of free circulation in country
        /// </summary>
        [Attr]
        [JsonProperty("freeCirculationPurpose", NullValueHandling = NullValueHandling.Ignore)]
        public string FreeCirculationPurpose { get; set; }
    
        /// <summary>
        /// Decision over purpose of definitive import
        /// </summary>
        [Attr]
        [JsonProperty("definitiveImportPurpose", NullValueHandling = NullValueHandling.Ignore)]
        public string DefinitiveImportPurpose { get; set; }
    
        /// <summary>
        /// Decision channeled option based on (article8, article15)
        /// </summary>
        [Attr]
        [JsonProperty("ifChanneledOption", NullValueHandling = NullValueHandling.Ignore)]
        public string IfChanneledOption { get; set; }
    
        /// <summary>
        /// Custom warehouse registered number
        /// </summary>
        [Attr]
        [JsonProperty("customWarehouseRegisteredNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomWarehouseRegisteredNumber { get; set; }
    
        /// <summary>
        /// Free warehouse registered number
        /// </summary>
        [Attr]
        [JsonProperty("freeWarehouseRegisteredNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string FreeWarehouseRegisteredNumber { get; set; }
    
        /// <summary>
        /// Ship name
        /// </summary>
        [Attr]
        [JsonProperty("shipName", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipName { get; set; }
    
        /// <summary>
        /// Port of exit
        /// </summary>
        [Attr]
        [JsonProperty("shipPortOfExit", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipPortOfExit { get; set; }
    
        /// <summary>
        /// Ship supplier registered number
        /// </summary>
        [Attr]
        [JsonProperty("shipSupplierRegisteredNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipSupplierRegisteredNumber { get; set; }
    
        /// <summary>
        /// Transhipment BIP
        /// </summary>
        [Attr]
        [JsonProperty("transhipmentBip", NullValueHandling = NullValueHandling.Ignore)]
        public string TranshipmentBip { get; set; }
    
        /// <summary>
        /// Transhipment third country
        /// </summary>
        [Attr]
        [JsonProperty("transhipmentThirdCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string TranshipmentThirdCountry { get; set; }
    
        /// <summary>
        /// Transit exit BIP
        /// </summary>
        [Attr]
        [JsonProperty("transitExitBip", NullValueHandling = NullValueHandling.Ignore)]
        public string TransitExitBip { get; set; }
    
        /// <summary>
        /// Transit third country
        /// </summary>
        [Attr]
        [JsonProperty("transitThirdCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string TransitThirdCountry { get; set; }
    
        /// <summary>
        /// Transit destination third country
        /// </summary>
        [Attr]
        [JsonProperty("transitDestinationThirdCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string TransitDestinationThirdCountry { get; set; }
    
        /// <summary>
        /// Temporary exit BIP
        /// </summary>
        [Attr]
        [JsonProperty("temporaryExitBip", NullValueHandling = NullValueHandling.Ignore)]
        public string TemporaryExitBip { get; set; }
    
        /// <summary>
        /// Horse re-entry
        /// </summary>
        [Attr]
        [JsonProperty("horseReentry", NullValueHandling = NullValueHandling.Ignore)]
        public string HorseReentry { get; set; }
    
        /// <summary>
        /// Is it transshipped to EU or third country (values EU / country name)
        /// </summary>
        [Attr]
        [JsonProperty("transhipmentEuOrThirdCountry", NullValueHandling = NullValueHandling.Ignore)]
        public string TranshipmentEuOrThirdCountry { get; set; }
    
}


