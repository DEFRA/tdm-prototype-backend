
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsFeedbackInformationAuthorityTypeEnum
{

		[EnumMember(Value = "exitbip")]
		ExitBip,
	
		[EnumMember(Value = "finalbip")]
		FinalBip,
	
		[EnumMember(Value = "localvetunit")]
		LocalVetUnit,
	
		[EnumMember(Value = "inspunit")]
		InspUnit,
	
}


