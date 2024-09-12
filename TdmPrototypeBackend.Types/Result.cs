
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Result
{

		[EnumMember(Value = "Satisfactory")]
		Satisfactory,
	
		[EnumMember(Value = "Satisfactory following official intervention")]
		Satisfactoryfollowingofficialintervention,
	
		[EnumMember(Value = "Not Satisfactory")]
		Notsatisfactory,
	
		[EnumMember(Value = "Not Done")]
		Notdone,
	
		[EnumMember(Value = "Derogation")]
		Derogation,
	
		[EnumMember(Value = "Not Set")]
		Notset,
	
}


