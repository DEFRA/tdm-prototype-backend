
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Contains countries and transfer points that consignment is going through
    /// </summary>
public partial class RouteDto  {


        /// <summary>
        /// 
        /// </summary>
        [Attr]
        [JsonPropertyName("transitingStates")]
        public string[][] TransitingStates { get; set; }
    
}


