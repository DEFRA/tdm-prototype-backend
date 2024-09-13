//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;

namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// An organisation as part of the DEFRA system
    /// </summary>
public partial class IpaffsEconomicOperator  {


        /// <summary>
        /// The unique identifier of this organisation
        /// </summary>
        [Attr]
        [JsonPropertyName("id")]
        public string IpaffsId { get; set; }
    
        /// <summary>
        /// Type of organisation
        /// </summary>
        [Attr]
        [JsonPropertyName("type")]
        public IpaffsEconomicOperatorTypeEnum IpaffsType { get; set; }
    
        /// <summary>
        /// Status of organisation
        /// </summary>
        [Attr]
        [JsonPropertyName("status")]
        public IpaffsEconomicOperatorStatusEnum Status { get; set; }
    
        /// <summary>
        /// Name of organisation
        /// </summary>
        [Attr]
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }
    
        /// <summary>
        /// Individual name
        /// </summary>
        [Attr]
        [JsonPropertyName("individualName")]
        public string IndividualName { get; set; }
    
        /// <summary>
        /// Address of economic operator
        /// </summary>
        [Attr]
        [JsonPropertyName("address")]
        public IpaffsAddress Address { get; set; }
    
        /// <summary>
        /// Approval Number which identifies an Economic Operator unambiguously per type of organisation per country.
        /// </summary>
        [Attr]
        [JsonPropertyName("approvalNumber")]
        public string ApprovalNumber { get; set; }
    
        /// <summary>
        /// Optional Business General Number, often named Aggregation Code, which identifies an Economic Operator.
        /// </summary>
        [Attr]
        [JsonPropertyName("otherIdentifier")]
        public string OtherIdentifier { get; set; }
    
        /// <summary>
        /// Traces Id of the economic operator generated by IPAFFS
        /// </summary>
        [Attr]
        [JsonPropertyName("tracesId")]
        public int TracesId { get; set; }
    
}


