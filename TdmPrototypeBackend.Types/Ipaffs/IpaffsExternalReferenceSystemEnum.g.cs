
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsExternalReferenceSystemEnum
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


