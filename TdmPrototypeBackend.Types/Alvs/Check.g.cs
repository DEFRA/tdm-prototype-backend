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
public partial class Check  //
{


		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("CheckCode")]
		public  string? CheckCode { get; set; }
    
		/// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("DepartmentCode")]
		public  string? DepartmentCode { get; set; }
    
}


