
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum PurposeGroup
{

		[EnumMember(Value = "For Import")]
		Forimport,
	
		[EnumMember(Value = "For NON-Conforming Consignments")]
		Fornonconformingconsignments,
	
		[EnumMember(Value = "For Transhipment to")]
		Fortranshipmentto,
	
		[EnumMember(Value = "For Transit to 3rd Country")]
		Fortransitto3rdcountry,
	
		[EnumMember(Value = "For Re-Import")]
		Forreimport,
	
		[EnumMember(Value = "For Private Import")]
		Forprivateimport,
	
		[EnumMember(Value = "For Transfer To")]
		Fortransferto,
	
		[EnumMember(Value = "For Import Re-Conformity Check")]
		Forimportreconformitycheck,
	
}


