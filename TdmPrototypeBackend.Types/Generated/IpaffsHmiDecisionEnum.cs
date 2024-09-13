
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsHmiDecisionEnum
{

		[EnumMember(Value = "REQUIRED")]
		Required,
	
		[EnumMember(Value = "NOTREQUIRED")]
		Notrequired,
	
}


