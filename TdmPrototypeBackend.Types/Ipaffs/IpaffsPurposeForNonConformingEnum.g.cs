
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace TdmPrototypeBackend.Types.Ipaffs;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsPurposeForNonConformingEnum
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


