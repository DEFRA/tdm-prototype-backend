
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IuuOption
{

		[EnumMember(Value = "IUUOK")]
		Iuuok,
	
		[EnumMember(Value = "IUUNA")]
		Iuuna,
	
		[EnumMember(Value = "IUUNotCompliant")]
		Iuunotcompliant,
	
}


