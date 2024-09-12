
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum System
{

		[EnumMember(Value = "E-CERT")]
		Ecert,
	
		[EnumMember(Value = "E-PHYTO")]
		Ephyto,
	
		[EnumMember(Value = "E-NOTIFICATION")]
		Enotification,
	
		[EnumMember(Value = "NCTS")]
		Ncts,
	
}


