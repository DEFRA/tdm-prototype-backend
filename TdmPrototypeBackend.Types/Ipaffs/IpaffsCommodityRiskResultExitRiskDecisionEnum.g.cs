
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsCommodityRiskResultExitRiskDecisionEnum
{

		[EnumMember(Value = "REQUIRED")]
		Required,
	
		[EnumMember(Value = "NOTREQUIRED")]
		NotRequired,
	
		[EnumMember(Value = "INCONCLUSIVE")]
		Inconclusive,
	
}


