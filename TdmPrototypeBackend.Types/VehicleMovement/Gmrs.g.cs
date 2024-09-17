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

namespace TdmPrototypeBackend.Types.VehicleMovement;

    /// <summary>
    /// 
    /// </summary>
public partial class Gmrs  {


        /// <summary>
        /// The Goods Movement Record (GMR) ID for this GMR.  Do not include when POSTing a GMR - GVMS will assign an ID.
        /// </summary>
        [Attr]
        [JsonPropertyName("gmrId")]
        public string? GmrId { get; set; }
    
        /// <summary>
        /// The EORI of the haulier that is responsible for the vehicle making the goods movement
        /// </summary>
        [Attr]
        [JsonPropertyName("haulierEORI")]
        public string? HaulierEORI { get; set; }
    
        /// <summary>
        /// The state of the GMR
        /// </summary>
        [Attr]
        [JsonPropertyName("state")]
        public StateEnum? State { get; set; }
    
        /// <summary>
        /// If set to true, indicates that the vehicle requires a customs inspection.  If set to false, indicates that the vehicle does not require a customs inspection.  If not set, indicates the customs inspection decision has not yet been made or is not applicable.  For outbound GMRs, this indicates that the vehicle must present at an inspection facility prior to checking-in at the port.  For Office of Transit inspections for inbound GMRs, a decision may be made to inspect subsequent to a notification that inspection is not required.  In this event a notification will be sent that changes inspectionRequired from false to true.  If this happens after leaving the port of arrival, the inspection should be carried out at the next transit office e.g. the office of destination.
        /// </summary>
        [Attr]
        [JsonPropertyName("inspectionRequired")]
        public bool? InspectionRequired { get; set; }
    
        /// <summary>
        /// A list of one or more inspection types, from GVMS Reference Data, that the vehicle must have carried out, in the order specified.  This means that where there are multiple entries here, the vehicle must report for the first inspection type listed before each subsequent listed inspection.  Each entry includes a list of available locations for the inspection type.
        /// </summary>
        [Attr]
        [JsonPropertyName("reportToLocations")]
        public ReportToLocations[]? ReportToLocations { get; set; }
    
        /// <summary>
        /// The date and time that this GMR was last updated.
        /// </summary>
        [Attr]
        [JsonPropertyName("updatedDateTime")]
        public string? UpdatedDateTime { get; set; }
    
        /// <summary>
        /// The direction of the movement - into or out of the UK, or between Great Britain and Northern Ireland
        /// </summary>
        [Attr]
        [JsonPropertyName("direction")]
        public DirectionEnum? Direction { get; set; }
    
        /// <summary>
        /// The type of haulier moving the goods
        /// </summary>
        [Attr]
        [JsonPropertyName("haulierType")]
        public HaulierTypeEnum? HaulierType { get; set; }
    
        /// <summary>
        /// Set to true if the vehicle will not be accompanying the trailer(s) during the crossing, or if the vehicle is carrying a container that will be detached and loaded for the crossing.
        /// </summary>
        [Attr]
        [JsonPropertyName("isUnaccompanied")]
        public bool? IsUnaccompanied { get; set; }
    
        /// <summary>
        /// Vehicle registration number of the vehicle that will arrive at port.  If isUnaccompanied is set to false then vehicleRegNum must be provided to check-in.
        /// </summary>
        [Attr]
        [JsonPropertyName("vehicleRegNum")]
        public string? VehicleRegNum { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("plannedCrossing")]
        public PlannedCrossing? PlannedCrossing { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("checkedInCrossing")]
        public CheckedInCrossing? CheckedInCrossing { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("actualCrossing")]
        public ActualCrossing? ActualCrossing { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("declarations")]
        public Declarations? Declarations { get; set; }
    
}

