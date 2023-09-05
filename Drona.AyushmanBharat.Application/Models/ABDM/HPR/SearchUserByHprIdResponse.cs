namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class SearchUserByHprIdResponse : ApiError
    {
            [Newtonsoft.Json.JsonProperty("status")]
            public bool Status { get; set; }
    }
}
