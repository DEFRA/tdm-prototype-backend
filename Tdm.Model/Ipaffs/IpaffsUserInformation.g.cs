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


namespace Tdm.Model.Ipaffs;

/// <summary>
/// Information about logged-in user
/// </summary>
public partial class IpaffsUserInformation  //
{


    /// <summary>
    /// Display name
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Display name")]
    public string? DisplayName { get; set; }

	
    /// <summary>
    /// User ID
    /// </summary
    [Attr]
    [System.ComponentModel.Description("User ID")]
    public string? UserId { get; set; }

	
    /// <summary>
    /// Is this user a control
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Is this user a control")]
    public bool? IsControlUser { get; set; }

	}


