
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsNotAcceptableActionUseForOtherPurposesReasonEnum
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


