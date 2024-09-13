//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;

namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Present if the consignment has been split
    /// </summary>
public partial class IpaffsSplitConsignment  {


        /// <summary>
        /// Reference number of the valid split consignment
        /// </summary>
        [Attr]
        [JsonPropertyName("validReferenceNumber")]
        public string ValidReferenceNumber { get; set; }
    
        /// <summary>
        /// Reference number of the rejected split consignment
        /// </summary>
        [Attr]
        [JsonPropertyName("rejectedReferenceNumber")]
        public string RejectedReferenceNumber { get; set; }
    
}

