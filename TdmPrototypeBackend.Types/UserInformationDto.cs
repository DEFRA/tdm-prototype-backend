
using JsonApiDotNetCore.Resources.Annotations;
using Newtonsoft.Json;
using TdmPrototypeBackend.Types;


namespace TdmDataModel;

    /// <summary>
    /// Information about logged-in user
    /// </summary>
public partial class UserInformationDto  {


        /// <summary>
        /// Display name
        /// </summary>
        [Attr]
        [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }
    
        /// <summary>
        /// User ID
        /// </summary>
        [Attr]
        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
    
        /// <summary>
        /// Is this user a control
        /// </summary>
        [Attr]
        [JsonProperty("isControlUser", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsControlUser { get; set; }
    
}


