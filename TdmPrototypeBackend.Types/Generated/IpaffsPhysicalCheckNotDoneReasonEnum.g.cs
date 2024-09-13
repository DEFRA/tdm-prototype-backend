
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsPhysicalCheckNotDoneReasonEnum
{

		[EnumMember(Value = "Reduced checks regime")]
		ReducedChecksRegime,
	
		[EnumMember(Value = "Other")]
		Other,
	
}


