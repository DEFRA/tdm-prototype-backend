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

public static class IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnumMapper
{
public static Tdm.Model.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum? Map(Tdm.Types.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum? from)
{
if(from == null)
{
return default!;
}
return from switch
{
Tdm.Types.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum.ContaminatedProducts => Tdm.Model.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum.ContaminatedProducts,
    Tdm.Types.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum.InterceptedPart => Tdm.Model.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum.InterceptedPart,
    Tdm.Types.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum.PackagingMaterial => Tdm.Model.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum.PackagingMaterial,
    Tdm.Types.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum.MeansOfTransport => Tdm.Model.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum.MeansOfTransport,
    Tdm.Types.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum.Other => Tdm.Model.Ipaffs.IpaffsDecisionNotAcceptableActionEntryRefusalReasonEnum.Other,
     
};
}
        

}


