
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Tdm.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsInspectionCheckTypeEnum
{

		[EnumMember(Value = "PHSI_DOCUMENT")]
		PhsiDocument,
	
		[EnumMember(Value = "PHSI_IDENTITY")]
		PhsiIdentity,
	
		[EnumMember(Value = "PHSI_PHYSICAL")]
		PhsiPhysical,
	
		[EnumMember(Value = "HMI")]
		Hmi,
	
}


