
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Authority which performed control
    /// </summary>
public partial class ControlAuthorityDto  {


        /// <summary>
        /// Official veterinarian
        /// </summary>
        [Attr]
        [JsonProperty("officialVeterinarian", NullValueHandling = NullValueHandling.Ignore)]
        public OfficialVeterinarianDto OfficialVeterinarian { get; set; }
    
        /// <summary>
        /// Customs reference number
        /// </summary>
        [Attr]
        [JsonProperty("customsReferenceNo", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomsReferenceNo { get; set; }
    
        /// <summary>
        /// Were containers resealed?
        /// </summary>
        [Attr]
        [JsonProperty("containerResealed", NullValueHandling = NullValueHandling.Ignore)]
        public bool ContainerResealed { get; set; }
    
        /// <summary>
        /// When the containers are resealed they need new seal numbers
        /// </summary>
        [Attr]
        [JsonProperty("newSealNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string NewSealNumber { get; set; }
    
        /// <summary>
        /// Illegal, Unreported and Unregulated (IUU) fishing reference number
        /// </summary>
        [Attr]
        [JsonProperty("iuuFishingReference", NullValueHandling = NullValueHandling.Ignore)]
        public string IuuFishingReference { get; set; }
    
        /// <summary>
        /// Was Illegal, Unreported and Unregulated (IUU) check required
        /// </summary>
        [Attr]
        [JsonProperty("iuuCheckRequired", NullValueHandling = NullValueHandling.Ignore)]
        public bool IuuCheckRequired { get; set; }
    
        /// <summary>
        /// Result of Illegal, Unreported and Unregulated (IUU) check
        /// </summary>
        [Attr]
        [JsonProperty("iuuOption", NullValueHandling = NullValueHandling.Ignore)]
        public string IuuOption { get; set; }
    
}


