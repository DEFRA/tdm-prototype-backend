
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsConsignmentCheckPhysicalCheckNotDoneReasonEnum
{

		[EnumMember(Value = "Reduced checks regime")]
		ReducedChecksRegime,
	
		[EnumMember(Value = "Other")]
		Other,
	
}


