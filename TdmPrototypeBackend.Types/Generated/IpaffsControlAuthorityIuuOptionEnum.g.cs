
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsControlAuthorityIuuOptionEnum
{

		[EnumMember(Value = "IUUOK")]
		Iuuok,
	
		[EnumMember(Value = "IUUNA")]
		Iuuna,
	
		[EnumMember(Value = "IUUNotCompliant")]
		IUUNotCompliant,
	
}


