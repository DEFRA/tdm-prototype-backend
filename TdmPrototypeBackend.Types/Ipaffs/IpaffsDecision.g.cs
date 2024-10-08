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
/// Decision if the consignment can be imported
/// </summary>
public partial class IpaffsDecision  //
{


    /// <summary>
    /// Is consignment acceptable or not
    /// </summary
    [Attr]
    [JsonPropertyName("consignmentAcceptable")]
    public bool? ConsignmentAcceptable { get; set; }

	
    /// <summary>
    /// Filled if consignmentAcceptable is set to false
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableAction")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionNotAcceptableActionEnum? NotAcceptableAction { get; set; }

	
    /// <summary>
    /// Filled if not acceptable action is set to destruction
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableActionDestructionReason")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionNotAcceptableActionDestructionReasonEnum? NotAcceptableActionDestructionReason { get; set; }

	
    /// <summary>
    /// Filled if not acceptable action is set to entry refusal
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableActionEntryRefusalReason")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum? NotAcceptableActionEntryRefusalReason { get; set; }

	
    /// <summary>
    /// Filled if not acceptable action is set to quarantine imposed
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableActionQuarantineImposedReason")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionNotAcceptableActionQuarantineImposedReasonEnum? NotAcceptableActionQuarantineImposedReason { get; set; }

	
    /// <summary>
    /// Filled if not acceptable action is set to special treatment
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableActionSpecialTreatmentReason")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionNotAcceptableActionSpecialTreatmentReasonEnum? NotAcceptableActionSpecialTreatmentReason { get; set; }

	
    /// <summary>
    /// Filled if not acceptable action is set to industrial processing
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableActionIndustrialProcessingReason")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionNotAcceptableActionIndustrialProcessingReasonEnum? NotAcceptableActionIndustrialProcessingReason { get; set; }

	
    /// <summary>
    /// Filled if not acceptable action is set to re-dispatch
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableActionReDispatchReason")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionNotAcceptableActionReDispatchReasonEnum? NotAcceptableActionReDispatchReason { get; set; }

	
    /// <summary>
    /// Filled if not acceptable action is set to use for other purposes
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableActionUseForOtherPurposesReason")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionNotAcceptableActionUseForOtherPurposesReasonEnum? NotAcceptableActionUseForOtherPurposesReason { get; set; }

	
    /// <summary>
    /// Filled when notAcceptableAction is equal to destruction
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableDestructionReason")]
    public string? NotAcceptableDestructionReason { get; set; }

	
    /// <summary>
    /// Filled when notAcceptableAction is equal to other
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableActionOtherReason")]
    public string? NotAcceptableActionOtherReason { get; set; }

	
    /// <summary>
    /// Filled when consignmentAcceptable is set to false
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableActionByDate")]
    public string? NotAcceptableActionByDate { get; set; }

	
    /// <summary>
    /// List of details for individual chedpp not acceptable reasons
    /// </summary
    [Attr]
    [JsonPropertyName("chedppNotAcceptableReasons")]
    public IpaffsChedppNotAcceptableReason[]? ChedppNotAcceptableReasons { get; set; }

	
    /// <summary>
    /// If the consignment was not accepted what was the reason
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableReasons")]
    public string[]? NotAcceptableReasons { get; set; }

	
    /// <summary>
    /// 2 digits ISO code of country (not acceptable country can be empty)
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableCountry")]
    public string? NotAcceptableCountry { get; set; }

	
    /// <summary>
    /// Filled if consignmentAcceptable is set to false
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableEstablishment")]
    public string? NotAcceptableEstablishment { get; set; }

	
    /// <summary>
    /// Filled if consignmentAcceptable is set to false
    /// </summary
    [Attr]
    [JsonPropertyName("notAcceptableOtherReason")]
    public string? NotAcceptableOtherReason { get; set; }

	
    /// <summary>
    /// Details of controlled destinations
    /// </summary
    [Attr]
    [JsonPropertyName("detailsOfControlledDestinations")]
    public IpaffsParty? DetailsOfControlledDestinations { get; set; }

	
    /// <summary>
    /// Filled if consignment is set to acceptable and decision type is Specific Warehouse
    /// </summary
    [Attr]
    [JsonPropertyName("specificWarehouseNonConformingConsignment")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionSpecificWarehouseNonConformingConsignmentEnum? SpecificWarehouseNonConformingConsignment { get; set; }

	
    /// <summary>
    /// Deadline when consignment has to leave borders
    /// </summary
    [Attr]
    [JsonPropertyName("temporaryDeadline")]
    public string? TemporaryDeadline { get; set; }

	
    /// <summary>
    /// Detailed decision for consignment
    /// </summary
    [Attr]
    [JsonPropertyName("decision")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionDecisionEnum? Decision { get; set; }

	
    /// <summary>
    /// Decision over purpose of free circulation in country
    /// </summary
    [Attr]
    [JsonPropertyName("freeCirculationPurpose")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionFreeCirculationPurposeEnum? FreeCirculationPurpose { get; set; }

	
    /// <summary>
    /// Decision over purpose of definitive import
    /// </summary
    [Attr]
    [JsonPropertyName("definitiveImportPurpose")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionDefinitiveImportPurposeEnum? DefinitiveImportPurpose { get; set; }

	
    /// <summary>
    /// Decision channeled option based on (article8, article15)
    /// </summary
    [Attr]
    [JsonPropertyName("ifChanneledOption")]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public IpaffsDecisionIfChanneledOptionEnum? IfChanneledOption { get; set; }

	
    /// <summary>
    /// Custom warehouse registered number
    /// </summary
    [Attr]
    [JsonPropertyName("customWarehouseRegisteredNumber")]
    public string? CustomWarehouseRegisteredNumber { get; set; }

	
    /// <summary>
    /// Free warehouse registered number
    /// </summary
    [Attr]
    [JsonPropertyName("freeWarehouseRegisteredNumber")]
    public string? FreeWarehouseRegisteredNumber { get; set; }

	
    /// <summary>
    /// Ship name
    /// </summary
    [Attr]
    [JsonPropertyName("shipName")]
    public string? ShipName { get; set; }

	
    /// <summary>
    /// Port of exit
    /// </summary
    [Attr]
    [JsonPropertyName("shipPortOfExit")]
    public string? ShipPortOfExit { get; set; }

	
    /// <summary>
    /// Ship supplier registered number
    /// </summary
    [Attr]
    [JsonPropertyName("shipSupplierRegisteredNumber")]
    public string? ShipSupplierRegisteredNumber { get; set; }

	
    /// <summary>
    /// Transhipment BIP
    /// </summary
    [Attr]
    [JsonPropertyName("transhipmentBip")]
    public string? TranshipmentBip { get; set; }

	
    /// <summary>
    /// Transhipment third country
    /// </summary
    [Attr]
    [JsonPropertyName("transhipmentThirdCountry")]
    public string? TranshipmentThirdCountry { get; set; }

	
    /// <summary>
    /// Transit exit BIP
    /// </summary
    [Attr]
    [JsonPropertyName("transitExitBip")]
    public string? TransitExitBip { get; set; }

	
    /// <summary>
    /// Transit third country
    /// </summary
    [Attr]
    [JsonPropertyName("transitThirdCountry")]
    public string? TransitThirdCountry { get; set; }

	
    /// <summary>
    /// Transit destination third country
    /// </summary
    [Attr]
    [JsonPropertyName("transitDestinationThirdCountry")]
    public string? TransitDestinationThirdCountry { get; set; }

	
    /// <summary>
    /// Temporary exit BIP
    /// </summary
    [Attr]
    [JsonPropertyName("temporaryExitBip")]
    public string? TemporaryExitBip { get; set; }

	
    /// <summary>
    /// Horse re-entry
    /// </summary
    [Attr]
    [JsonPropertyName("horseReentry")]
    public string? HorseReentry { get; set; }

	
    /// <summary>
    /// Is it transshipped to EU or third country (values EU / country name)
    /// </summary
    [Attr]
    [JsonPropertyName("transhipmentEuOrThirdCountry")]
    public string? TranshipmentEuOrThirdCountry { get; set; }

	}


