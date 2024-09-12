
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum NotAcceptableActionEntryRefusalReason
{

		[EnumMember(Value = "ContaminatedProducts")]
		Contaminatedproducts,
	
		[EnumMember(Value = "InterceptedPart")]
		Interceptedpart,
	
		[EnumMember(Value = "PackagingMaterial")]
		Packagingmaterial,
	
		[EnumMember(Value = "MeansOfTransport")]
		Meansoftransport,
	
		[EnumMember(Value = "Other")]
		Other,
	
}


