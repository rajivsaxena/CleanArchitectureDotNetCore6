namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class LoginViaMobileVerifyOtpResponse : ApiError
    {
        [Newtonsoft.Json.JsonProperty("txnId")]
        public Guid TxnId { get; set; }

        [Newtonsoft.Json.JsonProperty("mobileLinkedHpIdDTO")]
        public ICollection<Mobilelinkedhpiddto>? MobileLinkedHpIdDTO { get; set; }
    }

    public class Mobilelinkedhpiddto
    {
        [Newtonsoft.Json.JsonProperty("hprIdNumber")]
        public string? HprIdNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string? Name { get; set; }

        [Newtonsoft.Json.JsonProperty("hprId")]
        public string? HprId { get; set; }
    }

}
