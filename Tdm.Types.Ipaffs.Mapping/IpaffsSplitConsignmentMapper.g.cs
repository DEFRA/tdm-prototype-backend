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

public static class IpaffsSplitConsignmentMapper
{
	public static Tdm.Model.Ipaffs.IpaffsSplitConsignment Map(Tdm.Types.Ipaffs.IpaffsSplitConsignment from)
	{
	if(from is null)
	{
		return default!;
	}
		var to = new Tdm.Model.Ipaffs.IpaffsSplitConsignment ();
to.ValidReferenceNumber = from.ValidReferenceNumber;
            to.RejectedReferenceNumber = from.RejectedReferenceNumber;
            	return to;
	}
}

