namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class VerifyAadhaarOtpResponse : ApiError
    {
        /// <summary>
        /// Based on UUID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("txnId")]
        public Guid TxnId { get; set; }

        /// <summary>
        /// Mobile number of the user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("mobileNumber")]
        public string? MobileNumber { get; set; }

        /// <summary>
        /// Base64 string KYC Photo
        /// </summary>
        //[Newtonsoft.Json.JsonProperty("photo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public System.Collections.Generic.ICollection<byte[]> Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public byte[] Photo { get; set; }


        /// <summary>
        /// Gender of the User, M-Male, F-Female, T-Transgender
        /// </summary>
        [Newtonsoft.Json.JsonProperty("gender", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Gender { get; set; }

        /// <summary>
        /// Name of the User
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Email of the user
        /// </summary>
        [Newtonsoft.Json.JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Pincode
        /// </summary>
        [Newtonsoft.Json.JsonProperty("pincode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Pincode { get; set; }

        /// <summary>
        /// Date of Birth(dd-MM-YYY) or Year of Birth(YYYY).
        /// </summary>
        [Newtonsoft.Json.JsonProperty("birthdate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Birthdate { get; set; }

        /// <summary>
        /// Care of
        /// </summary>
        [Newtonsoft.Json.JsonProperty("careOf")]
        public string CareOf { get; set; }

        /// <summary>
        /// house
        /// </summary>
        [Newtonsoft.Json.JsonProperty("house")]
        public string House { get; set; }

        /// <summary>
        /// street
        /// </summary>
        [Newtonsoft.Json.JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        /// Landmark
        /// </summary>
        [Newtonsoft.Json.JsonProperty("landmark")]
        public string Landmark { get; set; }

        /// <summary>
        /// locality
        /// </summary>
        [Newtonsoft.Json.JsonProperty("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// village Town City
        /// </summary>
        [Newtonsoft.Json.JsonProperty("villageTownCity")]
        public string VillageTownCity { get; set; }

        /// <summary>
        /// Subdistrict Name
        /// </summary>
        [Newtonsoft.Json.JsonProperty("subDist")]
        public string SubDist { get; set; }

        /// <summary>
        /// District Name
        /// </summary>
        [Newtonsoft.Json.JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        /// State Name
        /// </summary>
        [Newtonsoft.Json.JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Post office
        /// </summary>
        [Newtonsoft.Json.JsonProperty("postOffice")]
        public string PostOffice { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }
    }
}
