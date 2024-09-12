
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Impact of transport on animals
    /// </summary>
public partial class ImpactOfTransportOnAnimalsDto  {


        /// <summary>
        /// Number of dead animals specified by units
        /// </summary>
        [Attr]
        [JsonPropertyName("numberOfDeadAnimals")]
        public int NumberOfDeadAnimals { get; set; }
    
        /// <summary>
        /// Unit used for specifying number of dead animals (percent or units)
        /// </summary>
        [Attr]
        [JsonPropertyName("numberOfDeadAnimalsUnit")]
        public string NumberOfDeadAnimalsUnit { get; set; }
    
        /// <summary>
        /// Number of unfit animals
        /// </summary>
        [Attr]
        [JsonPropertyName("numberOfUnfitAnimals")]
        public int NumberOfUnfitAnimals { get; set; }
    
        /// <summary>
        /// Unit used for specifying number of unfit animals (percent or units)
        /// </summary>
        [Attr]
        [JsonPropertyName("numberOfUnfitAnimalsUnit")]
        public string NumberOfUnfitAnimalsUnit { get; set; }
    
        /// <summary>
        /// Number of births or abortions (unit)
        /// </summary>
        [Attr]
        [JsonPropertyName("numberOfBirthOrAbortion")]
        public int NumberOfBirthOrAbortion { get; set; }
    
}


