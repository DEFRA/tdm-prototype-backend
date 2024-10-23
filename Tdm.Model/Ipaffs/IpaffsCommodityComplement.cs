using System.Text.Json.Serialization;
using JsonApiDotNetCore.Resources.Annotations;

namespace Tdm.Model.Ipaffs;

/// <summary>
/// Holder for additional parameters of a commodity line item
/// </summary>
public partial class IpaffsCommodityComplement  //
{
    [Attr] public IDictionary<string, object>? AdditionalData { get; set; } = new Dictionary<string, object>();
	
    [Attr]
    public IpaffsCommodityRiskResult? RiskAssesment { get; set; }

    [Attr]
    [JsonPropertyName("checks")]
    public IpaffsInspectionCheck[]? Checks { get; set; }


}


