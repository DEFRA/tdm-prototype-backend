
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsAnalysisTypeEnum
{

		[EnumMember(Value = "Initial analysis")]
		InitialAnalysis,
	
		[EnumMember(Value = "Counter analysis")]
		CounterAnalysis,
	
		[EnumMember(Value = "Second expert analysis")]
		SecondExpertAnalysis,
	
}


