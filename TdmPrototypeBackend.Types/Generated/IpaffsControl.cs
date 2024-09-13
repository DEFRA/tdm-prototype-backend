
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Details of Control (Part 3)
    /// </summary>
public partial class IpaffsControl  {


        /// <summary>
        /// Feedback information of Control
        /// </summary>
        [Attr]
        [JsonPropertyName("feedbackInformation")]
        public IpaffsFeedbackInformation FeedbackInformation { get; set; }
    
        /// <summary>
        /// Details on re-export
        /// </summary>
        [Attr]
        [JsonPropertyName("detailsOnReExport")]
        public IpaffsDetailsOnReExport DetailsOnReExport { get; set; }
    
        /// <summary>
        /// Official inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("officialInspector")]
        public IpaffsOfficialInspector OfficialInspector { get; set; }
    
        /// <summary>
        /// Is the consignment leaving UK borders?
        /// </summary>
        [Attr]
        [JsonPropertyName("consignmentLeave")]
        public IpaffsConsignmentLeaveEnum ConsignmentLeave { get; set; }
    
}


