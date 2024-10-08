
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsDecisionDefinitiveImportPurposeEnum
{

		[EnumMember(Value = "slaughter")]
		Slaughter,
	
		[EnumMember(Value = "approvedbodies")]
		ApprovedBodies,
	
		[EnumMember(Value = "quarantine")]
		Quarantine,
	
}


