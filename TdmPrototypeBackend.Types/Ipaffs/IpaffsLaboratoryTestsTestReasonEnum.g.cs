
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsLaboratoryTestsTestReasonEnum
{

		[EnumMember(Value = "Random")]
		Random,
	
		[EnumMember(Value = "Suspicious")]
		Suspicious,
	
		[EnumMember(Value = "Re-enforced")]
		ReEnforced,
	
		[EnumMember(Value = "Intensified controls")]
		IntensifiedControls,
	
		[EnumMember(Value = "Required")]
		Required,
	
		[EnumMember(Value = "Latent infection sampling")]
		LatentInfectionSampling,
	
}


