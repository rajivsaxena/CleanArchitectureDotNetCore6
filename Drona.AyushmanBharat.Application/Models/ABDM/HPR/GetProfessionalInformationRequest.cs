namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class GetProfessionalInformationRequest
    {
        [Newtonsoft.Json.JsonProperty("practitioner", Required = Newtonsoft.Json.Required.Always)]
        public PractitionerInformationRequest? Practitioner { get; set; }
    }

    public class PractitionerInformationRequest
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
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
