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


namespace TdmPrototypeBackend.Types.Alvs;

    /// <summary>
    /// 
    /// </summary>
public partial class ALVSClearanceRequest  //
{


		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("ServiceHeader")]
		public  ServiceHeader? ServiceHeader { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("Header")]
		public  Header? Header { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("Items")]
		public  Items[]? Items { get; set; }
    
}


