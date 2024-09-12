
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IdentityCheckNotDoneReason
{

		[EnumMember(Value = "Reduced checks regime")]
		Reducedchecksregime,
	
		[EnumMember(Value = "Not required")]
		Notrequired,
	
}


