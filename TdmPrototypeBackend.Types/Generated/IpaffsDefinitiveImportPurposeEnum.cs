
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsDefinitiveImportPurposeEnum
{

		[EnumMember(Value = "slaughter")]
		Slaughter,
	
		[EnumMember(Value = "approvedbodies")]
		Approvedbodies,
	
		[EnumMember(Value = "quarantine")]
		Quarantine,
	
}

