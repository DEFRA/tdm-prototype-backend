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

public static class IpaffsCommodityRiskResultHmiDecisionEnumMapper
{
public static Tdm.Model.Ipaffs.IpaffsCommodityRiskResultHmiDecisionEnum Map(Tdm.Types.Ipaffs.IpaffsCommodityRiskResultHmiDecisionEnum? from)
{
if(from == null)
{
return default!;
}
return from switch
{
Tdm.Types.Ipaffs.IpaffsCommodityRiskResultHmiDecisionEnum.Required => Tdm.Model.Ipaffs.IpaffsCommodityRiskResultHmiDecisionEnum.Required,
    Tdm.Types.Ipaffs.IpaffsCommodityRiskResultHmiDecisionEnum.Notrequired => Tdm.Model.Ipaffs.IpaffsCommodityRiskResultHmiDecisionEnum.Notrequired,
     
};
}
        

}

