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

public static class IpaffsPurposeForImportOrAdmissionEnumMapper
{
public static Tdm.Model.Ipaffs.IpaffsPurposeForImportOrAdmissionEnum? Map(Tdm.Types.Ipaffs.IpaffsPurposeForImportOrAdmissionEnum? from)
{
if(from == null)
{
return default!;
}
return from switch
{
Tdm.Types.Ipaffs.IpaffsPurposeForImportOrAdmissionEnum.DefinitiveImport => Tdm.Model.Ipaffs.IpaffsPurposeForImportOrAdmissionEnum.DefinitiveImport,
    Tdm.Types.Ipaffs.IpaffsPurposeForImportOrAdmissionEnum.HorsesReEntry => Tdm.Model.Ipaffs.IpaffsPurposeForImportOrAdmissionEnum.HorsesReEntry,
    Tdm.Types.Ipaffs.IpaffsPurposeForImportOrAdmissionEnum.TemporaryAdmissionHorses => Tdm.Model.Ipaffs.IpaffsPurposeForImportOrAdmissionEnum.TemporaryAdmissionHorses,
     
};
}
        

}


