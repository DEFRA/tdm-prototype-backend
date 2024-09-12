
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Party details
    /// </summary>
public partial class PartyDto  {


        /// <summary>
        /// IPAFFS ID of party
        /// </summary>
        [Attr]
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        /// <summary>
        /// Name of party
        /// </summary>
        [Attr]
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        /// <summary>
        /// Company ID
        /// </summary>
        [Attr]
        [JsonProperty("companyId", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyId { get; set; }
    
        /// <summary>
        /// Contact ID (B2C)
        /// </summary>
        [Attr]
        [JsonProperty("contactId", NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
    
        /// <summary>
        /// Company name
        /// </summary>
        [Attr]
        [JsonProperty("companyName", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }
    
        /// <summary>
        /// Addresses
        /// </summary>
        [Attr]
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string[][] Address { get; set; }
    
        /// <summary>
        /// County
        /// </summary>
        [Attr]
        [JsonProperty("county", NullValueHandling = NullValueHandling.Ignore)]
        public string County { get; set; }
    
        /// <summary>
        /// Post code of party
        /// </summary>
        [Attr]
        [JsonProperty("postCode", NullValueHandling = NullValueHandling.Ignore)]
        public string PostCode { get; set; }
    
        /// <summary>
        /// Country of party
        /// </summary>
        [Attr]
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
    
        /// <summary>
        /// City
        /// </summary>
        [Attr]
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }
    
        /// <summary>
        /// TRACES ID
        /// </summary>
        [Attr]
        [JsonProperty("tracesID", NullValueHandling = NullValueHandling.Ignore)]
        public int TracesID { get; set; }
    
        /// <summary>
        /// Type of party
        /// </summary>
        [Attr]
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string _Type { get; set; }
    
        /// <summary>
        /// Approval number
        /// </summary>
        [Attr]
        [JsonProperty("approvalNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string ApprovalNumber { get; set; }
    
        /// <summary>
        /// Phone number of party
        /// </summary>
        [Attr]
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }
    
        /// <summary>
        /// Fax number of party
        /// </summary>
        [Attr]
        [JsonProperty("fax", NullValueHandling = NullValueHandling.Ignore)]
        public string Fax { get; set; }
    
        /// <summary>
        /// Email number of party
        /// </summary>
        [Attr]
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
    
}


