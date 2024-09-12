
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IdentityCheckType
{

		[EnumMember(Value = "Seal Check")]
		Sealcheck,
	
		[EnumMember(Value = "Full Identity Check")]
		Fullidentitycheck,
	
		[EnumMember(Value = "Not Done")]
		Notdone,
	
}


