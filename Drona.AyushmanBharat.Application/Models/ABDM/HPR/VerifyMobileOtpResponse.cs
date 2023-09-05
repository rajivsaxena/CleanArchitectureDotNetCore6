namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class VerifyMobileOtpResponse : ApiError
    {
        [Newtonsoft.Json.JsonProperty("txnId")]
        public System.Guid TxnId { get; set; }

        [Newtonsoft.Json.JsonProperty("mobileNumber")]
        public string? MobileNumber { get; set; }
    }
}
