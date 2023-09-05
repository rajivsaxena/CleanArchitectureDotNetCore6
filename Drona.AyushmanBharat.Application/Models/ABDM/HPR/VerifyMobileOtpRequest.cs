namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class VerifyMobileOtpRequest
    {
        [Newtonsoft.Json.JsonProperty("txnId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public Guid TxnId { get; set; }

        [Newtonsoft.Json.JsonProperty("otp", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string? Otp { get; set; }
    }
}
