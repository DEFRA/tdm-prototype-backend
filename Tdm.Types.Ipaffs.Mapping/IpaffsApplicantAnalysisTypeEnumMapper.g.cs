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

public static class IpaffsApplicantAnalysisTypeEnumMapper
{
public static Tdm.Model.Ipaffs.IpaffsApplicantAnalysisTypeEnum? Map(Tdm.Types.Ipaffs.IpaffsApplicantAnalysisTypeEnum? from)
{
if(from == null)
{
return default!;
}
return from switch
{
Tdm.Types.Ipaffs.IpaffsApplicantAnalysisTypeEnum.InitialAnalysis => Tdm.Model.Ipaffs.IpaffsApplicantAnalysisTypeEnum.InitialAnalysis,
    Tdm.Types.Ipaffs.IpaffsApplicantAnalysisTypeEnum.CounterAnalysis => Tdm.Model.Ipaffs.IpaffsApplicantAnalysisTypeEnum.CounterAnalysis,
    Tdm.Types.Ipaffs.IpaffsApplicantAnalysisTypeEnum.SecondExpertAnalysis => Tdm.Model.Ipaffs.IpaffsApplicantAnalysisTypeEnum.SecondExpertAnalysis,
     
};
}
        

}


