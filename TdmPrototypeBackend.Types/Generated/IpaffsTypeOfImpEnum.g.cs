
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsTypeOfImpEnum
{

		[EnumMember(Value = "A")]
		A,
	
		[EnumMember(Value = "P")]
		P,
	
		[EnumMember(Value = "D")]
		D,
	
}


