
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Details of Control (Part 3)
    /// </summary>
public partial class ControlDto  {


        /// <summary>
        /// Feedback information of Control
        /// </summary>
        [Attr]
        [JsonPropertyName("feedbackInformation")]
        public FeedbackInformationDto FeedbackInformation { get; set; }
    
        /// <summary>
        /// Details on re-export
        /// </summary>
        [Attr]
        [JsonPropertyName("detailsOnReExport")]
        public DetailsOnReExportDto DetailsOnReExport { get; set; }
    
        /// <summary>
        /// Official inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("officialInspector")]
        public OfficialInspectorDto OfficialInspector { get; set; }
    
        /// <summary>
        /// Is the consignment leaving UK borders?
        /// </summary>
        [Attr]
        [JsonPropertyName("consignmentLeave")]
        public string ConsignmentLeave { get; set; }
    
}


