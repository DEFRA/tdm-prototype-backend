using System.Diagnostics;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;

namespace TdmPrototypeDmpSynchroniser.Api.Models;

public static class NotificationExtensions
{
    
    public static Notification FromBlob(string s)
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            // PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };
        
        var r = JsonSerializer.Deserialize<Notification>(s, options)!;
        // r.Transform();
        // r.Id = r.ReferenceNumber;
        
        return r;
    }
    
    // private static void Transform(this Notification n)
    // {
    //     var complementParameters = new Dictionary<string, IpaffsComplementParameterSet>();
    //     var complementRiskAssesments = new Dictionary<string, IpaffsCommodityRiskResult>();
    //     
    //     foreach (var commoditiesCommodityComplement in n.PartOne!.Commodities!.ComplementParameterSets!)
    //     {
    //         complementParameters[commoditiesCommodityComplement.UniqueComplementID!] = commoditiesCommodityComplement;
    //     }
    //     
    //     foreach (var commoditiesRA in n.RiskAssessment!.CommodityResults!)
    //     {
    //         complementRiskAssesments[commoditiesRA.UniqueId!] = commoditiesRA;
    //     }
    //     
    //     // private delegate void Assign(IpaffsCommodityComplement complement);
    //     //
    //     // Func<IpaffsCommodityComplement complement> assign = (IpaffsCommodityComplement complement) =>
    //     // {
    //     //     return null;
    //     // };
    //     
    //     // if (n.PartOne!.Commodities!.CommodityComplements.Length == 1)
    //     // {
    //     //     
    //     // }
    //     // else
    //     // {
    //     //     foreach (var commodity in n.PartOne!.Commodities!.CommodityComplements)
    //     //     {
    //     //         var parameters = complementParameters[commodity.UniqueComplementID!];
    //     //         commodity.AdditionalData = parameters.KeyDataPairs.
    //     //         commodity.RiskAssesment = complementRiskAssesments[commodity.UniqueComplementID!];
    //     //     }
    //     //
    //     // }
    //     
    //     n.PartOne.Commodities.CommodityComplements[0].AdditionalData["number_animal"] = 1;
    //     n.PartOne.Commodities.CommodityComplements[0].AdditionalData["number_package"] = 1;
    //     n.PartOne.Commodities.CommodityComplements[0].RiskAssesment = new IpaffsCommodityRiskResult()
    //     {
    //         RiskDecision = IpaffsCommodityRiskResultRiskDecisionEnum.Inconclusive
    //     };
    //     // return n;
    // }
}