
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Party details
    /// </summary>
public partial class IpaffsParty  {


        /// <summary>
        /// IPAFFS ID of party
        /// </summary>
        [Attr]
        [JsonPropertyName("id")]
        public string IpaffsId { get; set; }
    
        /// <summary>
        /// Name of party
        /// </summary>
        [Attr]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    
        /// <summary>
        /// Company ID
        /// </summary>
        [Attr]
        [JsonPropertyName("companyId")]
        public string CompanyId { get; set; }
    
        /// <summary>
        /// Contact ID (B2C)
        /// </summary>
        [Attr]
        [JsonPropertyName("contactId")]
        public string ContactId { get; set; }
    
        /// <summary>
        /// Company name
        /// </summary>
        [Attr]
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }
    
        /// <summary>
        /// Addresses
        /// </summary>
        [Attr]
        [JsonPropertyName("address")]
        public string[][] Addresses { get; set; }
    
        /// <summary>
        /// County
        /// </summary>
        [Attr]
        [JsonPropertyName("county")]
        public string County { get; set; }
    
        /// <summary>
        /// Post code of party
        /// </summary>
        [Attr]
        [JsonPropertyName("postCode")]
        public string PostCode { get; set; }
    
        /// <summary>
        /// Country of party
        /// </summary>
        [Attr]
        [JsonPropertyName("country")]
        public string Country { get; set; }
    
        /// <summary>
        /// City
        /// </summary>
        [Attr]
        [JsonPropertyName("city")]
        public string City { get; set; }
    
        /// <summary>
        /// TRACES ID
        /// </summary>
        [Attr]
        [JsonPropertyName("tracesID")]
        public int TracesID { get; set; }
    
        /// <summary>
        /// Type of party
        /// </summary>
        [Attr]
        [JsonPropertyName("type")]
        public IpaffsTypeEnum IpaffsType { get; set; }
    
        /// <summary>
        /// Approval number
        /// </summary>
        [Attr]
        [JsonPropertyName("approvalNumber")]
        public string ApprovalNumber { get; set; }
    
        /// <summary>
        /// Phone number of party
        /// </summary>
        [Attr]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    
        /// <summary>
        /// Fax number of party
        /// </summary>
        [Attr]
        [JsonPropertyName("fax")]
        public string Fax { get; set; }
    
        /// <summary>
        /// Email number of party
        /// </summary>
        [Attr]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    
}


