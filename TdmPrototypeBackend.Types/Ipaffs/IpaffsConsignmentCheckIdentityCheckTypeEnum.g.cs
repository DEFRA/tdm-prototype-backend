
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsConsignmentCheckIdentityCheckTypeEnum
{

		[EnumMember(Value = "Seal Check")]
		SealCheck,
	
		[EnumMember(Value = "Full Identity Check")]
		FullIdentityCheck,
	
		[EnumMember(Value = "Not Done")]
		NotDone,
	
}


