
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsProvideCtcMrnEnum
{

		[EnumMember(Value = "YES")]
		Yes,
	
		[EnumMember(Value = "YES_ADD_LATER")]
		YESADDLATER,
	
		[EnumMember(Value = "NO")]
		No,
	
}


