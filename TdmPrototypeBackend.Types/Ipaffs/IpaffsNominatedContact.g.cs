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
    /// Person to be nominated for text and email contact for the consignment
    /// </summary>
public partial class IpaffsNominatedContact  //
{


		/// <summary>
        /// Name of nominated contact
        /// </summary>
        [Attr]
        [JsonPropertyName("name")]
		public  string? Name { get; set; }
    
		/// <summary>
        /// Email address of nominated contact
        /// </summary>
        [Attr]
        [JsonPropertyName("email")]
		public  string? Email { get; set; }
    
		/// <summary>
        /// Telephone number of nominated contact
        /// </summary>
        [Attr]
        [JsonPropertyName("telephone")]
		public  string? Telephone { get; set; }
    
}


