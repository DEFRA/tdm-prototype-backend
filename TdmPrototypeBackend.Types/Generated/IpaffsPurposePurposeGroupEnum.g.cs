
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsPurposePurposeGroupEnum
{

		[EnumMember(Value = "For Import")]
		ForImport,
	
		[EnumMember(Value = "For NON-Conforming Consignments")]
		ForNONConformingConsignments,
	
		[EnumMember(Value = "For Transhipment to")]
		ForTranshipmentTo,
	
		[EnumMember(Value = "For Transit to 3rd Country")]
		ForTransitTo3rdCountry,
	
		[EnumMember(Value = "For Re-Import")]
		ForReImport,
	
		[EnumMember(Value = "For Private Import")]
		ForPrivateImport,
	
		[EnumMember(Value = "For Transfer To")]
		ForTransferTo,
	
		[EnumMember(Value = "For Import Re-Conformity Check")]
		ForImportReConformityCheck,
	
}


