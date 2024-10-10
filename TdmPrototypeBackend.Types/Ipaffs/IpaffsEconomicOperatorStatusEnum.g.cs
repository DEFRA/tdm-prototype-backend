
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsEconomicOperatorStatusEnum
{

		[EnumMember(Value = "approved")]
		Approved,
	
		[EnumMember(Value = "nonapproved")]
		NonApproved,
	
		[EnumMember(Value = "suspended")]
		Suspended,
	
}


