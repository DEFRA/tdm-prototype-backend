
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsLaboratoryTestResultConclusionEnum
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


