namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class AccessTokenResponse : ApiError
    {
        [Newtonsoft.Json.JsonProperty("token")]
        public string? AccessToken { get; set; }

        /// <summary>
        /// Access Token expiry time
        /// </summary>
        [Newtonsoft.Json.JsonProperty("expiresIn")]
        public long ExpiresIn { get; set; }

        /// <summary>
        /// JWT Bearer Token
        /// </summary>
        [Newtonsoft.Json.JsonProperty("refreshToken")]
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Refresh Token expiry time
        /// </summary>
        [Newtonsoft.Json.JsonProperty("refreshExpiresIn")]
        public long RefreshExpiresIn { get; set; }
    }
}
