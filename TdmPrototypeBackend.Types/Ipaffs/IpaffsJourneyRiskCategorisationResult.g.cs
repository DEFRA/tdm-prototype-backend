//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable

using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using System.Dynamic;


namespace TdmPrototypeBackend.Types.Ipaffs;

    /// <summary>
    /// Details of the risk categorisation level for a notification
    /// </summary>
public partial class IpaffsJourneyRiskCategorisationResult  //
{


		/// <summary>
        /// Risk Level is defined using enum values High,Medium,Low
        /// </summary>
        [Attr]
        [JsonPropertyName("riskLevel")]
		public  IpaffsJourneyRiskCategorisationResultRiskLevelEnum? RiskLevel { get; set; }
    
		/// <summary>
        /// Indicator of whether the risk level was determined by the system or by the user
        /// </summary>
        [Attr]
        [JsonPropertyName("riskLevelMethod")]
		public  IpaffsJourneyRiskCategorisationResultRiskLevelMethodEnum? RiskLevelMethod { get; set; }
    
		/// <summary>
        /// The date and time the risk level has been set for a notification
        /// </summary>
        [Attr]
        [JsonPropertyName("riskLevelDateTime")]
		public  string? RiskLevelDateTime { get; set; }
    
}


