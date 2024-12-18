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
public partial class CheckedInCrossing  //
{


    /// <summary>
    /// The ID of the crossing route, using a routeId from the GVMS reference data
    /// </summary
    [Attr]
    [JsonPropertyName("routeId")]
    public string? RouteId { get; set; }

	
    /// <summary>
    /// The planned date and time of arrival, in local time of the arrival port. Must not include seconds, time zone or UTC marker
    /// </summary
    [Attr]
    [JsonPropertyName("localDateTimeOfArrival")]
    public DateTime? ArrivesAt { get; set; }

	}


