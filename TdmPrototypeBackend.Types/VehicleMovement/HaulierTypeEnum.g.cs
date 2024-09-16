
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.VehicleMovement;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum HaulierTypeEnum
{

		[EnumMember(Value = "STANDARD")]
		Standard,
	
		[EnumMember(Value = "FPO_ASN")]
		Fpoasn,
	
		[EnumMember(Value = "FPO_OTHER")]
		Fpoother,
	
		[EnumMember(Value = "NATO_MOD")]
		Natomod,
	
		[EnumMember(Value = "RMG")]
		Rmg,
	
		[EnumMember(Value = "ETOE")]
		Etoe,
	
}


