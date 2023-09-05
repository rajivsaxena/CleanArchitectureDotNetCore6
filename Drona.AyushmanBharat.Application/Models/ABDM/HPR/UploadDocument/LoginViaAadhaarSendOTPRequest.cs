namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class LoginViaAadhaarSendOTPRequest
    {
        [Newtonsoft.Json.JsonProperty("idType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? IdType { get; set; }

        [Newtonsoft.Json.JsonProperty("domainName", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? DomainName { get; set; }

        [Newtonsoft.Json.JsonProperty("authMethod", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public AuthInitRequestAuthMethod AuthMethod { get; set; }

        /// <summary>
        /// Healthcare Professional ID Alias.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("hprId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string? HprId { get; set; }
    }

    public enum AuthInitRequestAuthMethod
    {

        [System.Runtime.Serialization.EnumMember(Value = @"AADHAAR_OTP")]
        AADHAAR_OTP = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"MOBILE_OTP")]
        MOBILE_OTP = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"PASSWORD")]
        PASSWORD = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"DEMOGRAPHICS")]
        DEMOGRAPHICS = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"AADHAAR_BIO")]
        AADHAAR_BIO = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"EMAIL_OTP")]
        EMAIL_OTP = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"MOBILE_OTP_RESET_PASSWROD")]
        MOBILE_OTP_RESET_PASSWROD = 6,

    }
}
