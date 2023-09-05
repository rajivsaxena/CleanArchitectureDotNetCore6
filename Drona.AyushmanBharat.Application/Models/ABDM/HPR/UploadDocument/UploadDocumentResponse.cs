namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class UploadDocumentResponse : ApiError
    {
        [Newtonsoft.Json.JsonProperty("status")]
        public string? Status { get; set; }

        [Newtonsoft.Json.JsonProperty("msg")]
        public string? Msg { get; set; }

        [Newtonsoft.Json.JsonProperty("profilePhoto")]
        public ProfilephotoResponse? ProfilePhoto { get; set; }

        [Newtonsoft.Json.JsonProperty("degreeCertificate")]
        public DegreecertificateResponse? DegreeCertificate { get; set; }

        [Newtonsoft.Json.JsonProperty("registrationCertificate")]
        public RegistrationcertificateResponse? RegistrationCertificate { get; set; }

        [Newtonsoft.Json.JsonProperty("proofOfWorkCertificate")]
        public ProofofworkcertificateResponse? ProofOfWorkCertificate { get; set; }
    }

    public class ProfilephotoResponse
    {
        [Newtonsoft.Json.JsonProperty("status")]
        public string? Status { get; set; }

        [Newtonsoft.Json.JsonProperty("msg")]
        public string? Msg { get; set; }
    }

    public class DegreecertificateResponse
    {
        [Newtonsoft.Json.JsonProperty("status")]
        public string? Status { get; set; }

        [Newtonsoft.Json.JsonProperty("msg")]
        public string? Msg { get; set; }
    }

    public class RegistrationcertificateResponse
    {
        [Newtonsoft.Json.JsonProperty("status")]
        public string? Status { get; set; }

        [Newtonsoft.Json.JsonProperty("msg")]
        public string? Msg { get; set; }
    }

    public class ProofofworkcertificateResponse
    {
        [Newtonsoft.Json.JsonProperty("status")]
        public string? Status { get; set; }

        [Newtonsoft.Json.JsonProperty("msg")]
        public string? Msg { get; set; }
    }
}