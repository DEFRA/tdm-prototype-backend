
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsDecisionDefinitiveImportPurposeEnum
{

		[EnumMember(Value = "slaughter")]
		Slaughter,
	
		[EnumMember(Value = "approvedbodies")]
		Approvedbodies,
	
		[EnumMember(Value = "quarantine")]
		Quarantine,
	
}


