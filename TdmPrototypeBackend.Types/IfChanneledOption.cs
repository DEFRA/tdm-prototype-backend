
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IfChanneledOption
{

		[EnumMember(Value = "article8")]
		Article8,
	
		[EnumMember(Value = "article15")]
		Article15,
	
}


