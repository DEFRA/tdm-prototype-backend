
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SpecificWarehouseNonConformingConsignment
{

		[EnumMember(Value = "CustomWarehouse")]
		Customwarehouse,
	
		[EnumMember(Value = "FreeZoneOrFreeWarehouse")]
		Freezoneorfreewarehouse,
	
		[EnumMember(Value = "ShipSupplier")]
		Shipsupplier,
	
		[EnumMember(Value = "Ship")]
		Ship,
	
}


