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

public static class IpaffsPurposeMapper
{
	public static Tdm.Model.Ipaffs.IpaffsPurpose Map(Tdm.Types.Ipaffs.IpaffsPurpose from)
	{
	if(from is null)
	{
		return default!;
	}
		var to = new Tdm.Model.Ipaffs.IpaffsPurpose ();
to.ConformsToEU = from.ConformsToEU;
            to.InternalMarketPurpose = IpaffsPurposeInternalMarketPurposeEnumMapper.Map(from?.InternalMarketPurpose);
                to.ThirdCountryTranshipment = from.ThirdCountryTranshipment;
            to.ForNonConforming = IpaffsPurposeForNonConformingEnumMapper.Map(from?.ForNonConforming);
                to.RegNumber = from.RegNumber;
            to.ShipName = from.ShipName;
            to.ShipPort = from.ShipPort;
            to.ExitBIP = from.ExitBIP;
            to.ThirdCountry = from.ThirdCountry;
            to.TransitThirdCountries = from.TransitThirdCountries;
            to.ForImportOrAdmission = IpaffsPurposeForImportOrAdmissionEnumMapper.Map(from?.ForImportOrAdmission);
                to.ExitDate = from.ExitDate;
            to.FinalBIP = from.FinalBIP;
            to.PurposeGroup = IpaffsPurposePurposeGroupEnumMapper.Map(from?.PurposeGroup);
                to.EstimatedArrivalDateAtPortOfExit = from.EstimatedArrivalDateAtPortOfExit;
            to.EstimatedArrivalTimeAtPortOfExit = from.EstimatedArrivalTimeAtPortOfExit;
            	return to;
	}
}
