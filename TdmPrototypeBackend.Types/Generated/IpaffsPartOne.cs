
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// 
    /// </summary>
public partial class IpaffsPartOne  {


        /// <summary>
        /// Used to indicate what type of EU Import the notification is - Live Animals, Product Of Animal Origin or High Risk Food Not Of Animal Origin
        /// </summary>
        [Attr]
        [JsonPropertyName("typeOfImp")]
        public IpaffsTypeOfImpEnum TypeOfImp { get; set; }
    
        /// <summary>
        /// The individual who has submitted the notification
        /// </summary>
        [Attr]
        [JsonPropertyName("personResponsible")]
        public IpaffsParty PersonResponsible { get; set; }
    
        /// <summary>
        /// Customs reference number
        /// </summary>
        [Attr]
        [JsonPropertyName("customsReferenceNumber")]
        public string CustomsReferenceNumber { get; set; }
    
        /// <summary>
        /// (Deprecated in IMTA-11832) Does the consignment contain wood packaging?
        /// </summary>
        [Attr]
        [JsonPropertyName("containsWoodPackaging")]
        public bool ContainsWoodPackaging { get; set; }
    
        /// <summary>
        /// Has the consignment arrived at the BCP?
        /// </summary>
        [Attr]
        [JsonPropertyName("consignmentArrived")]
        public bool ConsignmentArrived { get; set; }
    
        /// <summary>
        /// Person or Company that sends shipment
        /// </summary>
        [Attr]
        [JsonPropertyName("consignor")]
        public IpaffsEconomicOperator Consignor { get; set; }
    
        /// <summary>
        /// Person or Company that sends shipment
        /// </summary>
        [Attr]
        [JsonPropertyName("consignorTwo")]
        public IpaffsEconomicOperator ConsignorTwo { get; set; }
    
        /// <summary>
        /// Person or Company that packs the shipment
        /// </summary>
        [Attr]
        [JsonPropertyName("packer")]
        public IpaffsEconomicOperator Packer { get; set; }
    
        /// <summary>
        /// Person or Company that receives shipment
        /// </summary>
        [Attr]
        [JsonPropertyName("consignee")]
        public IpaffsEconomicOperator Consignee { get; set; }
    
        /// <summary>
        /// Person or Company that is importing the consignment
        /// </summary>
        [Attr]
        [JsonPropertyName("importer")]
        public IpaffsEconomicOperator Importer { get; set; }
    
        /// <summary>
        /// Where the shipment is to be sent? For IMP minimum 48 hour accommodation/holding location.
        /// </summary>
        [Attr]
        [JsonPropertyName("placeOfDestination")]
        public IpaffsEconomicOperator PlaceOfDestination { get; set; }
    
        /// <summary>
        /// A temporary place of destination for plants
        /// </summary>
        [Attr]
        [JsonPropertyName("pod")]
        public IpaffsEconomicOperator Pod { get; set; }
    
        /// <summary>
        /// Place in which the animals or products originate
        /// </summary>
        [Attr]
        [JsonPropertyName("placeOfOriginHarvest")]
        public IpaffsEconomicOperator PlaceOfOriginHarvest { get; set; }
    
        /// <summary>
        /// List of additional permanent addresses
        /// </summary>
        [Attr]
        [JsonPropertyName("additionalPermanentAddresses")]
        public IpaffsEconomicOperator[] AdditionalPermanentAddresses { get; set; }
    
        /// <summary>
        /// Charity Parish Holding number
        /// </summary>
        [Attr]
        [JsonPropertyName("cphNumber")]
        public string CphNumber { get; set; }
    
        /// <summary>
        /// Is the importer importing from a charity?
        /// </summary>
        [Attr]
        [JsonPropertyName("importingFromCharity")]
        public bool ImportingFromCharity { get; set; }
    
        /// <summary>
        /// Is the place of destination the permanent address?
        /// </summary>
        [Attr]
        [JsonPropertyName("isPlaceOfDestinationThePermanentAddress")]
        public bool IsPlaceOfDestinationThePermanentAddress { get; set; }
    
        /// <summary>
        /// Is this catch certificate required?
        /// </summary>
        [Attr]
        [JsonPropertyName("isCatchCertificateRequired")]
        public bool IsCatchCertificateRequired { get; set; }
    
        /// <summary>
        /// Is GVMS route?
        /// </summary>
        [Attr]
        [JsonPropertyName("isGVMSRoute")]
        public bool IsGVMSRoute { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("commodities")]
        public IpaffsCommodities Commodities { get; set; }
    
        /// <summary>
        /// Purpose of consignment details
        /// </summary>
        [Attr]
        [JsonPropertyName("purpose")]
        public IpaffsPurpose Purpose { get; set; }
    
        /// <summary>
        /// Either a Border-Inspection-Post or Designated-Point-Of-Entry, e.g. GBFXT1
        /// </summary>
        [Attr]
        [JsonPropertyName("pointOfEntry")]
        public string PointOfEntry { get; set; }
    
        /// <summary>
        /// A control point at the point of entry
        /// </summary>
        [Attr]
        [JsonPropertyName("pointOfEntryControlPoint")]
        public string PointOfEntryControlPoint { get; set; }
    
        /// <summary>
        /// Date when consignment arrives
        /// </summary>
        [Attr]
        [JsonPropertyName("arrivalDate")]
        public string ArrivalDate { get; set; }
    
        /// <summary>
        /// Time (HH:MM) when consignment arrives
        /// </summary>
        [Attr]
        [JsonPropertyName("arrivalTime")]
        public string ArrivalTime { get; set; }
    
