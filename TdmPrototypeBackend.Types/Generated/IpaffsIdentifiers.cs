
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// 
    /// </summary>
public partial class IpaffsIdentifiers  {


        /// <summary>
        /// Number used to identify which item the identifiers are related to
        /// </summary>
        [Attr]
        [JsonPropertyName("speciesNumber")]
        public int SpeciesNumber { get; set; }
    
        /// <summary>
        /// List of identifiers and their keys
        /// </summary>
        [Attr]
        [JsonPropertyName("data")]
        public object Data { get; set; }
    
        /// <summary>
        /// Is the place of destination the permanent address?
        /// </summary>
        [Attr]
        [JsonPropertyName("isPlaceOfDestinationThePermanentAddress")]
        public bool IsPlaceOfDestinationThePermanentAddress { get; set; }
    
        /// <summary>
        /// Permanent address of the species
        /// </summary>
        [Attr]
        [JsonPropertyName("permanentAddress")]
        public IpaffsEconomicOperator PermanentAddress { get; set; }
    
}


