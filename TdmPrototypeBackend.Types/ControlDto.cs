
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Details of Control (Part 3)
    /// </summary>
public partial class ControlDto  {


        /// <summary>
        /// Feedback information of Control
        /// </summary>
        [Attr]
        [JsonProperty("feedbackInformation", NullValueHandling = NullValueHandling.Ignore)]
        public FeedbackInformationDto FeedbackInformation { get; set; }
    
        /// <summary>
        /// Details on re-export
        /// </summary>
        [Attr]
        [JsonProperty("detailsOnReExport", NullValueHandling = NullValueHandling.Ignore)]
        public DetailsOnReExportDto DetailsOnReExport { get; set; }
    
        /// <summary>
        /// Official inspector
        /// </summary>
        [Attr]
        [JsonProperty("officialInspector", NullValueHandling = NullValueHandling.Ignore)]
        public OfficialInspectorDto OfficialInspector { get; set; }
    
        /// <summary>
        /// Is the consignment leaving UK borders?
        /// </summary>
        [Attr]
        [JsonProperty("consignmentLeave", NullValueHandling = NullValueHandling.Ignore)]
        public string ConsignmentLeave { get; set; }
    
}


