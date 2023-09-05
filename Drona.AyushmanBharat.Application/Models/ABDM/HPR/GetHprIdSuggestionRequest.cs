namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class GetHprIdSuggestionRequest
    {

        /// <summary>
        /// Based on UUID
        /// </summary>
        [Newtonsoft.Json.JsonProperty("txnId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public Guid TxnId { get; set; }
    }
}
