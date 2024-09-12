
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum NotAcceptableAction
{

		[EnumMember(Value = "slaughter")]
		Slaughter,
	
		[EnumMember(Value = "reexport")]
		Reexport,
	
		[EnumMember(Value = "euthanasia")]
		Euthanasia,
	
		[EnumMember(Value = "redispatching")]
		Redispatching,
	
		[EnumMember(Value = "destruction")]
		Destruction,
	
		[EnumMember(Value = "transformation")]
		Transformation,
	
		[EnumMember(Value = "other")]
		Other,
	
		[EnumMember(Value = "entry-refusal")]
		Entryrefusal,
	
		[EnumMember(Value = "quarantine-imposed")]
		Quarantineimposed,
	
		[EnumMember(Value = "special-treatment")]
		Specialtreatment,
	
		[EnumMember(Value = "industrial-processing")]
		Industrialprocessing,
	
		[EnumMember(Value = "re-dispatch")]
		Redispatch,
	
		[EnumMember(Value = "use-for-other-purposes")]
		Useforotherpurposes,
	
}


