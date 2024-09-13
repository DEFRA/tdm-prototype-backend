
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Control part of notification
    /// </summary>
public partial class IpaffsPartThree  {


        /// <summary>
        /// Control status enum
        /// </summary>
        [Attr]
        [JsonPropertyName("controlStatus")]
        public IpaffsControlStatusEnum ControlStatus { get; set; }
    
        /// <summary>
        /// Control details
        /// </summary>
        [Attr]
        [JsonPropertyName("control")]
        public IpaffsControl Control { get; set; }
    
        /// <summary>
        /// Validation messages for Part 3 - Control
        /// </summary>
        [Attr]
        [JsonPropertyName("consignmentValidation")]
        public IpaffsValidationMessageCode[] ConsignmentValidations { get; set; }
    
        /// <summary>
        /// Is the seal check required
        /// </summary>
        [Attr]
        [JsonPropertyName("sealCheckRequired")]
        public bool SealCheckRequired { get; set; }
    
        /// <summary>
        /// Seal check details
        /// </summary>
        [Attr]
        [JsonPropertyName("sealCheck")]
        public IpaffsSealCheck SealCheck { get; set; }
    
        /// <summary>
        /// Seal check override details
        /// </summary>
        [Attr]
        [JsonPropertyName("sealCheckOverride")]
        public IpaffsInspectionOverride SealCheckOverride { get; set; }
    
}

