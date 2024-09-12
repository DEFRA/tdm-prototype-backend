
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Details on re-export
    /// </summary>
public partial class DetailsOnReExportDto  {


        /// <summary>
        /// Date of re-export
        /// </summary>
        [Attr]
        [JsonPropertyName("date")]
        public string Date { get; set; }
    
        /// <summary>
        /// Number of vehicle
        /// </summary>
        [Attr]
        [JsonPropertyName("meansOfTransportNo")]
        public string MeansOfTransportNo { get; set; }
    
        /// <summary>
        /// Type of transport to be used
        /// </summary>
        [Attr]
        [JsonPropertyName("transportType")]
        public string TransportType { get; set; }
    
        /// <summary>
        /// Document issued for re-export
        /// </summary>
        [Attr]
        [JsonPropertyName("document")]
        public string Document { get; set; }
    
        /// <summary>
        /// Two letter ISO code for country of re-dispatching
        /// </summary>
        [Attr]
        [JsonPropertyName("countryOfReDispatching")]
        public string CountryOfReDispatching { get; set; }
    
        /// <summary>
        /// Exit BIP (where consignment will leave the country)
        /// </summary>
        [Attr]
        [JsonPropertyName("exitBIP")]
        public string ExitBIP { get; set; }
    
}


