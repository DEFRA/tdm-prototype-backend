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

public static class IpaffsOfficialInspectorMapper
{
	public static Tdm.Model.Ipaffs.IpaffsOfficialInspector Map(Tdm.Types.Ipaffs.IpaffsOfficialInspector from)
	{
	if(from is null)
	{
		return default!;
	}
		var to = new Tdm.Model.Ipaffs.IpaffsOfficialInspector ();
to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Email = from.Email;
            to.Phone = from.Phone;
            to.Fax = from.Fax;
            to.Address = IpaffsAddressMapper.Map(from?.Address);
                to.Signed = from.Signed;
            	return to;
	}
}
