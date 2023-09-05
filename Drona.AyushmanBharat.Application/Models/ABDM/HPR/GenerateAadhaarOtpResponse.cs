namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class GenerateAadhaarOtpResponse : ApiError
    {
        /// <summary>
        /// Based on UUID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("txnId")]
        public System.Guid TxnId { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        [Newtonsoft.Json.JsonProperty("mobileNumber")]
        public string? MobileNumber { get; set; }
    }
}
