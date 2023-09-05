namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class GenerateMobileOtpResponse : ApiError
    {
        [Newtonsoft.Json.JsonProperty("txnId")]
        public Guid TxnId { get; set; }

        [Newtonsoft.Json.JsonProperty("mobileNumber")]
        public string? MobileNumber { get; set; }
    }
}
