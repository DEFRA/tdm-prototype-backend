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

public static class IpaffsEconomicOperatorMapper
{
	public static Tdm.Model.Ipaffs.IpaffsEconomicOperator Map(Tdm.Types.Ipaffs.IpaffsEconomicOperator from)
	{
	if(from is null)
	{
		return default!;
	}
		var to = new Tdm.Model.Ipaffs.IpaffsEconomicOperator ();
to.IpaffsId = from.IpaffsId;
            to.IpaffsType = IpaffsEconomicOperatorTypeEnumMapper.Map(from?.IpaffsType);
                to.Status = IpaffsEconomicOperatorStatusEnumMapper.Map(from?.Status);
                to.CompanyName = from.CompanyName;
            to.IndividualName = from.IndividualName;
            to.Address = IpaffsAddressMapper.Map(from?.Address);
                to.ApprovalNumber = from.ApprovalNumber;
            to.OtherIdentifier = from.OtherIdentifier;
            to.TracesId = from.TracesId;
            	return to;
	}
}
