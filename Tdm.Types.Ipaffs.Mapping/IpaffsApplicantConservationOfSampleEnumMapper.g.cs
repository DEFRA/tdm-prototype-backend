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

public static class IpaffsApplicantConservationOfSampleEnumMapper
{
public static Tdm.Model.Ipaffs.IpaffsApplicantConservationOfSampleEnum Map(Tdm.Types.Ipaffs.IpaffsApplicantConservationOfSampleEnum? from)
{
if(from == null)
{
return default!;
}
return from switch
{
Tdm.Types.Ipaffs.IpaffsApplicantConservationOfSampleEnum.Ambient => Tdm.Model.Ipaffs.IpaffsApplicantConservationOfSampleEnum.Ambient,
    Tdm.Types.Ipaffs.IpaffsApplicantConservationOfSampleEnum.Chilled => Tdm.Model.Ipaffs.IpaffsApplicantConservationOfSampleEnum.Chilled,
    Tdm.Types.Ipaffs.IpaffsApplicantConservationOfSampleEnum.Frozen => Tdm.Model.Ipaffs.IpaffsApplicantConservationOfSampleEnum.Frozen,
     
};
}
        

}

