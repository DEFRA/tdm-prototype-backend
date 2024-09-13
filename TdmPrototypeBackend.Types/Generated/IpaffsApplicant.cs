
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Laboratory tests information details and information about laboratory that did the test
    /// </summary>
public partial class IpaffsApplicant  {


        /// <summary>
        /// Name of laboratory
        /// </summary>
        [Attr]
        [JsonPropertyName("laboratory")]
        public string Laboratory { get; set; }
    
        /// <summary>
        /// Laboratory address
        /// </summary>
        [Attr]
        [JsonPropertyName("laboratoryAddress")]
        public string LaboratoryAddress { get; set; }
    
        /// <summary>
        /// Laboratory identification
        /// </summary>
        [Attr]
        [JsonPropertyName("laboratoryIdentification")]
        public string LaboratoryIdentification { get; set; }
    
        /// <summary>
        /// Laboratory phone number
        /// </summary>
        [Attr]
        [JsonPropertyName("laboratoryPhoneNumber")]
        public string LaboratoryPhoneNumber { get; set; }
    
        /// <summary>
        /// Laboratory email
        /// </summary>
        [Attr]
        [JsonPropertyName("laboratoryEmail")]
        public string LaboratoryEmail { get; set; }
    
        /// <summary>
        /// Sample batch number
        /// </summary>
        [Attr]
        [JsonPropertyName("sampleBatchNumber")]
        public string SampleBatchNumber { get; set; }
    
        /// <summary>
        /// Type of analysis
        /// </summary>
        [Attr]
        [JsonPropertyName("analysisType")]
        public IpaffsAnalysisTypeEnum AnalysisType { get; set; }
    
        /// <summary>
        /// Number of samples analysed
        /// </summary>
        [Attr]
        [JsonPropertyName("numberOfSamples")]
        public int NumberOfSamples { get; set; }
    
        /// <summary>
        /// Type of sample
        /// </summary>
        [Attr]
        [JsonPropertyName("sampleType")]
        public string SampleType { get; set; }
    
        /// <summary>
        /// Conservation of sample
        /// </summary>
        [Attr]
        [JsonPropertyName("conservationOfSample")]
        public IpaffsConservationOfSampleEnum ConservationOfSample { get; set; }
    
        /// <summary>
        /// inspector
        /// </summary>
        [Attr]
        [JsonPropertyName("inspector")]
        public IpaffsInspector Inspector { get; set; }
    
        /// <summary>
        /// Date the sample is taken
        /// </summary>
        [Attr]
        [JsonPropertyName("sampleDate")]
        public string SampleDate { get; set; }
    
        /// <summary>
        /// Time the sample is taken
        /// </summary>
        [Attr]
        [JsonPropertyName("sampleTime")]
        public string SampleTime { get; set; }
    
}


