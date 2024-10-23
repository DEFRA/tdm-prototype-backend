
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Tdm.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsChedppNotAcceptableReasonCommodityOrPackageEnum
{

		[EnumMember(Value = "c")]
		C,
	
		[EnumMember(Value = "p")]
		P,
	
		[EnumMember(Value = "cp")]
		Cp,
	
}


