
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Tdm.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsApplicantConservationOfSampleEnum
{

		[EnumMember(Value = "Ambient")]
		Ambient,
	
		[EnumMember(Value = "Chilled")]
		Chilled,
	
		[EnumMember(Value = "Frozen")]
		Frozen,
	
}


