
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsConclusionEnum
{

		[EnumMember(Value = "Satisfactory")]
		Satisfactory,
	
		[EnumMember(Value = "Not satisfactory")]
		NotSatisfactory,
	
		[EnumMember(Value = "Not interpretable")]
		NotInterpretable,
	
		[EnumMember(Value = "Pending")]
		Pending,
	
}


