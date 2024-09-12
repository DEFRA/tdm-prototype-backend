
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ProvideCtcMrn
{

		[EnumMember(Value = "YES")]
		Yes,
	
		[EnumMember(Value = "YES_ADD_LATER")]
		Yesaddlater,
	
		[EnumMember(Value = "NO")]
		No,
	
}


