
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Laboratory tests details
    /// </summary>
public partial class LaboratoryTestsDto  {


        /// <summary>
        /// Date of tests
        /// </summary>
        [Attr]
        [JsonPropertyName("testDate")]
        public string TestDate { get; set; }
    
        /// <summary>
        /// Reason for test
        /// </summary>
        [Attr]
        [JsonPropertyName("testReason")]
        public string TestReason { get; set; }
    
        /// <summary>
        /// List of details of individual tests performed or to be performed
        /// </summary>
        [Attr]
        [JsonPropertyName("singleLaboratoryTests")]
        public SingleLaboratoryTestDto[] SingleLaboratoryTests { get; set; }
    
}


