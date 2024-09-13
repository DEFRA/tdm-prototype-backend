
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsIdentityCheckNotDoneReasonEnum
{

		[EnumMember(Value = "Reduced checks regime")]
		ReducedChecksRegime,
	
		[EnumMember(Value = "Not required")]
		NotRequired,
	
}


