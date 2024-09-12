
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Present if the consignment has been split
    /// </summary>
public partial class SplitConsignmentDto  {


        /// <summary>
        /// Reference number of the valid split consignment
        /// </summary>
        [Attr]
        [JsonPropertyName("validReferenceNumber")]
        public string ValidReferenceNumber { get; set; }
    
        /// <summary>
        /// Reference number of the rejected split consignment
        /// </summary>
        [Attr]
        [JsonPropertyName("rejectedReferenceNumber")]
        public string RejectedReferenceNumber { get; set; }
    
}


