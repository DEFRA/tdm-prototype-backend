
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsAuthorityTypeEnum
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


