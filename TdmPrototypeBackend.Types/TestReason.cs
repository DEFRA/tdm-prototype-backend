
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum TestReason
{

		[EnumMember(Value = "Random")]
		Random,
	
		[EnumMember(Value = "Suspicious")]
		Suspicious,
	
		[EnumMember(Value = "Re-enforced")]
		Reenforced,
	
		[EnumMember(Value = "Intensified controls")]
		Intensifiedcontrols,
	
		[EnumMember(Value = "Required")]
		Required,
	
		[EnumMember(Value = "Latent infection sampling")]
		Latentinfectionsampling,
	
}


