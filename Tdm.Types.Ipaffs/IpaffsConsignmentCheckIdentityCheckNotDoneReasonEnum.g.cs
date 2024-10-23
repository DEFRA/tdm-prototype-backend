
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Tdm.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsConsignmentCheckIdentityCheckNotDoneReasonEnum
{

		[EnumMember(Value = "Reduced checks regime")]
		ReducedChecksRegime,
	
		[EnumMember(Value = "Not required")]
		NotRequired,
	
}


