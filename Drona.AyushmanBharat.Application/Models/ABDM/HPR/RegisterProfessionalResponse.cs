namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class RegisterProfessionalResponse : ApiError
    {
        public Guid? TxnId { get; set; }

        [Newtonsoft.Json.JsonProperty("referenceNumber", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? ReferenceNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("status", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Status { get; set; }

        [Newtonsoft.Json.JsonProperty("hprId", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? HprId { get; set; }
    }
}
