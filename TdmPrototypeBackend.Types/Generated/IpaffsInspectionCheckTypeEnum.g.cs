
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsInspectionCheckTypeEnum
{

		[EnumMember(Value = "PHSI_DOCUMENT")]
		PHSIDOCUMENT,
	
		[EnumMember(Value = "PHSI_IDENTITY")]
		PHSIIDENTITY,
	
		[EnumMember(Value = "PHSI_PHYSICAL")]
		PHSIPHYSICAL,
	
		[EnumMember(Value = "HMI")]
		Hmi,
	
}


