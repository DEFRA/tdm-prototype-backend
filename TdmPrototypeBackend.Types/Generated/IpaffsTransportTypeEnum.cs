
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsTransportTypeEnum
{

		[EnumMember(Value = "rail")]
		Rail,
	
		[EnumMember(Value = "plane")]
		Plane,
	
		[EnumMember(Value = "ship")]
		Ship,
	
		[EnumMember(Value = "road")]
		Road,
	
		[EnumMember(Value = "other")]
		Other,
	
		[EnumMember(Value = "c_ship_road")]
		CShipRoad,
	
		[EnumMember(Value = "c_ship_rail")]
		CShipRail,
	
}


