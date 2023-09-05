namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class LoginViaMobileVerifyOtpRequest
    {
        [Newtonsoft.Json.JsonProperty("otp", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string? Otp { get; set; }

        [Newtonsoft.Json.JsonProperty("txnId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public Guid TxnId { get; set; }
    }
}
