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

public static class IpaffsApplicantMapper
{
	public static Tdm.Model.Ipaffs.IpaffsApplicant Map(Tdm.Types.Ipaffs.IpaffsApplicant from)
	{
	if(from is null)
	{
		return default!;
	}
		var to = new Tdm.Model.Ipaffs.IpaffsApplicant ();
to.Laboratory = from.Laboratory;
            to.LaboratoryAddress = from.LaboratoryAddress;
            to.LaboratoryIdentification = from.LaboratoryIdentification;
            to.LaboratoryPhoneNumber = from.LaboratoryPhoneNumber;
            to.LaboratoryEmail = from.LaboratoryEmail;
            to.SampleBatchNumber = from.SampleBatchNumber;
            to.AnalysisType = IpaffsApplicantAnalysisTypeEnumMapper.Map(from?.AnalysisType);
                to.NumberOfSamples = from.NumberOfSamples;
            to.SampleType = from.SampleType;
            to.ConservationOfSample = IpaffsApplicantConservationOfSampleEnumMapper.Map(from?.ConservationOfSample);
                to.Inspector = IpaffsInspectorMapper.Map(from?.Inspector);
                to.SampleDate = from.SampleDate;
            to.SampleTime = from.SampleTime;
            	return to;
	}
}
