
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum RiskDecision
{

		[EnumMember(Value = "REQUIRED")]
		Required,
	
		[EnumMember(Value = "NOTREQUIRED")]
		Notrequired,
	
		[EnumMember(Value = "INCONCLUSIVE")]
		Inconclusive,
	
		[EnumMember(Value = "REENFORCED_CHECK")]
		Reenforcedcheck,
	
}


