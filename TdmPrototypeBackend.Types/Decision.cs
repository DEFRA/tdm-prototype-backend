
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Decision
{

		[EnumMember(Value = "Non Acceptable")]
		Nonacceptable,
	
		[EnumMember(Value = "Acceptable for Internal Market")]
		Acceptableforinternalmarket,
	
		[EnumMember(Value = "Acceptable if Channeled")]
		Acceptableifchanneled,
	
		[EnumMember(Value = "Acceptable for Transhipment")]
		Acceptablefortranshipment,
	
		[EnumMember(Value = "Acceptable for Transit")]
		Acceptablefortransit,
	
		[EnumMember(Value = "Acceptable for Temporary Import")]
		Acceptablefortemporaryimport,
	
		[EnumMember(Value = "Acceptable for Specific Warehouse")]
		Acceptableforspecificwarehouse,
	
		[EnumMember(Value = "Acceptable for Private Import")]
		Acceptableforprivateimport,
	
		[EnumMember(Value = "Acceptable for Transfer")]
		Acceptablefortransfer,
	
		[EnumMember(Value = "Horse Re-entry")]
		Horsereentry,
	
}


