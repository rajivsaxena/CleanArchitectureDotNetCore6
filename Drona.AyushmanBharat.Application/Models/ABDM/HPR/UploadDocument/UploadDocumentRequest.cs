namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class UploadDocumentRequest
    {
        [Newtonsoft.Json.JsonProperty("hpr_token")]
        public string? Hpr_Token { get; set; }

        [Newtonsoft.Json.JsonProperty("document")]
        public ICollection<Document>? Document { get; set; }
    }

    public class Document
    {
        [Newtonsoft.Json.JsonProperty("document_id")]
        public int Document_id { get; set; }

        [Newtonsoft.Json.JsonProperty("document_type")]
        public string? Document_type { get; set; }

        [Newtonsoft.Json.JsonProperty("fileType")]
        public string? FileType { get; set; }

        [Newtonsoft.Json.JsonProperty("data")]
        public string? Data { get; set; }
    }
}
