
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Tdm.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsApplicantAnalysisTypeEnum
{

		[EnumMember(Value = "Initial analysis")]
		InitialAnalysis,
	
		[EnumMember(Value = "Counter analysis")]
		CounterAnalysis,
	
		[EnumMember(Value = "Second expert analysis")]
		SecondExpertAnalysis,
	
}


