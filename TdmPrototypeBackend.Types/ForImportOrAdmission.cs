
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ForImportOrAdmission
{

		[EnumMember(Value = "Definitive import")]
		Definitiveimport,
	
		[EnumMember(Value = "Horses Re-entry")]
		Horsesreentry,
	
		[EnumMember(Value = "Temporary admission horses")]
		Temporaryadmissionhorses,
	
}


