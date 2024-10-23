//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable

using System.Text.Json.Serialization;
using System.Dynamic;


namespace Tdm.Types.Ipaffs;

/// <summary>
/// Control part of notification
/// </summary>
public partial class IpaffsPartThree  //
{


    /// <summary>
    /// Control status enum
    /// </summary
    [JsonPropertyName("controlStatus")]
    public IpaffsPartThreeControlStatusEnum? ControlStatus { get; set; }

	
    /// <summary>
    /// Control details
    /// </summary
    [JsonPropertyName("control")]
    public IpaffsControl? Control { get; set; }

	
    /// <summary>
    /// Validation messages for Part 3 - Control
    /// </summary
    [JsonPropertyName("consignmentValidation")]
    public IpaffsValidationMessageCode[]? ConsignmentValidations { get; set; }

	
    /// <summary>
    /// Is the seal check required
    /// </summary
    [JsonPropertyName("sealCheckRequired")]
    public bool? SealCheckRequired { get; set; }

	
    /// <summary>
    /// Seal check details
    /// </summary
    [JsonPropertyName("sealCheck")]
    public IpaffsSealCheck? SealCheck { get; set; }

	
    /// <summary>
    /// Seal check override details
    /// </summary
    [JsonPropertyName("sealCheckOverride")]
    public IpaffsInspectionOverride? SealCheckOverride { get; set; }

	}

