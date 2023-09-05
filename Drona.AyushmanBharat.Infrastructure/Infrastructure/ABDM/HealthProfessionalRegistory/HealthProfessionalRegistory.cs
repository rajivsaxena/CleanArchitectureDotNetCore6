using Drona.AyushmanBharat.Application.Contracts.Infrastructure.ABDM.HealthProfessionalRegistory;
using Drona.AyushmanBharat.Application.Models.ABDM.HPR;
using Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument;
using Drona.AyushmanBharat.Application.Models.UrlDM.HPR;
using Drona.AyushmanBharat.Cache;
using Drona.AyushmanBharat.HPR.API.V1;
using Drona.AyushmanBharat.Infrastructure.Utilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Drona.AyushmanBharat.Infrastructure.Infrastructure.ABDM.HealthProfessionalRegistory
{
    public class HealthProfessionalRegistory : IHealthProfessionalRegistory
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public readonly ABDMSandboxKey _clientKeys;
        public readonly HprApiUrl _apiUrls;
        public readonly CacheConnectionOptions _cacheConnectionOption;
        public readonly ILogger<HealthProfessionalRegistory> _logger;
        public HealthProfessionalRegistory(IOptions<ABDMSandboxKey> clientKeys, IOptions<HprApiUrl> apiUrls, IOptions<CacheConnectionOptions> cacheConnectionOption, ILogger<HealthProfessionalRegistory> logger)
        {
            _clientKeys = clientKeys.Value ?? throw new ArgumentNullException(nameof(clientKeys));
            _apiUrls = apiUrls.Value ?? throw new ArgumentNullException(nameof(apiUrls));
            _cacheConnectionOption = cacheConnectionOption.Value ?? throw new ArgumentNullException(nameof(cacheConnectionOption));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GatewayToken> GenerateGatewayToken(CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient);
            ClientKeys clientKey = new ClientKeys() { clientId = _clientKeys.ClientId, clientSecret = _clientKeys.ClientSecret, grantType = "client_credentials" };
            var result = await v1.PostAync<ClientKeys, GatewayTokenResponse>(clientKey, string.Concat(_apiUrls.GatewayTokenUrl), cancellationToken);
            return result.Cast<GatewayToken>();
        }

        public async Task<GenerateAadhaarOtpResponse> GenerateAadhaarOTP(GenerateAadhaarOtpRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 clientV1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await clientV1.PostAync<GenerateAadhaarOtpRequest, GenerateAadhaarOtpResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.GenerateAadhaarOTPUrl), cancellationToken);
            return response;
        }

        public async Task<VerifyAadhaarOtpResponse> VerifyAadhaarOTP(VerifyAadhaarOtpRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            VerifyAadhaarOtpResponse response = await v1.PostAync<VerifyAadhaarOtpRequest, VerifyAadhaarOtpResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.VerifyAadhaarOTPUrl), cancellationToken);
            return response;
        }

        public async Task<GenerateMobileOtpResponse> GenerateMobileOTP(GenerateMobileOtpRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<GenerateMobileOtpRequest, GenerateMobileOtpResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.GenerateMobileOTPUrl), cancellationToken);
            return response;
        }

        public async Task<VerifyMobileOtpResponse> VerifyMobileOTP(VerifyMobileOtpRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<VerifyMobileOtpRequest, VerifyMobileOtpResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.VerifyMobileOTPUrl), cancellationToken);
            return response;
        }

        public async Task<CreateHprIdResponse> CreateHPRId(CreateHprIdRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<CreateHprIdRequest, CreateHprIdResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.CreateHPRIdUrl), cancellationToken);
            return response;
        }

        public async Task<RegisterProfessionalResponse> RegisterProfessional(RegisterProfessionalRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<RegisterProfessionalRequest, RegisterProfessionalResponse>(request, string.Concat(_apiUrls.HprDoctorBaseUrl, _apiUrls.RegisterProfessionalUrl), cancellationToken);
            return response;
        }

        public async Task<SearchUserByHprIdResponse> SearchUserByHprId(SearchUserByHprIdRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<SearchUserByHprIdRequest, SearchUserByHprIdResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.SearchUserByHprIdUrl), cancellationToken);
            return response;
        }

        public async Task<ICollection<string>> GetHprIdSuggestion(GetHprIdSuggestionRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<GetHprIdSuggestionRequest, ICollection<string>>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.GetHprIdSuggestionUrl), cancellationToken);
            return response;
        }

        public async Task<GetProfessionalInformationResponse> FetchProfessionalInformation(GetProfessionalInformationRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<GetProfessionalInformationRequest,GetProfessionalInformationResponse>(request, string.Concat(_apiUrls.HprDoctorBaseUrl, _apiUrls.FetchProfessionalInformationUrl), cancellationToken);
            return response;
        }

        public async Task<AccessTokenResponse> LoginViaPassword(LoginViaPasswordRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<LoginViaPasswordRequest, AccessTokenResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.LoginViaPasswordUrl), cancellationToken);
            return response;
        }

        public async Task<LoginViaMobileSendOTPResponse> LoginViaMobileSendOTP(LoginViaMobileSendOTPRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<LoginViaMobileSendOTPRequest, LoginViaMobileSendOTPResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.LoginViaMobileSendOTPUrl), cancellationToken);
            return response;
        }

        public async Task<LoginViaMobileVerifyOtpResponse> LoginViaMobileVerifyOTP(LoginViaMobileVerifyOtpRequest request, string? token, CancellationToken cancellationToken)
        {
            string dataToEncrypt = request.Otp ?? string.Empty;
            Guid guid = request.TxnId;
            //todo : store this certificate somewhere, may be in cache and use this only, no need to call get certificate again and again
            ClientV1 v1 = new ClientV1(httpClient);
            string publicKeyPEM = await v1.CertAsync(cancellationToken);
            if (string.IsNullOrEmpty(publicKeyPEM))
                throw new Exception($"Error while getting public certificate");
            publicKeyPEM = publicKeyPEM.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "").Replace("\n", "").Replace("\r", "").Trim();
            string otp = SecureNow.EncryptDataUsingRSA(publicKeyPEM, dataToEncrypt);
            if (string.IsNullOrEmpty(otp))
            {
                throw new Exception($"Error while encrypting otp");
            }
            var response = await v1.PostAync<LoginViaMobileVerifyOtpRequest, LoginViaMobileVerifyOtpResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.LoginViaMobileVerifyOTPUrl), cancellationToken);
            return response;
        }

        public async Task<AccessTokenResponse> LoginWithHRPId(LoginwithHprIdRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<LoginwithHprIdRequest, AccessTokenResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.LoginWithHRPIdUrl), cancellationToken);
            return response;
        }

        public async Task<LoginViaAadhaarSendOTPResponse> LoginViaAadharSendOTP(LoginViaAadhaarSendOTPRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<LoginViaAadhaarSendOTPRequest, LoginViaAadhaarSendOTPResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.LoginViaAadharSendOTPUrl), cancellationToken);
            return response;
        }

        public async Task<AccessTokenResponse> LoginViaAadharVerifyOtp(LoginViaAadharVerifyOtpRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<LoginViaAadharVerifyOtpRequest, AccessTokenResponse>(request, string.Concat(_apiUrls.HprBaseUrl, _apiUrls.LoginViaAadharVerifyOtpUrl), cancellationToken);
            return response;
        }

        public async Task<FetchProfessionalInfoResponse> FetchProfessionalInfo(FetchProfessionalInfoRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<FetchProfessionalInfoRequest, FetchProfessionalInfoResponse>(request, string.Concat(_apiUrls.HprDoctorBaseUrl, _apiUrls.FetchProfessionalInfoUrl), cancellationToken);
            return response;
        }

        public async Task<UploadDocumentResponse> UploadDocument(UploadDocumentRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<UploadDocumentRequest, UploadDocumentResponse>(request, string.Concat(_apiUrls.HprDoctorBaseUrl, _apiUrls.UploadDocumentUrl), cancellationToken);
            return response;
        }

        public async Task<FetchDocumentsListResponse> FetchDocumentsList(FetchDocumentsListRequest request, string? token, CancellationToken cancellationToken)
        {
            ClientV1 v1 = new ClientV1(httpClient, true, token ?? string.Empty);
            var response = await v1.PostAync<FetchDocumentsListRequest, FetchDocumentsListResponse>(request, string.Concat(_apiUrls.HprDoctorBaseUrl, _apiUrls.FetchDocumentsListUrl), cancellationToken);
            return response;
        }
    }
}

