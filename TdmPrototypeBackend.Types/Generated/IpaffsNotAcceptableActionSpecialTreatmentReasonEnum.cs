
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsNotAcceptableActionSpecialTreatmentReasonEnum
{

		[EnumMember(Value = "ContaminatedProducts")]
		ContaminatedProducts,
	
		[EnumMember(Value = "InterceptedPart")]
		InterceptedPart,
	
		[EnumMember(Value = "PackagingMaterial")]
		PackagingMaterial,
	
		[EnumMember(Value = "Other")]
		Other,
	
}


