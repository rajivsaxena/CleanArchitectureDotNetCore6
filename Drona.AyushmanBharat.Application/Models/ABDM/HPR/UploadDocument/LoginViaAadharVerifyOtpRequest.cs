namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class LoginViaAadharVerifyOtpRequest
    {
        /// <summary>
        /// OTP recievied on the Aadhaar Linked Mobile Number
        /// </summary>
        [Newtonsoft.Json.JsonProperty("otp", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string? Otp { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("txnId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public Guid TxnId { get; set; }
    }
}
