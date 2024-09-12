
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// 
    /// </summary>
public partial class ComplementParameterSetDto  {


        /// <summary>
        /// UUID used to match commodityComplement to its complementParameter set. CHEDPP only
        /// </summary>
        [Attr]
        [JsonPropertyName("uniqueComplementID")]
        public string UniqueComplementID { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("complementID")]
        public int ComplementID { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesID")]
        public string SpeciesID { get; set; }
    
        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("keyDataPair")]
        public KeyDataPairDto[] KeyDataPair { get; set; }
    
        /// <summary>
        /// Catch certificate details
        /// </summary>
        [Attr]
        [JsonPropertyName("catchCertificates")]
        public CatchCertificatesDto[] CatchCertificates { get; set; }
    
        /// <summary>
        /// Data used to identify the complements inside an IMP consignment
        /// </summary>
        [Attr]
        [JsonPropertyName("identifiers")]
        public IdentifiersDto[] Identifiers { get; set; }
    
}


