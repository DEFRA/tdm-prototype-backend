
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsSpecificWarehouseNonConformingConsignmentEnum
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


