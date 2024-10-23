
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Tdm.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsEconomicOperatorStatusEnum
{

		[EnumMember(Value = "approved")]
		Approved,
	
		[EnumMember(Value = "nonapproved")]
		Nonapproved,
	
		[EnumMember(Value = "suspended")]
		Suspended,
	
}

