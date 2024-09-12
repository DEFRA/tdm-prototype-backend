
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ControlStatus
{

		[EnumMember(Value = "REQUIRED")]
		Required,
	
		[EnumMember(Value = "COMPLETED")]
		Completed,
	
}


