//------------------------------------------------------------------------------
// <auto-generated>
    //     This code was generated from a template.
    //
    //     Manual changes to this file may cause unexpected behavior in your application.
    //     Manual changes to this file will be overwritten if the code is regenerated.
    // </auto-generated>
//------------------------------------------------------------------------------
#nullable enable


namespace Tdm.Types.Ipaffs;

public static class IpaffsPartyTypeEnumMapper
{
public static Tdm.Model.Ipaffs.IpaffsPartyTypeEnum Map(Tdm.Types.Ipaffs.IpaffsPartyTypeEnum? from)
{
if(from == null)
{
return default!;
}
return from switch
{
Tdm.Types.Ipaffs.IpaffsPartyTypeEnum.CommercialTransporter => Tdm.Model.Ipaffs.IpaffsPartyTypeEnum.CommercialTransporter,
    Tdm.Types.Ipaffs.IpaffsPartyTypeEnum.PrivateTransporter => Tdm.Model.Ipaffs.IpaffsPartyTypeEnum.PrivateTransporter,
     
};
}
        

}


