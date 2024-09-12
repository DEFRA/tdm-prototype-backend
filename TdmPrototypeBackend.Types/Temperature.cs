
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Temperature
{

		[EnumMember(Value = "Ambient")]
		Ambient,
	
		[EnumMember(Value = "Chilled")]
		Chilled,
	
		[EnumMember(Value = "Frozen")]
		Frozen,
	
}


