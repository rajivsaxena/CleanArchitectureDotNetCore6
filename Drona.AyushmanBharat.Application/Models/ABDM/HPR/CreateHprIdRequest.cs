namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class CreateHprIdRequest
    {
        [Newtonsoft.Json.JsonProperty("idType")]
        public string? IdType { get; set; }

        [Newtonsoft.Json.JsonProperty("domainName")]
        public string? DomainName { get; set; }

        /// <summary>
        /// Email Address of the user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string? Email { get; set; }

        /// <summary>
        /// First Name of the user).
        /// </summary>
        [Newtonsoft.Json.JsonProperty("firstName")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Middle name of the user 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("middleName")]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Last name of the user 
        /// </summary>
        [Newtonsoft.Json.JsonProperty("lastName")]
        public string? LastName { get; set; }

        /// <summary>
        /// Passwords for authentication
        /// </summary>
        [Newtonsoft.Json.JsonProperty("password")]
        public string? Password { get; set; }

        /// <summary>
        /// Profile photo of the user (Uploaded by the user).
        /// </summary>
        [Newtonsoft.Json.JsonProperty("profilePhoto")]
        public string? ProfilePhoto { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("txnId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public Guid TxnId { get; set; }

        /// <summary>
        /// Healthcare Professional ID Alias.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("hprId")]
        public string? HprId { get; set; }

        /// <summary>
        /// User will be notify for his/her Health Professional ID creation.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("notifyUser")]
        public bool NotifyUser { get; set; }
    }
}
