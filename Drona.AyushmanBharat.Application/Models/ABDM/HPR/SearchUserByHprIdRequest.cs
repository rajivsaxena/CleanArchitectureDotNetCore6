namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class SearchUserByHprIdRequest
    {
            [Newtonsoft.Json.JsonProperty("idType", Required = Newtonsoft.Json.Required.DisallowNull)]
            public string? IdType { get; set; }

            [Newtonsoft.Json.JsonProperty("domainName", Required = Newtonsoft.Json.Required.DisallowNull)]
            public string? DomainName { get; set; }

            /// <summary>
            /// Healthcare Professional-ID  Number or Alias
            /// </summary>
            [Newtonsoft.Json.JsonProperty("hprId", Required = Newtonsoft.Json.Required.Always)]
            [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
            public string? HprId { get; set; }
    }
}
