//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable


namespace Tdm.Types.Alvs;

public static class AlvsClearanceRequestPostMapper
{
	public static Tdm.Model.Alvs.AlvsClearanceRequestPost Map(Tdm.Types.Alvs.AlvsClearanceRequestPost from)
    {
    if(from is null)
    {
        return default!;
    }
		var to = new Tdm.Model.Alvs.AlvsClearanceRequestPost ();
to.XmlSchemaVersion = from.XmlSchemaVersion;
        to.UserIdentification = from.UserIdentification;
        to.UserPassword = from.UserPassword;
        to.SendingDate = from.SendingDate;
        to.AlvsClearanceRequest = AlvsClearanceRequestMapper.Map(from?.AlvsClearanceRequest);
            	return to;
    }
}



