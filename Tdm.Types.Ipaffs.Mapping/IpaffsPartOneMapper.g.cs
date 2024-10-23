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

public static class IpaffsPartOneMapper
{
	public static Tdm.Model.Ipaffs.IpaffsPartOne Map(Tdm.Types.Ipaffs.IpaffsPartOne from)
	{
	if(from is null)
	{
		return default!;
	}
		var to = new Tdm.Model.Ipaffs.IpaffsPartOne ();
to.TypeOfImp = IpaffsPartOneTypeOfImpEnumMapper.Map(from?.TypeOfImp);
                to.PersonResponsible = IpaffsPartyMapper.Map(from?.PersonResponsible);
                to.CustomsReferenceNumber = from.CustomsReferenceNumber;
            to.ContainsWoodPackaging = from.ContainsWoodPackaging;
            to.ConsignmentArrived = from.ConsignmentArrived;
            to.Consignor = IpaffsEconomicOperatorMapper.Map(from?.Consignor);
                to.ConsignorTwo = IpaffsEconomicOperatorMapper.Map(from?.ConsignorTwo);
                to.Packer = IpaffsEconomicOperatorMapper.Map(from?.Packer);
                to.Consignee = IpaffsEconomicOperatorMapper.Map(from?.Consignee);
                to.Importer = IpaffsEconomicOperatorMapper.Map(from?.Importer);
                to.PlaceOfDestination = IpaffsEconomicOperatorMapper.Map(from?.PlaceOfDestination);
                to.Pod = IpaffsEconomicOperatorMapper.Map(from?.Pod);
                to.PlaceOfOriginHarvest = IpaffsEconomicOperatorMapper.Map(from?.PlaceOfOriginHarvest);
                to.AdditionalPermanentAddresses = from?.AdditionalPermanentAddresses?.Select(x => IpaffsEconomicOperatorMapper.Map(x)).ToArray();
                to.CphNumber = from.CphNumber;
            to.ImportingFromCharity = from.ImportingFromCharity;
            to.IsPlaceOfDestinationThePermanentAddress = from.IsPlaceOfDestinationThePermanentAddress;
            to.IsCatchCertificateRequired = from.IsCatchCertificateRequired;
            to.IsGvmsRoute = from.IsGvmsRoute;
            to.Purpose = IpaffsPurposeMapper.Map(from?.Purpose);
                to.PointOfEntry = from.PointOfEntry;
            to.PointOfEntryControlPoint = from.PointOfEntryControlPoint;
            to.ArrivalDate = from.ArrivalDate;
            to.ArrivalTime = from.ArrivalTime;
            to.MeansOfTransport = IpaffsMeansOfTransportMapper.Map(from?.MeansOfTransport);
                to.Transporter = IpaffsEconomicOperatorMapper.Map(from?.Transporter);
                to.TransporterDetailsRequired = from.TransporterDetailsRequired;
            to.MeansOfTransportFromEntryPoint = IpaffsMeansOfTransportMapper.Map(from?.MeansOfTransportFromEntryPoint);
                to.DepartureDate = from.DepartureDate;
            to.DepartureTime = from.DepartureTime;
            to.EstimatedJourneyTimeInMinutes = from.EstimatedJourneyTimeInMinutes;
            to.ResponsibleForTransport = from.ResponsibleForTransport;
            to.VeterinaryInformation = IpaffsVeterinaryInformationMapper.Map(from?.VeterinaryInformation);
                to.ImporterLocalReferenceNumber = from.ImporterLocalReferenceNumber;
            to.Route = IpaffsRouteMapper.Map(from?.Route);
                to.SealsContainers = from?.SealsContainers?.Select(x => IpaffsSealContainerMapper.Map(x)).ToArray();
                to.SubmissionDate = from.SubmissionDate;
            to.SubmittedBy = IpaffsUserInformationMapper.Map(from?.SubmittedBy);
                to.ConsignmentValidations = from?.ConsignmentValidations?.Select(x => IpaffsValidationMessageCodeMapper.Map(x)).ToArray();
                to.ComplexCommoditySelected = from.ComplexCommoditySelected;
            to.PortOfEntry = from.PortOfEntry;
            to.PortOfExit = from.PortOfExit;
            to.PortOfExitDate = from.PortOfExitDate;
            to.ContactDetails = IpaffsContactDetailsMapper.Map(from?.ContactDetails);
                to.NominatedContacts = from?.NominatedContacts?.Select(x => IpaffsNominatedContactMapper.Map(x)).ToArray();
                to.OriginalEstimatedDateTime = from.OriginalEstimatedDateTime;
            to.BillingInformation = IpaffsBillingInformationMapper.Map(from?.BillingInformation);
                to.IsChargeable = from.IsChargeable;
            to.WasChargeable = from.WasChargeable;
            to.CommonUserCharge = IpaffsCommonUserChargeMapper.Map(from?.CommonUserCharge);
                to.ProvideCtcMrn = IpaffsPartOneProvideCtcMrnEnumMapper.Map(from?.ProvideCtcMrn);
                	return to;
	}
}

