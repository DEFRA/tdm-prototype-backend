//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable

using System.Text.Json.Serialization;
using System.Dynamic;


namespace Tdm.Types.Ipaffs;

/// <summary>
/// Details of the risk categorisation level for a notification
/// </summary>
public partial class IpaffsJourneyRiskCategorisationResult  //
{


    /// <summary>
    /// Risk Level is defined using enum values High,Medium,Low
    /// </summary
    [JsonPropertyName("riskLevel")]
    public IpaffsJourneyRiskCategorisationResultRiskLevelEnum? RiskLevel { get; set; }

	
    /// <summary>
    /// Indicator of whether the risk level was determined by the system or by the user
    /// </summary
    [JsonPropertyName("riskLevelMethod")]
    public IpaffsJourneyRiskCategorisationResultRiskLevelMethodEnum? RiskLevelMethod { get; set; }

	
    /// <summary>
    /// The date and time the risk level has been set for a notification
    /// </summary
    [JsonPropertyName("riskLevelDateTime")]
    public DateTime? RiskLevelDateTime { get; set; }

	}

