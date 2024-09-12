
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Laboratory tests details
    /// </summary>
public partial class LaboratoryTestsDto  {


        /// <summary>
        /// Date of tests
        /// </summary>
        [Attr]
        [JsonProperty("testDate", NullValueHandling = NullValueHandling.Ignore)]
        public string TestDate { get; set; }
    
        /// <summary>
        /// Reason for test
        /// </summary>
        [Attr]
        [JsonProperty("testReason", NullValueHandling = NullValueHandling.Ignore)]
        public string TestReason { get; set; }
    
        /// <summary>
        /// List of details of individual tests performed or to be performed
        /// </summary>
        [Attr]
        [JsonProperty("singleLaboratoryTests", NullValueHandling = NullValueHandling.Ignore)]
        public SingleLaboratoryTestDto[] SingleLaboratoryTests { get; set; }
    
}


