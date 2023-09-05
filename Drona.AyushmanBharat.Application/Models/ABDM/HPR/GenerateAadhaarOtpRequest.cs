namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class GenerateAadhaarOtpRequest
    {

        /// <summary>
        /// 12-digits Aaddhaar number/16-digits Virtual-ID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("aadhaar")]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^(\d{12}|\d{16})*$")]
        public string? Aadhaar { get; set; }

        /// <summary>
        /// Consent of the aadhaar card holder
        /// </summary>
        [Newtonsoft.Json.JsonProperty("iagree")]
        public bool Iagree { get; set; }

        /// <summary>
        /// consent version
        /// </summary>
        [Newtonsoft.Json.JsonProperty("consentVersion")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string? ConsentVersion { get; set; }
    }
}
