
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Authority which performed control
    /// </summary>
public partial class ControlAuthorityDto  {


        /// <summary>
        /// Official veterinarian
        /// </summary>
        [Attr]
        [JsonPropertyName("officialVeterinarian")]
        public OfficialVeterinarianDto OfficialVeterinarian { get; set; }
    
        /// <summary>
        /// Customs reference number
        /// </summary>
        [Attr]
        [JsonPropertyName("customsReferenceNo")]
        public string CustomsReferenceNo { get; set; }
    
        /// <summary>
        /// Were containers resealed?
        /// </summary>
        [Attr]
        [JsonPropertyName("containerResealed")]
        public bool ContainerResealed { get; set; }
    
        /// <summary>
        /// When the containers are resealed they need new seal numbers
        /// </summary>
        [Attr]
        [JsonPropertyName("newSealNumber")]
        public string NewSealNumber { get; set; }
    
        /// <summary>
        /// Illegal, Unreported and Unregulated (IUU) fishing reference number
        /// </summary>
        [Attr]
        [JsonPropertyName("iuuFishingReference")]
        public string IuuFishingReference { get; set; }
    
        /// <summary>
        /// Was Illegal, Unreported and Unregulated (IUU) check required
        /// </summary>
        [Attr]
        [JsonPropertyName("iuuCheckRequired")]
        public bool IuuCheckRequired { get; set; }
    
        /// <summary>
        /// Result of Illegal, Unreported and Unregulated (IUU) check
        /// </summary>
        [Attr]
        [JsonPropertyName("iuuOption")]
        public string IuuOption { get; set; }
    
}


