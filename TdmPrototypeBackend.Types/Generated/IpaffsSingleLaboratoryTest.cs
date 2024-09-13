
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Information about single laboratory test
    /// </summary>
public partial class IpaffsSingleLaboratoryTest  {


        /// <summary>
        /// Commodity code for which lab test was ordered
        /// </summary>
        [Attr]
        [JsonPropertyName("commodityCode")]
        public string CommodityCode { get; set; }
    
        /// <summary>
        /// Species id of commodity for which lab test was ordered
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesID")]
        public int SpeciesID { get; set; }
    
        /// <summary>
        /// TRACES ID
        /// </summary>
        [Attr]
        [JsonPropertyName("tracesID")]
        public int TracesID { get; set; }
    
        /// <summary>
        /// Test name
        /// </summary>
        [Attr]
        [JsonPropertyName("testName")]
        public string TestName { get; set; }
    
        /// <summary>
        /// Laboratory tests information details and information about laboratory
        /// </summary>
        [Attr]
        [JsonPropertyName("applicant")]
        public IpaffsApplicant Applicant { get; set; }
    
        /// <summary>
        /// Information about results of test
        /// </summary>
        [Attr]
        [JsonPropertyName("laboratoryTestResult")]
        public IpaffsLaboratoryTestResult LaboratoryTestResult { get; set; }
    
}


