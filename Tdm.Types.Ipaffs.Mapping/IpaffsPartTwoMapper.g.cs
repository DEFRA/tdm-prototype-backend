//------------------------------------------------------------------------------
// <auto-generated>
	//     This code was generated from a template.
	//
	//     Manual changes to this file may cause unexpected behavior in your application.
	//     Manual changes to this file will be overwritten if the code is regenerated.
	//
//</auto-generated>
//------------------------------------------------------------------------------
#nullable enable


namespace Tdm.Types.Ipaffs;

public static class IpaffsPartTwoMapper
{
	public static Tdm.Model.Ipaffs.IpaffsPartTwo Map(Tdm.Types.Ipaffs.IpaffsPartTwo from)
	{
	if(from is null)
	{
		return default!;
	}
		var to = new Tdm.Model.Ipaffs.IpaffsPartTwo ();
to.Decision = IpaffsDecisionMapper.Map(from?.Decision);
                to.ConsignmentCheck = IpaffsConsignmentCheckMapper.Map(from?.ConsignmentCheck);
                to.ImpactOfTransportOnAnimals = IpaffsImpactOfTransportOnAnimalsMapper.Map(from?.ImpactOfTransportOnAnimals);
                to.LaboratoryTestsRequired = from.LaboratoryTestsRequired;
            to.LaboratoryTests = IpaffsLaboratoryTestsMapper.Map(from?.LaboratoryTests);
                to.ResealedContainersIncluded = from.ResealedContainersIncluded;
            to.ResealedContainers = from.ResealedContainers;
            to.ResealedContainersMappings = from?.ResealedContainersMappings?.Select(x => IpaffsSealContainerMapper.Map(x)).ToArray();
                to.ControlAuthority = IpaffsControlAuthorityMapper.Map(from?.ControlAuthority);
                to.ControlledDestination = IpaffsEconomicOperatorMapper.Map(from?.ControlledDestination);
                to.BipLocalReferenceNumber = from.BipLocalReferenceNumber;
            to.SignedOnBehalfOf = from.SignedOnBehalfOf;
            to.OnwardTransportation = from.OnwardTransportation;
            to.ConsignmentValidations = from?.ConsignmentValidations?.Select(x => IpaffsValidationMessageCodeMapper.Map(x)).ToArray();
                to.CheckDate = from.CheckDate;
            to.AccompanyingDocuments = from?.AccompanyingDocuments?.Select(x => IpaffsAccompanyingDocumentMapper.Map(x)).ToArray();
                to.PhsiAutoCleared = from.PhsiAutoCleared;
            to.HmiAutoCleared = from.HmiAutoCleared;
            to.InspectionRequired = from.InspectionRequired;
            to.InspectionOverride = IpaffsInspectionOverrideMapper.Map(from?.InspectionOverride);
                to.AutoClearedDateTime = from.AutoClearedDateTime;
            	return to;
	}
}
