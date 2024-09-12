
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Impact of transport on animals
    /// </summary>
public partial class ImpactOfTransportOnAnimalsDto  {


        /// <summary>
        /// Number of dead animals specified by units
        /// </summary>
        [Attr]
        [JsonProperty("numberOfDeadAnimals", NullValueHandling = NullValueHandling.Ignore)]
        public int NumberOfDeadAnimals { get; set; }
    
        /// <summary>
        /// Unit used for specifying number of dead animals (percent or units)
        /// </summary>
        [Attr]
        [JsonProperty("numberOfDeadAnimalsUnit", NullValueHandling = NullValueHandling.Ignore)]
        public string NumberOfDeadAnimalsUnit { get; set; }
    
        /// <summary>
        /// Number of unfit animals
        /// </summary>
        [Attr]
        [JsonProperty("numberOfUnfitAnimals", NullValueHandling = NullValueHandling.Ignore)]
        public int NumberOfUnfitAnimals { get; set; }
    
        /// <summary>
        /// Unit used for specifying number of unfit animals (percent or units)
        /// </summary>
        [Attr]
        [JsonProperty("numberOfUnfitAnimalsUnit", NullValueHandling = NullValueHandling.Ignore)]
        public string NumberOfUnfitAnimalsUnit { get; set; }
    
        /// <summary>
        /// Number of births or abortions (unit)
        /// </summary>
        [Attr]
        [JsonProperty("numberOfBirthOrAbortion", NullValueHandling = NullValueHandling.Ignore)]
        public int NumberOfBirthOrAbortion { get; set; }
    
}


