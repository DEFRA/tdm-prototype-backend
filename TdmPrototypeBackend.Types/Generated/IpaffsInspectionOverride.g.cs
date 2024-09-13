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
    /// Details about the manual inspection override
    /// </summary>
public partial class IpaffsInspectionOverride  {


        /// <summary>
        /// Original inspection decision
        /// </summary>
        [Attr]
        [JsonPropertyName("originalDecision")]
        public string OriginalDecision { get; set; }
    
        /// <summary>
        /// The time the risk decision is overridden
        /// </summary>
        [Attr]
        [JsonPropertyName("overriddenOn")]
        public string OverriddenOn { get; set; }
    
        /// <summary>
        /// User entity who has manually overridden the inspection
        /// </summary>
        [Attr]
        [JsonPropertyName("overriddenBy")]
        public IpaffsUserInformation OverriddenBy { get; set; }
    
}

