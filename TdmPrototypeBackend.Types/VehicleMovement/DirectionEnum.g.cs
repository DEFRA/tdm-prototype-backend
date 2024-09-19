
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.VehicleMovement;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum DirectionEnum
{

		[EnumMember(Value = "UK_INBOUND")]
		Ukinbound,
	
		[EnumMember(Value = "UK_OUTBOUND")]
		Ukoutbound,
	
		[EnumMember(Value = "GB_TO_NI")]
		Gbtoni,
	
		[EnumMember(Value = "NI_TO_GB")]
		Nitogb,
	
}


