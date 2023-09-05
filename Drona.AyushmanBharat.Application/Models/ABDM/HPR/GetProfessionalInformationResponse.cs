#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class GetProfessionalInformationResponse : ApiError
    {
        [Newtonsoft.Json.JsonProperty("practitioners")]
        public FetchProfessionalInfomationResponse[][]? Practitioners { get; set; }
    }

    public class FetchProfessionalInfomationResponse
    {
        [Newtonsoft.Json.JsonProperty("identifier")]
        public int Identifier { get; set; }

        [Newtonsoft.Json.JsonProperty("hpr_id")]
        public string Hpr_Id { get; set; }

        [Newtonsoft.Json.JsonProperty("application_status")]
        public string Application_Status { get; set; }

        [Newtonsoft.Json.JsonProperty("is_council_verified")]
        public string Is_council_Verified { get; set; }

        [Newtonsoft.Json.JsonProperty("is_work_verified")]
        public string Is_Work_Verified { get; set; }

        [Newtonsoft.Json.JsonProperty("practitioners")]
        public string Remarks { get; set; }

        [Newtonsoft.Json.JsonProperty("active")]
        public string Active { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("gender")]
        public string Gender { get; set; }

        [Newtonsoft.Json.JsonProperty("salutation")]
        public string Salutation { get; set; }

        [Newtonsoft.Json.JsonProperty("hpr_category")]
        public string Hpr_Category { get; set; }
    }
}
