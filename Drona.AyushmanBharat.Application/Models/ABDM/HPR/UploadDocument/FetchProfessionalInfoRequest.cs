namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class FetchProfessionalInfoRequest
    {
        [Newtonsoft.Json.JsonProperty("practitioner")]
        public PractitionerRequest? Practitioner { get; set; }
    }

    public class PractitionerRequest
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string? HprNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string? Name { get; set; }

        [Newtonsoft.Json.JsonProperty("contactNumber")]
        public string? MobileNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("state")]
        public string? State { get; set; }

        [Newtonsoft.Json.JsonProperty("registrationNumber")]
        public string? RegistrationNumber { get; set; }
    }

}
