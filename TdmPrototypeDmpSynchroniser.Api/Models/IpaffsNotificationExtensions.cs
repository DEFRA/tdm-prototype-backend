using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;
using TdmPrototypeBackend.Types.Ipaffs;
using TdmPrototypeDmpSynchroniser.Api.SensitiveData;

namespace TdmPrototypeDmpSynchroniser.Api.Models;

public static class NotificationExtensions
{
    
    public static Notification FromBlob(string s, ISensitiveDataSerializer sensitiveDataSerializer)
    {
        var r = sensitiveDataSerializer.Deserialize<Notification>(s, _ => {})!;
        r.Transform();
        
        return r;
    }

    public static string FromSnakeCase(this string input)
    {
        if (input == "netweight")
        {
            return "netWeight";
        }
        var pascal = input.Split(new [] {"_"}, StringSplitOptions.RemoveEmptyEntries).Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1)).Aggregate(string.Empty, (s1, s2) => s1 + s2);
        return char.ToLower(pascal[0]) + pascal[1..];
    }

    public static IDictionary<string, object> FromSnakeCase(this IDictionary<string, object> input)
    {
        // var output = from pair in input
        //     select pair.Key;

        return input.ToDictionary(mc => mc.Key.FromSnakeCase(),
            mc => mc.Value);
        
        // return output;
    }
    
    private static void Transform(this Notification n)
    {
        var commodities = n.PartOne!.Commodities;

        if (commodities!.CommodityComplements!.Length == 1)
        {
            commodities!.CommodityComplements[0].AdditionalData = commodities!.ComplementParameterSets![0].KeyDataPairs!.FromSnakeCase();
            if (n.RiskAssessment != null)
            {
                commodities!.CommodityComplements[0].RiskAssesment = n.RiskAssessment.CommodityResults![0];    
            }
        }
        else
        {
            var complementParameters = new Dictionary<int, IpaffsComplementParameterSet>();
            var complementRiskAssesments = new Dictionary<string, IpaffsCommodityRiskResult>();
            var commodityChecks = new Dictionary<string, IpaffsInspectionCheck[]>();

            foreach (var commoditiesCommodityComplement in commodities!.ComplementParameterSets!)
            {
                complementParameters[commoditiesCommodityComplement.ComplementID.Value!] = commoditiesCommodityComplement;
            }

            if (n.RiskAssessment != null)
            {
                foreach (var commoditiesRa in n.RiskAssessment.CommodityResults!)
                {
                    complementRiskAssesments[commoditiesRa.UniqueId!] = commoditiesRa;
                }
            }

            if (n.PartTwo?.CommodityChecks != null)
            {
                foreach (var commodityCheck in n.PartTwo?.CommodityChecks)
                {
                    commodityChecks[commodityCheck.UniqueComplementId] = commodityCheck.Checks;
                }
            }
            
            foreach (var commodity in commodities!.CommodityComplements)
            {
                var parameters = complementParameters[commodity.ComplementID.Value!];
                commodity.AdditionalData = parameters.KeyDataPairs.FromSnakeCase();

                if (complementRiskAssesments.Any() && 
                    parameters.UniqueComplementID is not null && 
                    complementRiskAssesments.ContainsKey(parameters.UniqueComplementID))
                {
                    commodity.RiskAssesment = complementRiskAssesments[parameters.UniqueComplementID!];
                    
                }

                if (commodityChecks.Any() &&
                    parameters.UniqueComplementID is not null &&
                    commodityChecks.ContainsKey(parameters.UniqueComplementID))
                {
                    commodity.Checks = commodityChecks[parameters.UniqueComplementID!];
                }
            }
        }

        n.CommoditiesSummary = commodities;
        n.Commodities= commodities.CommodityComplements.Select(x => x).ToArray();
    }
}