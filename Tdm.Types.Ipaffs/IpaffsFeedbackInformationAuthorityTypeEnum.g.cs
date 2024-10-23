
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Tdm.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsFeedbackInformationAuthorityTypeEnum
{

		[EnumMember(Value = "exitbip")]
		Exitbip,
	
		[EnumMember(Value = "finalbip")]
		Finalbip,
	
		[EnumMember(Value = "localvetunit")]
		Localvetunit,
	
		[EnumMember(Value = "inspunit")]
		Inspunit,
	
}


