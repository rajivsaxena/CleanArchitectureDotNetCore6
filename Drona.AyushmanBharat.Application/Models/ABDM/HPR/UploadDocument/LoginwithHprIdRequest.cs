namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class LoginwithHprIdRequest
    {
        [Newtonsoft.Json.JsonProperty("hpId")]
        public string? HpId { get; set; }
        [Newtonsoft.Json.JsonProperty("txnId")]
        public Guid TxnId { get; set; }
    }
}
