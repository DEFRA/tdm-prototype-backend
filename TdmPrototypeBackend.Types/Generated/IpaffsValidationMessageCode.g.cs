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
    /// Validation field code-message representation
    /// </summary>
public partial class IpaffsValidationMessageCode  {


        /// <summary>
        /// Field
        /// </summary>
        [Attr]
        [JsonPropertyName("field")]
        public string Field { get; set; }
    
        /// <summary>
        /// Code
        /// </summary>
        [Attr]
        [JsonPropertyName("code")]
        public string Code { get; set; }
    
}

