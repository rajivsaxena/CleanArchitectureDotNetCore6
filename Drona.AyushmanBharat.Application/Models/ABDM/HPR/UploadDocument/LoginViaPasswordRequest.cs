namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class LoginViaPasswordRequest
    {
        [Newtonsoft.Json.JsonProperty("idType")]
        public string? IdType { get; set; }

        [Newtonsoft.Json.JsonProperty("domainName")]
        public string? DomainName { get; set; }

        /// <summary>
        /// Healthcare Professional ID Alias.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("hprId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string? HprId { get; set; }

        /// <summary>
        /// Passwords for authentication
        /// </summary>
        [Newtonsoft.Json.JsonProperty("password")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string? Password { get; set; }

    }
}
