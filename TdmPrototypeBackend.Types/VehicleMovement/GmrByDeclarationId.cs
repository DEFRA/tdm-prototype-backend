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


namespace TdmPrototypeBackend.Types.VehicleMovement;

/// <summary>
/// 
/// </summary>
public partial class GmrByDeclarationId  //
{
    /// <summary>
    /// This is the identifier for a customs declaration from Customs Declaration Service (CDS) or CHIEF.&#xA;For inbound movements declared in CDS it is a MRN, for example 19GB4S24GC3PPFGVR7.&#xA;For inbound movements declared in CHIEF it is an ERN, for example 999123456C20210615.&#xA;For outbound movements declared in either CDS or CHIEF it is a DUCR, for example 0GB689223596000-SE119404.
    /// </summary
    [Attr]
    [JsonPropertyName("gmrs")]
    public List<string> Gmrs { get; set; }

}

