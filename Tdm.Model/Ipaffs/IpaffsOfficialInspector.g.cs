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
/// Official inspector details
/// </summary>
public partial class IpaffsOfficialInspector  //
{


    /// <summary>
    /// First name of inspector
    /// </summary
    [Attr]
    [System.ComponentModel.Description("First name of inspector")]
    public string? FirstName { get; set; }

	
    /// <summary>
    /// Last name of inspector
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Last name of inspector")]
    public string? LastName { get; set; }

	
    /// <summary>
    /// Email of inspector
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Email of inspector")]
    public string? Email { get; set; }

	
    /// <summary>
    /// Phone number of inspector
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Phone number of inspector")]
    public string? Phone { get; set; }

	
    /// <summary>
    /// Fax number of inspector
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Fax number of inspector")]
    public string? Fax { get; set; }

	
    /// <summary>
    /// Address of inspector
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Address of inspector")]
    public IpaffsAddress? Address { get; set; }

	
    /// <summary>
    /// Date of sign
    /// </summary
    [Attr]
    [System.ComponentModel.Description("Date of sign")]
    public string? Signed { get; set; }

	}


