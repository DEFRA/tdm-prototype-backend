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

public static class IpaffsPurposeForNonConformingEnumMapper
{
public static Tdm.Model.Ipaffs.IpaffsPurposeForNonConformingEnum Map(Tdm.Types.Ipaffs.IpaffsPurposeForNonConformingEnum? from)
{
if(from == null)
{
return default!;
}
return from switch
{
Tdm.Types.Ipaffs.IpaffsPurposeForNonConformingEnum.CustomsWarehouse => Tdm.Model.Ipaffs.IpaffsPurposeForNonConformingEnum.CustomsWarehouse,
    Tdm.Types.Ipaffs.IpaffsPurposeForNonConformingEnum.FreeZoneOrFreeWarehouse => Tdm.Model.Ipaffs.IpaffsPurposeForNonConformingEnum.FreeZoneOrFreeWarehouse,
    Tdm.Types.Ipaffs.IpaffsPurposeForNonConformingEnum.ShipSupplier => Tdm.Model.Ipaffs.IpaffsPurposeForNonConformingEnum.ShipSupplier,
    Tdm.Types.Ipaffs.IpaffsPurposeForNonConformingEnum.Ship => Tdm.Model.Ipaffs.IpaffsPurposeForNonConformingEnum.Ship,
     
};
}
        

}

