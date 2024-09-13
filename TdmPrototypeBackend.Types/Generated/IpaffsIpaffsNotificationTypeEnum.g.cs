
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsIpaffsNotificationTypeEnum
{

		[EnumMember(Value = "CVEDA")]
		Cveda,
	
		[EnumMember(Value = "CVEDP")]
		Cvedp,
	
		[EnumMember(Value = "CHEDPP")]
		Chedpp,
	
		[EnumMember(Value = "CED")]
		Ced,
	
		[EnumMember(Value = "IMP")]
		Imp,
	
}


