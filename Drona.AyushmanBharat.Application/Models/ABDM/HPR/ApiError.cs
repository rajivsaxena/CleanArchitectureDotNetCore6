namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class ApiError
    {
        [Newtonsoft.Json.JsonProperty("code")]
        public string? Code { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string? Message { get; set; }

        [Newtonsoft.Json.JsonProperty("details")]
        public ICollection<ErrorDetails>? Details { get; set; }

        private IDictionary<string, object>? _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }
    }
    public partial class ErrorDetails
    {
        [Newtonsoft.Json.JsonProperty("message")]
        public string? Message { get; set; }

        [Newtonsoft.Json.JsonProperty("code")]
        public string? Code { get; set; }

        [Newtonsoft.Json.JsonProperty("attribute")]
        public ErrorAttribute? Attribute { get; set; }

        private IDictionary<string, object>? _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }
    }
    public partial class ErrorAttribute
    {
        [Newtonsoft.Json.JsonProperty("key")]
        public string? Key { get; set; }

        [Newtonsoft.Json.JsonProperty("value")]
        public string? Value { get; set; }

        private IDictionary<string, object>? _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }
    }
}
