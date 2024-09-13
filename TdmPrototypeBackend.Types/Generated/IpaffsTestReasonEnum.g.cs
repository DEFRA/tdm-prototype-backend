
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsTestReasonEnum
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


