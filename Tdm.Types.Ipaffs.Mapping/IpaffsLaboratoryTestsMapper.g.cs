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

public static class IpaffsLaboratoryTestsMapper
{
	public static Tdm.Model.Ipaffs.IpaffsLaboratoryTests Map(Tdm.Types.Ipaffs.IpaffsLaboratoryTests from)
	{
	if(from is null)
	{
		return default!;
	}
		var to = new Tdm.Model.Ipaffs.IpaffsLaboratoryTests ();
to.TestDate = from.TestDate;
            to.TestReason = IpaffsLaboratoryTestsTestReasonEnumMapper.Map(from?.TestReason);
                to.SingleLaboratoryTests = from?.SingleLaboratoryTests?.Select(x => IpaffsSingleLaboratoryTestMapper.Map(x)).ToArray();
                	return to;
	}
}

