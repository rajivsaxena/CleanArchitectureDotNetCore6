namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class GenerateMobileOtpRequest
    {
        [Newtonsoft.Json.JsonProperty("mobile")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Mobile { get; set; }

        [Newtonsoft.Json.JsonProperty("txnId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public Guid TxnId { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }
    }
}
