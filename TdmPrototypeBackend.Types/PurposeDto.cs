
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Purpose of consignment details
    /// </summary>
public partial class PurposeDto  {


        /// <summary>
        /// Does consignment conforms to UK laws
        /// </summary>
        [Attr]
        [JsonPropertyName("conformsToEU")]
        public bool ConformsToEU { get; set; }
    
        /// <summary>
        /// Detailed purpose of internal market purpose group
        /// </summary>
        [Attr]
        [JsonPropertyName("internalMarketPurpose")]
        public string InternalMarketPurpose { get; set; }
    
        /// <summary>
        /// Country that consignment is transshipped through
        /// </summary>
        [Attr]
        [JsonPropertyName("thirdCountryTranshipment")]
        public string ThirdCountryTranshipment { get; set; }
    
        /// <summary>
        /// Detailed purpose for non conforming purpose group
        /// </summary>
        [Attr]
        [JsonPropertyName("forNonConforming")]
        public string ForNonConforming { get; set; }
    
        /// <summary>
        /// There are 3 types of registration number based on the purpose of consignment. Customs registration number, Free zone registration number and Shipping supplier registration number.&#xA;
        /// </summary>
        [Attr]
        [JsonPropertyName("regNumber")]
        public string RegNumber { get; set; }
    
        /// <summary>
        /// Ship name
        /// </summary>
        [Attr]
        [JsonPropertyName("shipName")]
        public string ShipName { get; set; }
    
        /// <summary>
        /// Destination Ship port
        /// </summary>
        [Attr]
        [JsonPropertyName("shipPort")]
        public string ShipPort { get; set; }
    
        /// <summary>
        /// Exit Border Inspection Post
        /// </summary>
        [Attr]
        [JsonPropertyName("exitBIP")]
        public string ExitBIP { get; set; }
    
        /// <summary>
        /// Country to which consignment is transited
        /// </summary>
        [Attr]
        [JsonPropertyName("thirdCountry")]
        public string ThirdCountry { get; set; }
    
        /// <summary>
        /// Countries that consignment is transited through
        /// </summary>
        [Attr]
        [JsonPropertyName("transitThirdCountries")]
        public string[][] TransitThirdCountries { get; set; }
    
        /// <summary>
        /// Specification of Import or admission purpose
        /// </summary>
        [Attr]
        [JsonPropertyName("forImportOrAdmission")]
        public string ForImportOrAdmission { get; set; }
    
        /// <summary>
        /// Exit date when import or admission
        /// </summary>
        [Attr]
        [JsonPropertyName("exitDate")]
        public string ExitDate { get; set; }
    
        /// <summary>
        /// Final Border Inspection Post
        /// </summary>
        [Attr]
        [JsonPropertyName("finalBIP")]
        public string FinalBIP { get; set; }
    
        /// <summary>
        /// Purpose group of consignment (general purpose)
        /// </summary>
        [Attr]
        [JsonPropertyName("purposeGroup")]
        public string PurposeGroup { get; set; }
    
        /// <summary>
        /// Estimated date at port of exit
        /// </summary>
        [Attr]
        [JsonPropertyName("estimatedArrivalDateAtPortOfExit")]
        public string EstimatedArrivalDateAtPortOfExit { get; set; }
    
        /// <summary>
        /// Estimated time at port of exit
        /// </summary>
        [Attr]
        [JsonPropertyName("estimatedArrivalTimeAtPortOfExit")]
        public string EstimatedArrivalTimeAtPortOfExit { get; set; }
    
}


