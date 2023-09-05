namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class VerifyAadhaarOtpRequest
    {
        [Newtonsoft.Json.JsonProperty("idType")]
        public string? IdType { get; set; }

        [Newtonsoft.Json.JsonProperty("domainName")]
        public string? DomainName { get; set; }

        [Newtonsoft.Json.JsonProperty("otp", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string? Otp { get; set; }

        [Newtonsoft.Json.JsonProperty("txnId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public Guid TxnId { get; set; }

        [Newtonsoft.Json.JsonProperty("restrictions")]
        public string? Restrictions { get; set; }
    }
}
