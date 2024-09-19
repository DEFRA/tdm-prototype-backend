
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsInspectionCheckTypeEnum
{

		[EnumMember(Value = "PHSI_DOCUMENT")]
		Phsidocument,
	
		[EnumMember(Value = "PHSI_IDENTITY")]
		Phsiidentity,
	
		[EnumMember(Value = "PHSI_PHYSICAL")]
		Phsiphysical,
	
		[EnumMember(Value = "HMI")]
		Hmi,
	
}


