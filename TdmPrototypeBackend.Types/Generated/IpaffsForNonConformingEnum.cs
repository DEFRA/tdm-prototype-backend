
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsForNonConformingEnum
{

		[EnumMember(Value = "Customs Warehouse")]
		CustomsWarehouse,
	
		[EnumMember(Value = "Free Zone or Free Warehouse")]
		FreeZoneOrFreeWarehouse,
	
		[EnumMember(Value = "Ship Supplier")]
		ShipSupplier,
	
		[EnumMember(Value = "Ship")]
		Ship,
	
}


