
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsCommodityRiskResultRiskDecisionEnum
{

		[EnumMember(Value = "REQUIRED")]
		Required,
	
		[EnumMember(Value = "NOTREQUIRED")]
		Notrequired,
	
		[EnumMember(Value = "INCONCLUSIVE")]
		Inconclusive,
	
		[EnumMember(Value = "REENFORCED_CHECK")]
		REENFORCEDCHECK,
	
}


