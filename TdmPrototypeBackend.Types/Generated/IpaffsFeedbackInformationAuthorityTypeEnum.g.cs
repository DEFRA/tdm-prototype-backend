
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

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


