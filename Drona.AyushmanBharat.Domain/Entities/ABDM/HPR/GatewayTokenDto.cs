using Drona.AyushmanBharat.Domain.Common;
using Newtonsoft.Json;

namespace Drona.AyushmanBharat.Domain.Entities.ABDM.HPR
{
    public class GatewayTokenDto : EntityBase
    {
        public Guid TxnId { get; set; }

        public string? MobileNumber { get; set; }

        private IDictionary<string, object>? _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }
    }
}
