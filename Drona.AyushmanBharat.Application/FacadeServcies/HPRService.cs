using Drona.AyushmanBharat.Application.Contracts.Infrastructure.ABDM.HealthProfessionalRegistory;
using Drona.AyushmanBharat.Application.Contracts.StateManagement;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddGenerateAAdhaarOtp;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddGenerateMobileOtp;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddHprId;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddRegisterProfessional;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddVerifyAadhaarOtp;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddVerifyMobileOtp;
using Drona.AyushmanBharat.Application.Models.ABDM.HPR;
using Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Drona.AyushmanBharat.Application.FacadeServcies
{
    public class HPRService : IHPRService
    {
        private readonly IHealthProfessionalRegistory _healthProfessionalRegistory;
        private readonly IMediator _mediator;
        private readonly ICacheProvider _cache;
        private readonly ILogger<HPRService> _logger;

        public HPRService(IHealthProfessionalRegistory healthProfessionalRegistory, IMediator mediator, ICacheProvider cache, ILogger<HPRService> logger)
        {
            _healthProfessionalRegistory = healthProfessionalRegistory ?? throw new ArgumentNullException(nameof(healthProfessionalRegistory));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private async Task<string> GetAccessToken(CancellationToken cancellationToken, bool flushrequired = false)
        {
            string accessToken = string.Empty;
            // state 1. call cache to find token for subsequent requests
            //todo : clean the cache and add new one
            try
            {
                if (flushrequired)
                {
                    bool flusedAll = _cache.FlushAll();
                }
                var token = await _cache.Execute("HPRGatewayTokenDev", () => this.GenerateGatewayToken(cancellationToken));

                // todo: if not null, check for token expiry and generate new token if expired
                if (token != null)
                {
                    accessToken = token.AccessToken ?? string.Empty;
                }
                return accessToken;
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAccessToken : {ex.Message}");
                throw;
            }
        }

        #region Create HPR ID Region

        public async Task<GenerateAadhaarOtpResponse> GenerateAadhaarOTP(GenerateAadhaarOtpRequest generateAadhaarOtpRequest)
        {
            try
            {
                CancellationTokenSource tokenSource = new CancellationTokenSource();

                string accessToken = await GetAccessToken(tokenSource.Token, true);

                if (string.IsNullOrEmpty(accessToken))
                {
                    throw new ArgumentNullException(nameof(accessToken));
                }

                // state 2. Call ABDM API - generateOTP
                var result = await _healthProfessionalRegistory.GenerateAadhaarOTP(generateAadhaarOtpRequest, accessToken, tokenSource.Token);
                
                // do not save data into db if there is some error
                if(result.Code != null)
                {
                    return result;
                }

                // state 2. Save the response in DB if there is no error
                //Mapping profile should be present to map domain entities with application entities
                AddGenerateAadhaarOtpCommand command = new AddGenerateAadhaarOtpCommand() { MobileNumber = result.MobileNumber, TxnId = result.TxnId, ProgressStep = 2 };
                int insertedId = await _mediator.Send(command);
                if (insertedId < 0)
                {
                    _logger.LogError($"Error while executing command : {command} : received txnId  : {result.TxnId} ");
                    // throw new Exception("Error while adding GenerateAadhaarOTP response in database.");   
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception HPRService : GenerateAadhaarOTP  {ex.Message}, Stack trace : {ex.StackTrace}");
                throw;
            }
        }

        public async Task<VerifyAadhaarOtpResponse> VerifyAadhaarOTP(VerifyAadhaarOtpRequest verifyAadhaarOtpRequest)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            // state 1. call cache to find token for subsequent requests
            string accessToken = await GetAccessToken(tokenSource.Token);

            // state 1. Call ABHM API - verifyOTP
            var result = await _healthProfessionalRegistory.VerifyAadhaarOTP(verifyAadhaarOtpRequest, accessToken, tokenSource.Token);
            
            VerifyAadhaarOtpCommand command = new VerifyAadhaarOtpCommand() { MobileNumber = result.MobileNumber, TxnId = result.TxnId, ProgressStep = 3 };
            // state 2. add/update the response in db
            int insertedId = await _mediator.Send(command);
            return result;
        }

        public async Task<GenerateMobileOtpResponse> GenerateMobileOTP(GenerateMobileOtpRequest generateMobileOtpRequest)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            // state 1. Call ABHM API - generateMobileOTP
            var result = await _healthProfessionalRegistory.GenerateMobileOTP(generateMobileOtpRequest, accessToken, tokenSource.Token);
            GenerateMobileOtpCommand command = new GenerateMobileOtpCommand() { MobileNumber = result.MobileNumber, TxnId = result.TxnId, ProgressStep = 4 };
            // state 2. add/update the response in db
            int insertedId = await _mediator.Send(command);
            return result;
        }

        public async Task<VerifyMobileOtpResponse> VerifyMobileOTP(VerifyMobileOtpRequest verifyMobileOtpResponse)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            // state 1. Call ABHM API - generateMobileOTP
            var result = await _healthProfessionalRegistory.VerifyMobileOTP(verifyMobileOtpResponse, accessToken, tokenSource.Token);
            AddVerifyMobileOtpCommand command = new AddVerifyMobileOtpCommand { MobileNumber = result.MobileNumber, TxnId = result.TxnId, ProgressStep = 5 };
            // state 2. add/update the response in db
            int insertedId = await _mediator.Send(command);
            return result;
        }

        public async Task<CreateHprIdResponse> CreateHPRId(CreateHprIdRequest createHprIdRequest)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            var result = await _healthProfessionalRegistory.CreateHPRId(createHprIdRequest, accessToken, tokenSource.Token);
            CreateHprIdCommand command = new CreateHprIdCommand { MobileNumber = null, TxnId = createHprIdRequest.TxnId, ProgressStep = 6 };
            // state 2. add/update the response in db
            int insertedId = await _mediator.Send(command);
            return result;
        }

        public async Task<RegisterProfessionalResponse> RegisterProfessional(RegisterProfessionalRequest request, Guid txnId)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            var result = await _healthProfessionalRegistory.RegisterProfessional(request, accessToken, tokenSource.Token);
            AddRegisterProfessionalCommand command = new AddRegisterProfessionalCommand()
            {
                TxnId = txnId,
                HprId = result.HprId,
                Message = result.Message,
                ReferenceNumber = result.ReferenceNumber,
                Status = result.Status,

            };
            // state 2. add/update the response in db
            int insertedId = await _mediator.Send(command);
            return result;
        }

        public async Task<SearchUserByHprIdResponse> SearchUserByHprId(SearchUserByHprIdRequest request)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.SearchUserByHprId(request, accessToken, tokenSource.Token);
        }

        public async Task<ICollection<string>> GetHprIdSuggestion(GetHprIdSuggestionRequest request)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.GetHprIdSuggestion(request, accessToken, tokenSource.Token);
        }

        public async Task<GetProfessionalInformationResponse> FetchProfessionalInformation(GetProfessionalInformationRequest request)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.FetchProfessionalInformation(request, accessToken, tokenSource.Token);
        }

        private async Task<GatewayToken> GenerateGatewayToken(CancellationToken cancellationToken)
        {
            try
            {
                var tokenObj = await _healthProfessionalRegistory.GenerateGatewayToken(cancellationToken);
                if (tokenObj == null)
                    throw new Exception("Not able to generate token from ABDM API.");
                return tokenObj;
            }
            catch (Exception ex)
            {
                _logger.LogError($"HPRService : GenerateGatewayToken {ex.Message} stack trace {ex.StackTrace}");
                throw;
            }
        }

        #endregion

        #region Upload Document Region
        public async Task<AccessTokenResponse> LoginViaPassword(LoginViaPasswordRequest loginViaPasswordRequest)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.LoginViaPassword(loginViaPasswordRequest, accessToken, tokenSource.Token);
        }

        public async Task<LoginViaMobileSendOTPResponse> LoginViaMobileSendOTP(LoginViaMobileSendOTPRequest loginViaMobileSendOTPRequest)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.LoginViaMobileSendOTP(loginViaMobileSendOTPRequest, accessToken, tokenSource.Token);
        }

        public async Task<LoginViaMobileVerifyOtpResponse> LoginViaMobileVerifyOTP(LoginViaMobileVerifyOtpRequest request)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.LoginViaMobileVerifyOTP(request, accessToken, tokenSource.Token);
        }

        public async Task<AccessTokenResponse> LoginWithHRPId(LoginwithHprIdRequest request)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.LoginWithHRPId(request, accessToken, tokenSource.Token);
        }

        public async Task<LoginViaAadhaarSendOTPResponse> LoginViaAadharSendOTP(LoginViaAadhaarSendOTPRequest LoginViaAadhaarSendOTPRequest)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.LoginViaAadharSendOTP(LoginViaAadhaarSendOTPRequest, accessToken, tokenSource.Token);
        }

        public async Task<AccessTokenResponse> LoginViaAadharVerifyOtp(LoginViaAadharVerifyOtpRequest request)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.LoginViaAadharVerifyOtp(request, accessToken, tokenSource.Token);
        }

        public async Task<FetchProfessionalInfoResponse> FetchProfessionalInfo(FetchProfessionalInfoRequest request)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.FetchProfessionalInfo(request, accessToken, tokenSource.Token);
        }

        public async Task<UploadDocumentResponse> UploadDocument(UploadDocumentRequest request)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.UploadDocument(request, accessToken, tokenSource.Token);
        }

        public async Task<FetchDocumentsListResponse> FetchDocumentsList(FetchDocumentsListRequest request)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            string accessToken = await GetAccessToken(tokenSource.Token);
            return await _healthProfessionalRegistory.FetchDocumentsList(request, accessToken, tokenSource.Token);
        }
        #endregion
    }
}