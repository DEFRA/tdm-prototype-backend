
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsConsignmentCheckIdentityCheckTypeEnum
{

		[EnumMember(Value = "Seal Check")]
		SealCheck,
	
		[EnumMember(Value = "Full Identity Check")]
		FullIdentityCheck,
	
		[EnumMember(Value = "Not Done")]
		NotDone, 
        

        // TODO: this was added manually due to data in dev using the below value, which isn't part of the schema
        [EnumMember(Value = "Seal AlvsRequestCheck")]
        SealCheckAlvs,

}


