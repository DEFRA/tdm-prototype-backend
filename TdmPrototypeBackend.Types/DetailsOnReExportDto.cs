
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Details on re-export
    /// </summary>
public partial class DetailsOnReExportDto  {


        /// <summary>
        /// Date of re-export
        /// </summary>
        [Attr]
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public string Date { get; set; }
    
        /// <summary>
        /// Number of vehicle
        /// </summary>
        [Attr]
        [JsonProperty("meansOfTransportNo", NullValueHandling = NullValueHandling.Ignore)]
        public string MeansOfTransportNo { get; set; }
    
        /// <summary>
        /// Type of transport to be used
        /// </summary>
        [Attr]
        [JsonProperty("transportType", NullValueHandling = NullValueHandling.Ignore)]
        public string TransportType { get; set; }
    
        /// <summary>
        /// Document issued for re-export
        /// </summary>
        [Attr]
        [JsonProperty("document", NullValueHandling = NullValueHandling.Ignore)]
        public string Document { get; set; }
    
        /// <summary>
        /// Two letter ISO code for country of re-dispatching
        /// </summary>
        [Attr]
        [JsonProperty("countryOfReDispatching", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryOfReDispatching { get; set; }
    
        /// <summary>
        /// Exit BIP (where consignment will leave the country)
        /// </summary>
        [Attr]
        [JsonProperty("exitBIP", NullValueHandling = NullValueHandling.Ignore)]
        public string ExitBIP { get; set; }
    
}


