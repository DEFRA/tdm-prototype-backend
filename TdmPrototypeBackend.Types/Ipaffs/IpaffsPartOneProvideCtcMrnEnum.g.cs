
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsPartOneProvideCtcMrnEnum
{

		[EnumMember(Value = "YES")]
		Yes,
	
		[EnumMember(Value = "YES_ADD_LATER")]
		YESADDLATER,
	
		[EnumMember(Value = "NO")]
		No,
	
}


