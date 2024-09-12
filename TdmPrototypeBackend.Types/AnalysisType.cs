
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum AnalysisType
{

		[EnumMember(Value = "Initial analysis")]
		Initialanalysis,
	
		[EnumMember(Value = "Counter analysis")]
		Counteranalysis,
	
		[EnumMember(Value = "Second expert analysis")]
		Secondexpertanalysis,
	
}


