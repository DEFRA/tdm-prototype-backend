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

public static class IpaffsContactDetailsMapper
{
	public static Tdm.Model.Ipaffs.IpaffsContactDetails Map(Tdm.Types.Ipaffs.IpaffsContactDetails from)
	{
	if(from is null)
	{
		return default!;
	}
		var to = new Tdm.Model.Ipaffs.IpaffsContactDetails ();
to.Name = from.Name;
            to.Telephone = from.Telephone;
            to.Email = from.Email;
            to.Agent = from.Agent;
            	return to;
	}
}

