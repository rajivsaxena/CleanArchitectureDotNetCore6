namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class LoginViaMobileSendOTPResponse : ApiError
    {
        [Newtonsoft.Json.JsonProperty("txnId")]
        public System.Guid TxnId { get; set; }

        [Newtonsoft.Json.JsonProperty("mobileNumber", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? MobileNumber { get; set; }
    }
}
