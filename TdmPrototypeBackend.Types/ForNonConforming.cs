
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ForNonConforming
{

		[EnumMember(Value = "Customs Warehouse")]
		Customswarehouse,
	
		[EnumMember(Value = "Free Zone or Free Warehouse")]
		Freezoneorfreewarehouse,
	
		[EnumMember(Value = "Ship Supplier")]
		Shipsupplier,
	
		[EnumMember(Value = "Ship")]
		Ship,
	
}


