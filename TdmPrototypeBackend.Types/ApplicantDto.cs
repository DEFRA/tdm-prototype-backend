
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Laboratory tests information details and information about laboratory that did the test
    /// </summary>
public partial class ApplicantDto  {


        /// <summary>
        /// Name of laboratory
        /// </summary>
        [Attr]
        [JsonProperty("laboratory", NullValueHandling = NullValueHandling.Ignore)]
        public string Laboratory { get; set; }
    
        /// <summary>
        /// Laboratory address
        /// </summary>
        [Attr]
        [JsonProperty("laboratoryAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string LaboratoryAddress { get; set; }
    
        /// <summary>
        /// Laboratory identification
        /// </summary>
        [Attr]
        [JsonProperty("laboratoryIdentification", NullValueHandling = NullValueHandling.Ignore)]
        public string LaboratoryIdentification { get; set; }
    
        /// <summary>
        /// Laboratory phone number
        /// </summary>
        [Attr]
        [JsonProperty("laboratoryPhoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string LaboratoryPhoneNumber { get; set; }
    
        /// <summary>
        /// Laboratory email
        /// </summary>
        [Attr]
        [JsonProperty("laboratoryEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string LaboratoryEmail { get; set; }
    
        /// <summary>
        /// Sample batch number
        /// </summary>
        [Attr]
        [JsonProperty("sampleBatchNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string SampleBatchNumber { get; set; }
    
        /// <summary>
        /// Type of analysis
        /// </summary>
        [Attr]
        [JsonProperty("analysisType", NullValueHandling = NullValueHandling.Ignore)]
        public string AnalysisType { get; set; }
    
        /// <summary>
        /// Number of samples analysed
        /// </summary>
        [Attr]
        [JsonProperty("numberOfSamples", NullValueHandling = NullValueHandling.Ignore)]
        public int NumberOfSamples { get; set; }
    
        /// <summary>
        /// Type of sample
        /// </summary>
        [Attr]
        [JsonProperty("sampleType", NullValueHandling = NullValueHandling.Ignore)]
        public string SampleType { get; set; }
    
        /// <summary>
        /// Conservation of sample
        /// </summary>
        [Attr]
        [JsonProperty("conservationOfSample", NullValueHandling = NullValueHandling.Ignore)]
        public string ConservationOfSample { get; set; }
    
        /// <summary>
        /// inspector
        /// </summary>
        [Attr]
        [JsonProperty("inspector", NullValueHandling = NullValueHandling.Ignore)]
        public object Inspector { get; set; }
    
        /// <summary>
        /// Date the sample is taken
        /// </summary>
        [Attr]
        [JsonProperty("sampleDate", NullValueHandling = NullValueHandling.Ignore)]
        public string SampleDate { get; set; }
    
        /// <summary>
        /// Time the sample is taken
        /// </summary>
        [Attr]
        [JsonProperty("sampleTime", NullValueHandling = NullValueHandling.Ignore)]
        public string SampleTime { get; set; }
    
}


