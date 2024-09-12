
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum RiskLevelMethod
{

		[EnumMember(Value = "System")]
		System,
	
		[EnumMember(Value = "User")]
		User,
	
}


