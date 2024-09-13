
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsSystemEnum
{

		[EnumMember(Value = "E-CERT")]
		ECERT,
	
		[EnumMember(Value = "E-PHYTO")]
		EPHYTO,
	
		[EnumMember(Value = "E-NOTIFICATION")]
		ENOTIFICATION,
	
		[EnumMember(Value = "NCTS")]
		Ncts,
	
}


