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
    /// 
    /// </summary>
public partial class IpaffsCommonUserCharge  //
{


		/// <summary>
        /// Indicates whether the last applicable change was successfully send over the interface to Trade Charge
        /// </summary>
        [Attr]
        [JsonPropertyName("wasSentToTradeCharge")]
		public  bool? WasSentToTradeCharge { get; set; }
    
}

