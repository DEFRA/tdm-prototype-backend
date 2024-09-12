
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Information about single laboratory test
    /// </summary>
public partial class SingleLaboratoryTestDto  {


        /// <summary>
        /// Commodity code for which lab test was ordered
        /// </summary>
        [Attr]
        [JsonProperty("commodityCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CommodityCode { get; set; }
    
        /// <summary>
        /// Species id of commodity for which lab test was ordered
        /// </summary>
        [Attr]
        [JsonProperty("speciesID", NullValueHandling = NullValueHandling.Ignore)]
        public int SpeciesID { get; set; }
    
        /// <summary>
        /// TRACES ID
        /// </summary>
        [Attr]
        [JsonProperty("tracesID", NullValueHandling = NullValueHandling.Ignore)]
        public int TracesID { get; set; }
    
        /// <summary>
        /// Test name
        /// </summary>
        [Attr]
        [JsonProperty("testName", NullValueHandling = NullValueHandling.Ignore)]
        public string TestName { get; set; }
    
        /// <summary>
        /// Laboratory tests information details and information about laboratory
        /// </summary>
        [Attr]
        [JsonProperty("applicant", NullValueHandling = NullValueHandling.Ignore)]
        public ApplicantDto Applicant { get; set; }
    
        /// <summary>
        /// Information about results of test
        /// </summary>
        [Attr]
        [JsonProperty("laboratoryTestResult", NullValueHandling = NullValueHandling.Ignore)]
        public LaboratoryTestResultDto LaboratoryTestResult { get; set; }
    
}


