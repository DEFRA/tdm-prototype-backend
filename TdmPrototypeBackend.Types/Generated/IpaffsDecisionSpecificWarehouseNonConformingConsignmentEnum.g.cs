
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsDecisionSpecificWarehouseNonConformingConsignmentEnum
{

		[EnumMember(Value = "CustomWarehouse")]
		CustomWarehouse,
	
		[EnumMember(Value = "FreeZoneOrFreeWarehouse")]
		FreeZoneOrFreeWarehouse,
	
		[EnumMember(Value = "ShipSupplier")]
		ShipSupplier,
	
		[EnumMember(Value = "Ship")]
		Ship,
	
}


