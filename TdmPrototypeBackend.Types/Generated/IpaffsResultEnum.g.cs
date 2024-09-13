
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsResultEnum
{

		[EnumMember(Value = "Satisfactory")]
		Satisfactory,
	
		[EnumMember(Value = "Satisfactory following official intervention")]
		SatisfactoryFollowingOfficialIntervention,
	
		[EnumMember(Value = "Not Satisfactory")]
		NotSatisfactory,
	
		[EnumMember(Value = "Not Done")]
		NotDone,
	
		[EnumMember(Value = "Derogation")]
		Derogation,
	
		[EnumMember(Value = "Not Set")]
		NotSet,
	
}


