
namespace Drona.AyushmanBharat.HPR.API.V1
{

    public class ClientKeys
    {
        public string? clientId { get; set; }
        public string? clientSecret { get; set; }
        public string? grantType { get; set; }
    }

    public partial class ClientV1
    {
        private readonly string _token;
        public readonly bool _isAuthorized;

        public ClientV1(HttpClient httpClient, bool isAuthorized, string token)
        {
            _token = token;
            _isAuthorized = isAuthorized;
            _httpClient = httpClient;
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
        }

        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            if (_isAuthorized && client.DefaultRequestHeaders.Authorization is null)
            {
                client.DefaultRequestHeaders.Add("Authorization", string.Concat("Bearer ", _token));
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }
        }

        public async Task<T2> ProcessResponse<T2>(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response_, CancellationToken cancellationToken)
        {
            var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
            if (response_.Content != null && response_.Content.Headers != null)
            {
                foreach (var item_ in response_.Content.Headers)
                    headers_[item_.Key] = item_.Value;
            }
            var status_ = (int)response_.StatusCode;
            if (status_ == 400)
            {
                var objectResponse_ = await ReadObjectResponseAsync<T2>(response_, headers_, cancellationToken).ConfigureAwait(false);
                if (objectResponse_.Object == null)
                {
                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                }
                return objectResponse_.Object;
                // throw new ApiException<ApiError>("Bad Request. Please provide valid request syntax", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 500)
            {
                var objectResponse_ = await ReadObjectResponseAsync<T2>(response_, headers_, cancellationToken).ConfigureAwait(false);
                if (objectResponse_.Object == null)
                {
                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                }
                return objectResponse_.Object;
                // throw new ApiException<ApiError>("Server encountered an unexpected condition that prevented it from fulfilling the request", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 422)
            {
                var objectResponse_ = await ReadObjectResponseAsync<T2>(response_, headers_, cancellationToken).ConfigureAwait(false);
                if (objectResponse_.Object == null)
                {
                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                }
                return objectResponse_.Object;
                //throw new ApiException<T2>("Unprocessable Entity", status_, objectResponse_.Text, headers_, objectResponse_.Object, null);
            }
            else
            if (status_ == 200)
            {
                var objectResponse_ = await ReadObjectResponseAsync<T2>(response_, headers_, cancellationToken).ConfigureAwait(false);
                if (objectResponse_.Object == null)
                {
                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                }
                return objectResponse_.Object;
            }
            if (status_ == 401)
            {
                var objectResponse_ = await ReadObjectResponseAsync<T2>(response_, headers_, cancellationToken).ConfigureAwait(false);
                if (objectResponse_.Object == null)
                {
                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                }
                return objectResponse_.Object;
            }
            else
            {
                var objectResponse_ = await ReadObjectResponseAsync<T2>(response_, headers_, cancellationToken).ConfigureAwait(false);
                if (objectResponse_.Object == null)
                {
                    throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                }
                return objectResponse_.Object;

                //var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                //throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
            }
        }

        public virtual async Task<T2> PostAync<T1, T2>(T1 body, string url, CancellationToken cancellationToken, bool serializeObject = true)
        {
            if (body == null)
                throw new System.ArgumentNullException("body");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(url);

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new HttpRequestMessage())
                {
                    string json_ = string.Empty;
                    if (_settings == null)
                        _settings = new Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);

                    if (serializeObject)
                        json_ = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                    else
                        json_ = body.ToString() ?? string.Empty;

                    var content_ = new StringContent(json_);
                    content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                    request_.Content = content_;
                    request_.Method = new HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));
                    request_.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url);

                    var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        return await ProcessResponse<T2>(client_, response_, cancellationToken);
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }

        public virtual async Task<T2> GetAsync<T2>(string x_Token, string url, CancellationToken cancellationToken, bool serializeObject = true)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            //urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1/account/profile");
            urlBuilder_.Append(url);
            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new HttpRequestMessage())
                {

                    if (x_Token != null)
                        request_.Headers.TryAddWithoutValidation("X-Token", ConvertToString(x_Token, System.Globalization.CultureInfo.InvariantCulture));
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        return await ProcessResponse<T2>(client_, response_, cancellationToken);
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (disposeClient_)
                    client_.Dispose();
            }
        }
    }
}