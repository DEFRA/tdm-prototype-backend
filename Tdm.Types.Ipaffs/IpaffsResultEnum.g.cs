
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Tdm.Types.Ipaffs;

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


