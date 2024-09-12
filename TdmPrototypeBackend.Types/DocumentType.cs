
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum DocumentType
{

		[EnumMember(Value = "airWaybill")]
		Airwaybill,
	
		[EnumMember(Value = "billOfLading")]
		Billoflading,
	
		[EnumMember(Value = "cargoManifest")]
		Cargomanifest,
	
		[EnumMember(Value = "catchCertificate")]
		Catchcertificate,
	
		[EnumMember(Value = "commercialDocument")]
		Commercialdocument,
	
		[EnumMember(Value = "commercialInvoice")]
		Commercialinvoice,
	
		[EnumMember(Value = "conformityCertificate")]
		Conformitycertificate,
	
		[EnumMember(Value = "containerManifest")]
		Containermanifest,
	
		[EnumMember(Value = "customsDeclaration")]
		Customsdeclaration,
	
		[EnumMember(Value = "docom")]
		Docom,
	
		[EnumMember(Value = "healthCertificate")]
		Healthcertificate,
	
		[EnumMember(Value = "heatTreatmentCertificate")]
		Heattreatmentcertificate,
	
		[EnumMember(Value = "importPermit")]
		Importpermit,
	
		[EnumMember(Value = "inspectionCertificate")]
		Inspectioncertificate,
	
		[EnumMember(Value = "itahc")]
		Itahc,
	
		[EnumMember(Value = "journeyLog")]
		Journeylog,
	
		[EnumMember(Value = "laboratorySamplingResultsForAflatoxin")]
		Laboratorysamplingresultsforaflatoxin,
	
		[EnumMember(Value = "latestVeterinaryHealthCertificate")]
		Latestveterinaryhealthcertificate,
	
		[EnumMember(Value = "letterOfAuthority")]
		Letterofauthority,
	
		[EnumMember(Value = "licenseOrAuthorisation")]
		Licenseorauthorisation,
	
		[EnumMember(Value = "mycotoxinCertification")]
		Mycotoxincertification,
	
		[EnumMember(Value = "originCertificate")]
		Origincertificate,
	
		[EnumMember(Value = "other")]
		Other,
	
		[EnumMember(Value = "phytosanitaryCertificate")]
		Phytosanitarycertificate,
	
		[EnumMember(Value = "processingStatement")]
		Processingstatement,
	
		[EnumMember(Value = "proofOfStorage")]
		Proofofstorage,
	
		[EnumMember(Value = "railwayBill")]
		Railwaybill,
	
		[EnumMember(Value = "seaWaybill")]
		Seawaybill,
	
		[EnumMember(Value = "veterinaryHealthCertificate")]
		Veterinaryhealthcertificate,
	
		[EnumMember(Value = "listOfIngredients")]
		Listofingredients,
	
		[EnumMember(Value = "packingList")]
		Packinglist,
	
		[EnumMember(Value = "roadConsignmentNote")]
		Roadconsignmentnote,
	
}


