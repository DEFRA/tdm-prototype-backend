
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsPartOneTypeOfImpEnum
{

		[EnumMember(Value = "A")]
		A,
	
		[EnumMember(Value = "P")]
		P,
	
		[EnumMember(Value = "D")]
		D,
	
}


