
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Tests results corresponding to LaboratoryTests
    /// </summary>
public partial class LaboratoryTestResultDto  {


        /// <summary>
        /// When sample was used
        /// </summary>
        [Attr]
        [JsonProperty("sampleUseByDate", NullValueHandling = NullValueHandling.Ignore)]
        public string SampleUseByDate { get; set; }
    
        /// <summary>
        /// When it was released
        /// </summary>
        [Attr]
        [JsonProperty("releasedDate", NullValueHandling = NullValueHandling.Ignore)]
        public string ReleasedDate { get; set; }
    
        /// <summary>
        /// Laboratory test method
        /// </summary>
        [Attr]
        [JsonProperty("laboratoryTestMethod", NullValueHandling = NullValueHandling.Ignore)]
        public string LaboratoryTestMethod { get; set; }
    
        /// <summary>
        /// Result of test
        /// </summary>
        [Attr]
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public string Results { get; set; }
    
        /// <summary>
        /// Conclusion of laboratory test
        /// </summary>
        [Attr]
        [JsonProperty("conclusion", NullValueHandling = NullValueHandling.Ignore)]
        public string Conclusion { get; set; }
    
        /// <summary>
        /// Date of lab test created in IPAFFS
        /// </summary>
        [Attr]
        [JsonProperty("labTestCreatedDate", NullValueHandling = NullValueHandling.Ignore)]
        public string LabTestCreatedDate { get; set; }
    
}


