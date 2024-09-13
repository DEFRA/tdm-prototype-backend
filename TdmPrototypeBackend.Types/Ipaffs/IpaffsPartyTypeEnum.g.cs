
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsPartyTypeEnum
{

		[EnumMember(Value = "Commercial transporter")]
		CommercialTransporter,
	
		[EnumMember(Value = "Private transporter")]
		PrivateTransporter,
	
}


