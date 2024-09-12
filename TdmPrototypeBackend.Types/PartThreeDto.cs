
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Control part of notification
    /// </summary>
public partial class PartThreeDto  {


        /// <summary>
        /// Control status enum
        /// </summary>
        [Attr]
        [JsonProperty("controlStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string ControlStatus { get; set; }
    
        /// <summary>
        /// Control details
        /// </summary>
        [Attr]
        [JsonProperty("control", NullValueHandling = NullValueHandling.Ignore)]
        public ControlDto Control { get; set; }
    
        /// <summary>
        /// Validation messages for Part 3 - Control
        /// </summary>
        [Attr]
        [JsonProperty("consignmentValidation", NullValueHandling = NullValueHandling.Ignore)]
        public ValidationMessageCodeDto[] ConsignmentValidation { get; set; }
    
        /// <summary>
        /// Is the seal check required
        /// </summary>
        [Attr]
        [JsonProperty("sealCheckRequired", NullValueHandling = NullValueHandling.Ignore)]
        public bool SealCheckRequired { get; set; }
    
        /// <summary>
        /// Seal check details
        /// </summary>
        [Attr]
        [JsonProperty("sealCheck", NullValueHandling = NullValueHandling.Ignore)]
        public SealCheckDto SealCheck { get; set; }
    
        /// <summary>
        /// Seal check override details
        /// </summary>
        [Attr]
        [JsonProperty("sealCheckOverride", NullValueHandling = NullValueHandling.Ignore)]
        public InspectionOverrideDto SealCheckOverride { get; set; }
    
}


