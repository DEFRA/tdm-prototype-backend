
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Tdm.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsUnitEnum
{

		[EnumMember(Value = "percent")]
		Percent,
	
		[EnumMember(Value = "number")]
		Number,
	
}


