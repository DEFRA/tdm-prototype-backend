
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Tests results corresponding to LaboratoryTests
    /// </summary>
public partial class LaboratoryTestResultDto  {


        /// <summary>
        /// When sample was used
        /// </summary>
        [Attr]
        [JsonPropertyName("sampleUseByDate")]
        public string SampleUseByDate { get; set; }
    
        /// <summary>
        /// When it was released
        /// </summary>
        [Attr]
        [JsonPropertyName("releasedDate")]
        public string ReleasedDate { get; set; }
    
        /// <summary>
        /// Laboratory test method
        /// </summary>
        [Attr]
        [JsonPropertyName("laboratoryTestMethod")]
        public string LaboratoryTestMethod { get; set; }
    
        /// <summary>
        /// Result of test
        /// </summary>
        [Attr]
        [JsonPropertyName("results")]
        public string Results { get; set; }
    
        /// <summary>
        /// Conclusion of laboratory test
        /// </summary>
        [Attr]
        [JsonPropertyName("conclusion")]
        public string Conclusion { get; set; }
    
        /// <summary>
        /// Date of lab test created in IPAFFS
        /// </summary>
        [Attr]
        [JsonPropertyName("labTestCreatedDate")]
        public string LabTestCreatedDate { get; set; }
    
}


