
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Conclusion
{

		[EnumMember(Value = "Satisfactory")]
		Satisfactory,
	
		[EnumMember(Value = "Not satisfactory")]
		Notsatisfactory,
	
		[EnumMember(Value = "Not interpretable")]
		Notinterpretable,
	
		[EnumMember(Value = "Pending")]
		Pending,
	
}


