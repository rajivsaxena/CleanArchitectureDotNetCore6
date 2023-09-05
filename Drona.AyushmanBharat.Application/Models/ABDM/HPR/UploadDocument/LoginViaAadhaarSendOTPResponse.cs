namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class LoginViaAadhaarSendOTPResponse : ApiError
    {
        [Newtonsoft.Json.JsonProperty("txnId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid TxnId { get; set; }

        [Newtonsoft.Json.JsonProperty("mobileNumber", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? MobileNumber { get; set; }
    }
}
