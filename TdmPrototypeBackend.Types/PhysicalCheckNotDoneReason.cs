
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum PhysicalCheckNotDoneReason
{

		[EnumMember(Value = "Reduced checks regime")]
		Reducedchecksregime,
	
		[EnumMember(Value = "Other")]
		Other,
	
}


