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


namespace Tdm.Model.Alvs;

/// <summary>
/// 
/// </summary>
public partial class AlvsClearanceRequest  //
{


    /// <summary>
    /// 
    /// </summary
    [Attr]
    [System.ComponentModel.Description("")]
    public ServiceHeader? ServiceHeader { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [System.ComponentModel.Description("")]
    public Header? Header { get; set; }

	
    /// <summary>
    /// 
    /// </summary
    [Attr]
    [System.ComponentModel.Description("")]
    public Items[]? Items { get; set; }

	}

