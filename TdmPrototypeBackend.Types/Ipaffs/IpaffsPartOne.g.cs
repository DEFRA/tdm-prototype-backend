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
public partial class IpaffsPartOne  //
{


    /// <summary>
    /// Used to indicate what type of EU Import the notification is - Live Animals, Product Of Animal Origin or High Risk Food Not Of Animal Origin
    /// </summary
    [Attr]
    [JsonPropertyName("typeOfImp")]
    [System.ComponentModel.Description("Used to indicate what type of EU Import the notification is - Live Animals, Product Of Animal Origin or High Risk Food Not Of Animal Origin")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsPartOneTypeOfImpEnum? TypeOfImp { get; set; }

	
    /// <summary>
    /// The individual who has submitted the notification
    /// </summary
    [Attr]
    [JsonPropertyName("personResponsible")]
    [System.ComponentModel.Description("The individual who has submitted the notification")]
    public IpaffsParty? PersonResponsible { get; set; }

	
    /// <summary>
    /// Customs reference number
    /// </summary
    [Attr]
    [JsonPropertyName("customsReferenceNumber")]
    [System.ComponentModel.Description("Customs reference number")]
    public string? CustomsReferenceNumber { get; set; }

	
    /// <summary>
    /// (Deprecated in IMTA-11832) Does the consignment contain wood packaging?
    /// </summary
    [Attr]
    [JsonPropertyName("containsWoodPackaging")]
    [System.ComponentModel.Description("(Deprecated in IMTA-11832) Does the consignment contain wood packaging?")]
    public bool? ContainsWoodPackaging { get; set; }

	
    /// <summary>
    /// Has the consignment arrived at the BCP?
    /// </summary
    [Attr]
    [JsonPropertyName("consignmentArrived")]
    [System.ComponentModel.Description("Has the consignment arrived at the BCP?")]
    public bool? ConsignmentArrived { get; set; }

	
    /// <summary>
    /// Person or Company that sends shipment
    /// </summary
    [Attr]
    [JsonPropertyName("consignor")]
    [System.ComponentModel.Description("Person or Company that sends shipment")]
    public IpaffsEconomicOperator? Consignor { get; set; }

	
    /// <summary>
    /// Person or Company that sends shipment
    /// </summary
    [Attr]
    [JsonPropertyName("consignorTwo")]
    [System.ComponentModel.Description("Person or Company that sends shipment")]
    public IpaffsEconomicOperator? ConsignorTwo { get; set; }

	
    /// <summary>
    /// Person or Company that packs the shipment
    /// </summary
    [Attr]
    [JsonPropertyName("packer")]
    [System.ComponentModel.Description("Person or Company that packs the shipment")]
    public IpaffsEconomicOperator? Packer { get; set; }

	
    /// <summary>
    /// Person or Company that receives shipment
    /// </summary
    [Attr]
    [JsonPropertyName("consignee")]
    [System.ComponentModel.Description("Person or Company that receives shipment")]
    public IpaffsEconomicOperator? Consignee { get; set; }

	
    /// <summary>
    /// Person or Company that is importing the consignment
    /// </summary
    [Attr]
    [JsonPropertyName("importer")]
    [System.ComponentModel.Description("Person or Company that is importing the consignment")]
    public IpaffsEconomicOperator? Importer { get; set; }

	
    /// <summary>
    /// Where the shipment is to be sent? For IMP minimum 48 hour accommodation/holding location.
    /// </summary
    [Attr]
    [JsonPropertyName("placeOfDestination")]
    [System.ComponentModel.Description("Where the shipment is to be sent? For IMP minimum 48 hour accommodation/holding location.")]
    public IpaffsEconomicOperator? PlaceOfDestination { get; set; }

	
    /// <summary>
    /// A temporary place of destination for plants
    /// </summary
    [Attr]
    [JsonPropertyName("pod")]
    [System.ComponentModel.Description("A temporary place of destination for plants")]
    public IpaffsEconomicOperator? Pod { get; set; }

	
    /// <summary>
    /// Place in which the animals or products originate
    /// </summary
    [Attr]
    [JsonPropertyName("placeOfOriginHarvest")]
    [System.ComponentModel.Description("Place in which the animals or products originate")]
    public IpaffsEconomicOperator? PlaceOfOriginHarvest { get; set; }

	
    /// <summary>
    /// List of additional permanent addresses
    /// </summary
    [Attr]
    [JsonPropertyName("additionalPermanentAddresses")]
    [System.ComponentModel.Description("List of additional permanent addresses")]
    public IpaffsEconomicOperator[]? AdditionalPermanentAddresses { get; set; }

	
    /// <summary>
    /// Charity Parish Holding number
    /// </summary
    [Attr]
    [JsonPropertyName("cphNumber")]
    [System.ComponentModel.Description("Charity Parish Holding number")]
    public string? CphNumber { get; set; }

	
    /// <summary>
    /// Is the importer importing from a charity?
    /// </summary
    [Attr]
    [JsonPropertyName("importingFromCharity")]
    [System.ComponentModel.Description("Is the importer importing from a charity?")]
    public bool? ImportingFromCharity { get; set; }

	
    /// <summary>
    /// Is the place of destination the permanent address?
    /// </summary
    [Attr]
    [JsonPropertyName("isPlaceOfDestinationThePermanentAddress")]
    [System.ComponentModel.Description("Is the place of destination the permanent address?")]
    public bool? IsPlaceOfDestinationThePermanentAddress { get; set; }

	
    /// <summary>
    /// Is this catch certificate required?
    /// </summary
    [Attr]
    [JsonPropertyName("isCatchCertificateRequired")]
    [System.ComponentModel.Description("Is this catch certificate required?")]
    public bool? IsCatchCertificateRequired { get; set; }

	
    /// <summary>
    /// Is GVMS route?
    /// </summary
    [Attr]
    [JsonPropertyName("isGVMSRoute")]
    [System.ComponentModel.Description("Is GVMS route?")]
    public bool? IsGvmsRoute { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("commodities")]
    [System.ComponentModel.Description("")]
    [MongoDB.Bson.Serialization.Attributes.BsonIgnore]
    public IpaffsCommodities? Commodities { get; set; }

	
    /// <summary>
    /// Purpose of consignment details
    /// </summary
    [Attr]
    [JsonPropertyName("purpose")]
    [System.ComponentModel.Description("Purpose of consignment details")]
    public IpaffsPurpose? Purpose { get; set; }

	
    /// <summary>
    /// Either a Border-Inspection-Post or Designated-Point-Of-Entry, e.g. GBFXT1
    /// </summary
    [Attr]
    [JsonPropertyName("pointOfEntry")]
    [System.ComponentModel.Description("Either a Border-Inspection-Post or Designated-Point-Of-Entry, e.g. GBFXT1")]
    public string? PointOfEntry { get; set; }

	
    /// <summary>
    /// A control point at the point of entry
    /// </summary
    [Attr]
    [JsonPropertyName("pointOfEntryControlPoint")]
    [System.ComponentModel.Description("A control point at the point of entry")]
    public string? PointOfEntryControlPoint { get; set; }

	
    /// <summary>
    /// Date when consignment arrives
    /// </summary
    [Attr]
    [JsonPropertyName("arrivalDate")]
    [System.ComponentModel.Description("Date when consignment arrives")]
    public string? ArrivalDate { get; set; }

	
    /// <summary>
    /// Time (HH:MM) when consignment arrives
    /// </summary
    [Attr]
    [JsonPropertyName("arrivalTime")]
    [System.ComponentModel.Description("Time (HH:MM) when consignment arrives")]
    public string? ArrivalTime { get; set; }

	
    /// <summary>
    /// How consignment is transported after BIP
    /// </summary
    [Attr]
    [JsonPropertyName("meansOfTransport")]
    [System.ComponentModel.Description("How consignment is transported after BIP")]
    public IpaffsMeansOfTransport? MeansOfTransport { get; set; }

	
    /// <summary>
    /// Transporter of consignment details
    /// </summary
    [Attr]
    [JsonPropertyName("transporter")]
    [System.ComponentModel.Description("Transporter of consignment details")]
    public IpaffsEconomicOperator? Transporter { get; set; }

	
    /// <summary>
    /// Are transporter details required for this consignment
    /// </summary
    [Attr]
    [JsonPropertyName("transporterDetailsRequired")]
    [System.ComponentModel.Description("Are transporter details required for this consignment")]
    public bool? TransporterDetailsRequired { get; set; }

	
    /// <summary>
    /// Transport to BIP
    /// </summary
    [Attr]
    [JsonPropertyName("meansOfTransportFromEntryPoint")]
    [System.ComponentModel.Description("Transport to BIP")]
    public IpaffsMeansOfTransport? MeansOfTransportFromEntryPoint { get; set; }

	
    /// <summary>
    /// Date of consignment departure
    /// </summary
    [Attr]
    [JsonPropertyName("departureDate")]
    [System.ComponentModel.Description("Date of consignment departure")]
    public string? DepartureDate { get; set; }

	
    /// <summary>
    /// Time (HH:MM) of consignment departure
    /// </summary
    [Attr]
    [JsonPropertyName("departureTime")]
    [System.ComponentModel.Description("Time (HH:MM) of consignment departure")]
    public string? DepartureTime { get; set; }

	
    /// <summary>
    /// Estimated journey time in minutes to point of entry
    /// </summary
    [Attr]
    [JsonPropertyName("estimatedJourneyTimeInMinutes")]
    [System.ComponentModel.Description("Estimated journey time in minutes to point of entry")]
    public double? EstimatedJourneyTimeInMinutes { get; set; }

	
    /// <summary>
    /// (Deprecated in IMTA-12139) Person who is responsible for transport
    /// </summary
    [Attr]
    [JsonPropertyName("responsibleForTransport")]
    [System.ComponentModel.Description("(Deprecated in IMTA-12139) Person who is responsible for transport")]
    public string? ResponsibleForTransport { get; set; }

	
    /// <summary>
    /// Part 1 - Holds the information related to veterinary checks and details
    /// </summary
    [Attr]
    [JsonPropertyName("veterinaryInformation")]
    [System.ComponentModel.Description("Part 1 - Holds the information related to veterinary checks and details")]
    public IpaffsVeterinaryInformation? VeterinaryInformation { get; set; }

	
    /// <summary>
    /// Reference number added by the importer
    /// </summary
    [Attr]
    [JsonPropertyName("importerLocalReferenceNumber")]
    [System.ComponentModel.Description("Reference number added by the importer")]
    public string? ImporterLocalReferenceNumber { get; set; }

	
    /// <summary>
    /// Contains countries and transfer points that consignment is going through
    /// </summary
    [Attr]
    [JsonPropertyName("route")]
    [System.ComponentModel.Description("Contains countries and transfer points that consignment is going through")]
    public IpaffsRoute? Route { get; set; }

	
    /// <summary>
    /// Array that contains pair of seal number and container number
    /// </summary
    [Attr]
    [JsonPropertyName("sealsContainers")]
    [System.ComponentModel.Description("Array that contains pair of seal number and container number")]
    public IpaffsSealContainer[]? SealsContainers { get; set; }

	
    /// <summary>
    /// Date and time when the notification was submitted
    /// </summary
    [Attr]
    [JsonPropertyName("submissionDate")]
    [System.ComponentModel.Description("Date and time when the notification was submitted")]
    public DateTime? SubmissionDate { get; set; }

	
    /// <summary>
    /// Information about user who submitted notification
    /// </summary
    [Attr]
    [JsonPropertyName("submittedBy")]
    [System.ComponentModel.Description("Information about user who submitted notification")]
    public IpaffsUserInformation? SubmittedBy { get; set; }

	
    /// <summary>
    /// Validation messages for whole notification
    /// </summary
    [Attr]
    [JsonPropertyName("consignmentValidation")]
    [System.ComponentModel.Description("Validation messages for whole notification")]
    public IpaffsValidationMessageCode[]? ConsignmentValidations { get; set; }

	
    /// <summary>
    /// Was complex commodity selected. Indicating if importer provided commodity code.
    /// </summary
    [Attr]
    [JsonPropertyName("complexCommoditySelected")]
    [System.ComponentModel.Description("Was complex commodity selected. Indicating if importer provided commodity code.")]
    public bool? ComplexCommoditySelected { get; set; }

	
    /// <summary>
    /// Entry port for EU Import notification.
    /// </summary
    [Attr]
    [JsonPropertyName("portOfEntry")]
    [System.ComponentModel.Description("Entry port for EU Import notification.")]
    public string? PortOfEntry { get; set; }

	
    /// <summary>
    /// Exit Port for EU Import Notification.
    /// </summary
    [Attr]
    [JsonPropertyName("portOfExit")]
    [System.ComponentModel.Description("Exit Port for EU Import Notification.")]
    public string? PortOfExit { get; set; }

	
    /// <summary>
    /// Date of Port Exit for EU Import Notification.
    /// </summary
    [Attr]
    [JsonPropertyName("portOfExitDate")]
    [System.ComponentModel.Description("Date of Port Exit for EU Import Notification.")]
    public string? PortOfExitDate { get; set; }

	
    /// <summary>
    /// Person to be contacted if there is an issue with the consignment
    /// </summary
    [Attr]
    [JsonPropertyName("contactDetails")]
    [System.ComponentModel.Description("Person to be contacted if there is an issue with the consignment")]
    public IpaffsContactDetails? ContactDetails { get; set; }

	
    /// <summary>
    /// List of nominated contacts to receive text and email notifications
    /// </summary
    [Attr]
    [JsonPropertyName("nominatedContacts")]
    [System.ComponentModel.Description("List of nominated contacts to receive text and email notifications")]
    public IpaffsNominatedContact[]? NominatedContacts { get; set; }

	
    /// <summary>
    /// Original estimated date time of arrival
    /// </summary
    [Attr]
    [JsonPropertyName("originalEstimatedDateTime")]
    [System.ComponentModel.Description("Original estimated date time of arrival")]
    public DateTime? OriginalEstimatedDateTime { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("billingInformation")]
    [System.ComponentModel.Description("")]
    public IpaffsBillingInformation? BillingInformation { get; set; }

	
    /// <summary>
    /// Indicates whether CUC applies to the notification
    /// </summary
    [Attr]
    [JsonPropertyName("isChargeable")]
    [System.ComponentModel.Description("Indicates whether CUC applies to the notification")]
    public bool? IsChargeable { get; set; }

	
    /// <summary>
    /// Indicates whether CUC previously applied to the notification
    /// </summary
    [Attr]
    [JsonPropertyName("wasChargeable")]
    [System.ComponentModel.Description("Indicates whether CUC previously applied to the notification")]
    public bool? WasChargeable { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [JsonPropertyName("commonUserCharge")]
    [System.ComponentModel.Description("")]
    public IpaffsCommonUserCharge? CommonUserCharge { get; set; }

	
    /// <summary>
    /// When the NCTS MRN will be added for the Common Transit Convention (CTC)
    /// </summary
    [Attr]
    [JsonPropertyName("provideCtcMrn")]
    [System.ComponentModel.Description("When the NCTS MRN will be added for the Common Transit Convention (CTC)")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsPartOneProvideCtcMrnEnum? ProvideCtcMrn { get; set; }

	}


