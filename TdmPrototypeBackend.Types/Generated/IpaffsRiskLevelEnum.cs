
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsRiskLevelEnum
{

		[EnumMember(Value = "High")]
		High,
	
		[EnumMember(Value = "Medium")]
		Medium,
	
		[EnumMember(Value = "Low")]
		Low,
	
}


