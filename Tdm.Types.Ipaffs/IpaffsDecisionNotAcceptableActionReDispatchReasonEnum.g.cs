
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Tdm.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsDecisionNotAcceptableActionReDispatchReasonEnum
{

		[EnumMember(Value = "ContaminatedProducts")]
		ContaminatedProducts,
	
		[EnumMember(Value = "InterceptedPart")]
		InterceptedPart,
	
		[EnumMember(Value = "PackagingMaterial")]
		PackagingMaterial,
	
		[EnumMember(Value = "MeansOfTransport")]
		MeansOfTransport,
	
		[EnumMember(Value = "Other")]
		Other,
	
}


