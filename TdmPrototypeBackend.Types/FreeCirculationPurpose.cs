
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum FreeCirculationPurpose
{

		[EnumMember(Value = "Animal Feeding Stuff")]
		Animalfeedingstuff,
	
		[EnumMember(Value = "Human Consumption")]
		Humanconsumption,
	
		[EnumMember(Value = "Pharmaceutical Use")]
		Pharmaceuticaluse,
	
		[EnumMember(Value = "Technical Use")]
		Technicaluse,
	
		[EnumMember(Value = "Further Process")]
		Furtherprocess,
	
		[EnumMember(Value = "Other")]
		Other,
	
}


