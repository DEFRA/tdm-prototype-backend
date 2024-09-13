
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsIdentityCheckTypeEnum
{

		[EnumMember(Value = "Seal Check")]
		SealCheck,
	
		[EnumMember(Value = "Full Identity Check")]
		FullIdentityCheck,
	
		[EnumMember(Value = "Not Done")]
		NotDone,
	
}


