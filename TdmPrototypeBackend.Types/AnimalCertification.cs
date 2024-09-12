
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum AnimalCertification
{

		[EnumMember(Value = "Animal feeding stuff")]
		Animalfeedingstuff,
	
		[EnumMember(Value = "Approved")]
		Approved,
	
		[EnumMember(Value = "Artificial reproduction")]
		Artificialreproduction,
	
		[EnumMember(Value = "Breeding")]
		Breeding,
	
		[EnumMember(Value = "Circus")]
		Circus,
	
		[EnumMember(Value = "Commercial sale")]
		Commercialsale,
	
		[EnumMember(Value = "Commercial sale or change of ownership")]
		Commercialsaleorchangeofownership,
	
		[EnumMember(Value = "Fattening")]
		Fattening,
	
		[EnumMember(Value = "Game restocking")]
		Gamerestocking,
	
		[EnumMember(Value = "Human consumption")]
		Humanconsumption,
	
		[EnumMember(Value = "Internal market")]
		Internalmarket,
	
		[EnumMember(Value = "Other")]
		Other,
	
		[EnumMember(Value = "Personally owned pets not for rehoming")]
		Personallyownedpetsnotforrehoming,
	
		[EnumMember(Value = "Pets")]
		Pets,
	
		[EnumMember(Value = "Production")]
		Production,
	
		[EnumMember(Value = "Quarantine")]
		Quarantine,
	
		[EnumMember(Value = "Racing/Competition")]
		Racingcompetition,
	
		[EnumMember(Value = "Registered equidae")]
		Registeredequidae,
	
		[EnumMember(Value = "Registered")]
		Registered,
	
		[EnumMember(Value = "Rejected or Returned consignment")]
		Rejectedorreturnedconsignment,
	
		[EnumMember(Value = "Relaying")]
		Relaying,
	
		[EnumMember(Value = "Rescue/Rehoming")]
		Rescuerehoming,
	
		[EnumMember(Value = "Research")]
		Research,
	
		[EnumMember(Value = "Slaughter")]
		Slaughter,
	
		[EnumMember(Value = "Technical/Pharmaceutical use")]
		Technicalpharmaceuticaluse,
	
		[EnumMember(Value = "Transit")]
		Transit,
	
		[EnumMember(Value = "Zoo/Collection")]
		Zoocollection,
	
}


