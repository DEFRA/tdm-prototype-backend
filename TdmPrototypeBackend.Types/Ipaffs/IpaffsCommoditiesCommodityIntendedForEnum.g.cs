
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsCommoditiesCommodityIntendedForEnum
{

		[EnumMember(Value = "human")]
		Human,
	
		[EnumMember(Value = "feedingstuff")]
		FeedingStuff,
	
		[EnumMember(Value = "further")]
		Further,
	
		[EnumMember(Value = "other")]
		Other,
	
}


