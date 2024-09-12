
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum NotAcceptableActionIndustrialProcessingReason
{

		[EnumMember(Value = "ContaminatedProducts")]
		Contaminatedproducts,
	
		[EnumMember(Value = "InterceptedPart")]
		Interceptedpart,
	
		[EnumMember(Value = "PackagingMaterial")]
		Packagingmaterial,
	
		[EnumMember(Value = "Other")]
		Other,
	
}


