
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsTemperatureEnum
{

		[EnumMember(Value = "Ambient")]
		Ambient,
	
		[EnumMember(Value = "Chilled")]
		Chilled,
	
		[EnumMember(Value = "Frozen")]
		Frozen,
	
}


