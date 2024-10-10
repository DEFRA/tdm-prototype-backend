
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsExternalReferenceSystemEnum
{

		[EnumMember(Value = "E-CERT")]
		ECert,
	
		[EnumMember(Value = "E-PHYTO")]
		EPhyto,
	
		[EnumMember(Value = "E-NOTIFICATION")]
		ENotification,
	
		[EnumMember(Value = "NCTS")]
		Ncts,
	
}


