
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsCommodityOrPackageEnum
{

		[EnumMember(Value = "c")]
		C,
	
		[EnumMember(Value = "p")]
		P,
	
		[EnumMember(Value = "cp")]
		Cp,
	
}


