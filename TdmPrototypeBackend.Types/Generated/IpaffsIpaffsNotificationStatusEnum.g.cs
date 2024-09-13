
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsIpaffsNotificationStatusEnum
{

		[EnumMember(Value = "DRAFT")]
		Draft,
	
		[EnumMember(Value = "SUBMITTED")]
		Submitted,
	
		[EnumMember(Value = "VALIDATED")]
		Validated,
	
		[EnumMember(Value = "REJECTED")]
		Rejected,
	
		[EnumMember(Value = "IN_PROGRESS")]
		INPROGRESS,
	
		[EnumMember(Value = "AMEND")]
		Amend,
	
		[EnumMember(Value = "MODIFY")]
		Modify,
	
		[EnumMember(Value = "REPLACED")]
		Replaced,
	
		[EnumMember(Value = "CANCELLED")]
		Cancelled,
	
		[EnumMember(Value = "DELETED")]
		Deleted,
	
		[EnumMember(Value = "PARTIALLY_REJECTED")]
		PARTIALLYREJECTED,
	
		[EnumMember(Value = "SPLIT_CONSIGNMENT")]
		SPLITCONSIGNMENT,
	
		[EnumMember(Value = "SUBMITTED,IN_PROGRESS,MODIFY")]
		SUBMITTEDINPROGRESSMODIFY,
	
}


