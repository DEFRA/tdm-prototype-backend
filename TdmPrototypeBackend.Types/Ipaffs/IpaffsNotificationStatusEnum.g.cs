
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsNotificationStatusEnum
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
		Inprogress,
	
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
		Partiallyrejected,
	
		[EnumMember(Value = "SPLIT_CONSIGNMENT")]
		Splitconsignment,
	
		[EnumMember(Value = "SUBMITTED,IN_PROGRESS,MODIFY")]
		SUBMITTEDINPROGRESSMODIFY,
	
}


