namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class GatewayToken : ApiError
    {
        [Newtonsoft.Json.JsonProperty("accessToken")]
        public string? AccessToken { get; set; }

        [Newtonsoft.Json.JsonProperty("expiresIn")]
        public long ExpiresIn { get; set; }

        [Newtonsoft.Json.JsonProperty("refreshToken")]
        public string? RefreshToken { get; set; }

        [Newtonsoft.Json.JsonProperty("refreshExpiresIn")]
        public long RefreshExpiresIn { get; set; }
        [Newtonsoft.Json.JsonProperty("tokenType")]
        public string? TokenType { get; set; }
    }
}
