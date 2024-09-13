
using System.ComponentModel;
using System.Runtime.Serialization;


namespace TdmPrototypeBackend.Types;

//[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IpaffsFreeCirculationPurposeEnum
{

		[EnumMember(Value = "Animal Feeding Stuff")]
		AnimalFeedingStuff,
	
		[EnumMember(Value = "Human Consumption")]
		HumanConsumption,
	
		[EnumMember(Value = "Pharmaceutical Use")]
		PharmaceuticalUse,
	
		[EnumMember(Value = "Technical Use")]
		TechnicalUse,
	
		[EnumMember(Value = "Further Process")]
		FurtherProcess,
	
		[EnumMember(Value = "Other")]
		Other,
	
}

