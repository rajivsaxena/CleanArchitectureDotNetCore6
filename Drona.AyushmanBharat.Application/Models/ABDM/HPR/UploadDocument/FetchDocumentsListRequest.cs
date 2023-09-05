namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class FetchDocumentsListRequest
    {
        [Newtonsoft.Json.JsonProperty("hprid", Required = Newtonsoft.Json.Required.Always)]
        public string? HprId { get; set; }
    }
}