        /// <summary>
        /// How consignment is transported after BIP
        /// </summary>
        [Attr]
        [JsonPropertyName("meansOfTransport")]
        public IpaffsMeansOfTransport MeansOfTransport { get; set; }
    
        /// <summary>
        /// Transporter of consignment details
        /// </summary>
        [Attr]
        [JsonPropertyName("transporter")]
        public IpaffsEconomicOperator Transporter { get; set; }
    
        /// <summary>
        /// Are transporter details required for this consignment
        /// </summary>
        [Attr]
        [JsonPropertyName("transporterDetailsRequired")]
        public bool TransporterDetailsRequired { get; set; }
    
        /// <summary>
        /// Transport to BIP
        /// </summary>
        [Attr]
        [JsonPropertyName("meansOfTransportFromEntryPoint")]
        public IpaffsMeansOfTransport MeansOfTransportFromEntryPoint { get; set; }
    
        /// <summary>
        /// Date of consignment departure
        /// </summary>
        [Attr]
        [JsonPropertyName("departureDate")]
        public string DepartureDate { get; set; }
    
        /// <summary>
        /// Time (HH:MM) of consignment departure
        /// </summary>
        [Attr]
        [JsonPropertyName("departureTime")]
        public string DepartureTime { get; set; }
    
        /// <summary>
        /// Estimated journey time in minutes to point of entry
        /// </summary>
        [Attr]
        [JsonPropertyName("estimatedJourneyTimeInMinutes")]
        public double EstimatedJourneyTimeInMinutes { get; set; }
    
        /// <summary>
        /// (Deprecated in IMTA-12139) Person who is responsible for transport
        /// </summary>
        [Attr]
        [JsonPropertyName("responsibleForTransport")]
        public string ResponsibleForTransport { get; set; }
    
        /// <summary>
        /// Part 1 - Holds the information related to veterinary checks and details
        /// </summary>
        [Attr]
        [JsonPropertyName("veterinaryInformation")]
        public IpaffsVeterinaryInformation VeterinaryInformation { get; set; }
    
        /// <summary>
        /// Reference number added by the importer
        /// </summary>
        [Attr]
        [JsonPropertyName("importerLocalReferenceNumber")]
        public string ImporterLocalReferenceNumber { get; set; }
    
        /// <summary>
        /// Contains countries and transfer points that consignment is going through
        /// </summary>
        [Attr]
        [JsonPropertyName("route")]
        public IpaffsRoute Route { get; set; }
    
        /// <summary>
        /// Array that contains pair of seal number and container number
        /// </summary>
        [Attr]
        [JsonPropertyName("sealsContainers")]
        public IpaffsSealContainer[] SealsContainers { get; set; }
    
        /// <summary>
        /// Date and time when the notification was submitted
        /// </summary>
        [Attr]
        [JsonPropertyName("submissionDate")]
        public string SubmissionDate { get; set; }
    
        /// <summary>
        /// Information about user who submitted notification
        /// </summary>
        [Attr]
        [JsonPropertyName("submittedBy")]
        public IpaffsUserInformation SubmittedBy { get; set; }
    
        /// <summary>
        /// Validation messages for whole notification
        /// </summary>
        [Attr]
        [JsonPropertyName("consignmentValidation")]
        public IpaffsValidationMessageCode[] ConsignmentValidations { get; set; }
    
        /// <summary>
        /// Was complex commodity selected. Indicating if importer provided commodity code.
        /// </summary>
        [Attr]
        [JsonPropertyName("complexCommoditySelected")]
        public bool ComplexCommoditySelected { get; set; }
    
        /// <summary>
        /// Entry port for EU Import notification.
        /// </summary>
        [Attr]
        [JsonPropertyName("portOfEntry")]
        public string PortOfEntry { get; set; }
    
        /// <summary>
        /// Exit Port for EU Import Notification.
        /// </summary>
        [Attr]
        [JsonPropertyName("portOfExit")]
        public string PortOfExit { get; set; }
    
        /// <summary>
        /// Date of Port Exit for EU Import Notification.
        /// </summary>
        [Attr]
        [JsonPropertyName("portOfExitDate")]
        public string PortOfExitDate { get; set; }
    
        /// <summary>
        /// Person to be contacted if there is an issue with the consignment
        /// </summary>
        [Attr]
        [JsonPropertyName("contactDetails")]
        public IpaffsContactDetails ContactDetails { get; set; }
    
        /// <summary>
        /// List of nominated contacts to receive text and email notifications
        /// </summary>
        [Attr]
        [JsonPropertyName("nominatedContacts")]
        public IpaffsNominatedContact[] NominatedContacts { get; set; }
    
        /// <summary>
        /// Original estimated date time of arrival
        /// </summary>
        [Attr]
        [JsonPropertyName("originalEstimatedDateTime")]
        public string OriginalEstimatedDateTime { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("billingInformation")]
        public IpaffsBillingInformation BillingInformation { get; set; }
    
        /// <summary>
        /// Indicates whether CUC applies to the notification
        /// </summary>
        [Attr]
        [JsonPropertyName("isChargeable")]
        public bool IsChargeable { get; set; }
    
        /// <summary>
        /// Indicates whether CUC previously applied to the notification
        /// </summary>
        [Attr]
        [JsonPropertyName("wasChargeable")]
        public bool WasChargeable { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("commonUserCharge")]
        public IpaffsCommonUserCharge CommonUserCharge { get; set; }
    
        /// <summary>
        /// When the NCTS MRN will be added for the Common Transit Convention (CTC)
        /// </summary>
        [Attr]
        [JsonPropertyName("provideCtcMrn")]
        public IpaffsProvideCtcMrnEnum ProvideCtcMrn { get; set; }
    
}

