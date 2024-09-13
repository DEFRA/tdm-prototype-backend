
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsInspectionRequiredEnum
{

		[EnumMember(Value = "Required")]
		Required,
	
		[EnumMember(Value = "Inconclusive")]
		Inconclusive,
	
		[EnumMember(Value = "Not required")]
		NotRequired,
	
}


