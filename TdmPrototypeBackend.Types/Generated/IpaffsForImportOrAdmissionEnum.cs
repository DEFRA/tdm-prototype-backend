
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsForImportOrAdmissionEnum
{

		[EnumMember(Value = "Definitive import")]
		DefinitiveImport,
	
		[EnumMember(Value = "Horses Re-entry")]
		HorsesReEntry,
	
		[EnumMember(Value = "Temporary admission horses")]
		TemporaryAdmissionHorses,
	
}


