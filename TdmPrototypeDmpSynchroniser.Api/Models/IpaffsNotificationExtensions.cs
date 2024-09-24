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
        r.Transform();
        
        return r;
    }
    
    private static void Transform(this Notification n)
    {
        if (n.PartOne!.Commodities!.CommodityComplements.Length == 1)
        {
            n.PartOne!.Commodities!.CommodityComplements[0].AdditionalData = n.PartOne!.Commodities!.ComplementParameterSets![0].KeyDataPairs;
            if (n.RiskAssessment != null)
            {
                n.PartOne!.Commodities!.CommodityComplements[0].RiskAssesment = n.RiskAssessment.CommodityResults[0];    
            }
        }
        else
        {
            var complementParameters = new Dictionary<string, IpaffsComplementParameterSet>();
            var complementRiskAssesments = new Dictionary<string, IpaffsCommodityRiskResult>();
        
            foreach (var commoditiesCommodityComplement in n.PartOne!.Commodities!.ComplementParameterSets!)
            {
                complementParameters[commoditiesCommodityComplement.UniqueComplementID!] = commoditiesCommodityComplement;
            }

            if (n.RiskAssessment != null)
            {
                foreach (var commoditiesRa in n.RiskAssessment.CommodityResults!)
                {
                    complementRiskAssesments[commoditiesRa.UniqueId!] = commoditiesRa;
                }
            }
            
            foreach (var commodity in n.PartOne!.Commodities!.CommodityComplements)
            {
                var parameters = complementParameters[commodity.UniqueComplementID!];
                commodity.AdditionalData = parameters.KeyDataPairs;
                commodity.RiskAssesment = complementRiskAssesments[commodity.UniqueComplementID!];
            }
        
        }
    }
}