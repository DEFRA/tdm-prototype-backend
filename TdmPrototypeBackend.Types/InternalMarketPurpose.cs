
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum InternalMarketPurpose
{

		[EnumMember(Value = "Animal Feeding Stuff")]
		Animalfeedingstuff,
	
		[EnumMember(Value = "Human Consumption")]
		Humanconsumption,
	
		[EnumMember(Value = "Pharmaceutical Use")]
		Pharmaceuticaluse,
	
		[EnumMember(Value = "Technical Use")]
		Technicaluse,
	
		[EnumMember(Value = "Other")]
		Other,
	
		[EnumMember(Value = "Commercial Sale")]
		Commercialsale,
	
		[EnumMember(Value = "Commercial sale or change of ownership")]
		Commercialsaleorchangeofownership,
	
		[EnumMember(Value = "Rescue")]
		Rescue,
	
		[EnumMember(Value = "Breeding")]
		Breeding,
	
		[EnumMember(Value = "Research")]
		Research,
	
		[EnumMember(Value = "Racing or Competition")]
		Racingorcompetition,
	
		[EnumMember(Value = "Approved Premises or Body")]
		Approvedpremisesorbody,
	
		[EnumMember(Value = "Companion Animal not for Resale or Rehoming")]
		Companionanimalnotforresaleorrehoming,
	
		[EnumMember(Value = "Production")]
		Production,
	
		[EnumMember(Value = "Slaughter")]
		Slaughter,
	
		[EnumMember(Value = "Fattening")]
		Fattening,
	
		[EnumMember(Value = "Game Restocking")]
		Gamerestocking,
	
		[EnumMember(Value = "Registered Horses")]
		Registeredhorses,
	
}


