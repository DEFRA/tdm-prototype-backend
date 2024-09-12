
using JsonApiDotNetCore.Resources.Annotations;
using System.Text.Json.Serialization;
using TdmPrototypeBackend.Types;


namespace TdmPrototypeBackend.Types;

    /// <summary>
    /// Information about logged-in user
    /// </summary>
public partial class UserInformationDto  {


        /// <summary>
        /// Display name
        /// </summary>
        [Attr]
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    
        /// <summary>
        /// User ID
        /// </summary>
        [Attr]
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
    
        /// <summary>
        /// Is this user a control
        /// </summary>
        [Attr]
        [JsonPropertyName("isControlUser")]
        public bool IsControlUser { get; set; }
    
}


