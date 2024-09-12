
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Catch certificate details for uploaded attachment
    /// </summary>
public partial class CatchCertificateDetailsDto  {


        /// <summary>
        /// The UUID of the catch certificate
        /// </summary>
        [Attr]
        [JsonProperty("catchCertificateId", NullValueHandling = NullValueHandling.Ignore)]
        public string CatchCertificateId { get; set; }
    
        /// <summary>
        /// Catch certificate reference
        /// </summary>
        [Attr]
        [JsonProperty("catchCertificateReference", NullValueHandling = NullValueHandling.Ignore)]
        public string CatchCertificateReference { get; set; }
    
        /// <summary>
        /// Catch certificate date of issue
        /// </summary>
        [Attr]
        [JsonProperty("dateOfIssue", NullValueHandling = NullValueHandling.Ignore)]
        public string DateOfIssue { get; set; }
    
        /// <summary>
        /// Catch certificate flag state of catching vessel(s)
        /// </summary>
        [Attr]
        [JsonProperty("flagState", NullValueHandling = NullValueHandling.Ignore)]
        public string FlagState { get; set; }
    
        /// <summary>
        /// List of species imported under this catch certificate
        /// </summary>
        [Attr]
        [JsonProperty("species", NullValueHandling = NullValueHandling.Ignore)]
        public string[][] Species { get; set; }
    
}


