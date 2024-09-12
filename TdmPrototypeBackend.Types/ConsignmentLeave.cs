
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ConsignmentLeave
{

		[EnumMember(Value = "YES")]
		Yes,
	
		[EnumMember(Value = "NO")]
		No,
	
		[EnumMember(Value = "It has been destroyed")]
		Ithasbeendestroyed,
	
}


