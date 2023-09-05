namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class CreateHprIdResponse : ApiError
    {
        [Newtonsoft.Json.JsonProperty("token")]
        public string? Token { get; set; }

        [Newtonsoft.Json.JsonProperty("expiresIn")]
        public long ExpiresIn { get; set; }

        [Newtonsoft.Json.JsonProperty("refreshToken")]
        public string? RefreshToken { get; set; }

        [Newtonsoft.Json.JsonProperty("refreshExpiresIn")]
        public long RefreshExpiresIn { get; set; }

        [Newtonsoft.Json.JsonProperty("hprIdNumber")]
        public string? HprIdNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string? Name { get; set; }

        [Newtonsoft.Json.JsonProperty("gender")]
        public string? Gender { get; set; }

        [Newtonsoft.Json.JsonProperty("yearOfBirth")]
        public string? YearOfBirth { get; set; }

        [Newtonsoft.Json.JsonProperty("monthOfBirth")]
        public string? MonthOfBirth { get; set; }

        [Newtonsoft.Json.JsonProperty("dayOfBirth")]
        public string? DayOfBirth { get; set; }

        [Newtonsoft.Json.JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("hprId")]
        public string? HprId { get; set; }

        [Newtonsoft.Json.JsonProperty("lastName")]
        public string? LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("middleName")]
        public string? MiddleName { get; set; }

        [Newtonsoft.Json.JsonProperty("stateCode")]
        public string? StateCode { get; set; }

        [Newtonsoft.Json.JsonProperty("districtCode")]
        public string? DistrictCode { get; set; }

        [Newtonsoft.Json.JsonProperty("stateName")]
        public string? StateName { get; set; }

        [Newtonsoft.Json.JsonProperty("districtName")]
        public string? DistrictName { get; set; }

        [Newtonsoft.Json.JsonProperty("email")]
        public string? Email { get; set; }

        [Newtonsoft.Json.JsonProperty("kycPhoto")]
        public string? KycPhoto { get; set; }

        [Newtonsoft.Json.JsonProperty("mobile")]
        public string? Mobile { get; set; }

        [Newtonsoft.Json.JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [Newtonsoft.Json.JsonProperty("subCategoryId")]
        public int SubCategoryId { get; set; }

        [Newtonsoft.Json.JsonProperty("new")]
        public bool New { get; set; }

        [Newtonsoft.Json.JsonProperty("categories")]
        public IDictionary<string, string>? Categories { get; set; }
    }
}
