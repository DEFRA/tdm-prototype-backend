
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum CommodityIntendedFor
{

		[EnumMember(Value = "human")]
		Human,
	
		[EnumMember(Value = "feedingstuff")]
		Feedingstuff,
	
		[EnumMember(Value = "further")]
		Further,
	
		[EnumMember(Value = "other")]
		Other,
	
}


