
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum PhsiClassification
{

		[EnumMember(Value = "Mandatory")]
		Mandatory,
	
		[EnumMember(Value = "Reduced")]
		Reduced,
	
		[EnumMember(Value = "Controlled")]
		Controlled,
	
}


