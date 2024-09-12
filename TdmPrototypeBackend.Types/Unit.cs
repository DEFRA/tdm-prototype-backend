
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Unit
{

		[EnumMember(Value = "percent")]
		Percent,
	
		[EnumMember(Value = "number")]
		Number,
	
}


