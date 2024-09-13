
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsTypeEnum
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


