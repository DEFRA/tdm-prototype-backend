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

public static class IpaffsLaboratoryTestResultMapper
{
	public static Tdm.Model.Ipaffs.IpaffsLaboratoryTestResult Map(Tdm.Types.Ipaffs.IpaffsLaboratoryTestResult from)
	{
	if(from is null)
	{
		return default!;
	}
		var to = new Tdm.Model.Ipaffs.IpaffsLaboratoryTestResult ();
to.SampleUseByDate = from.SampleUseByDate;
            to.ReleasedDate = from.ReleasedDate;
            to.LaboratoryTestMethod = from.LaboratoryTestMethod;
            to.Results = from.Results;
            to.Conclusion = IpaffsLaboratoryTestResultConclusionEnumMapper.Map(from?.Conclusion);
                to.LabTestCreatedDate = from.LabTestCreatedDate;
            	return to;
	}
}
