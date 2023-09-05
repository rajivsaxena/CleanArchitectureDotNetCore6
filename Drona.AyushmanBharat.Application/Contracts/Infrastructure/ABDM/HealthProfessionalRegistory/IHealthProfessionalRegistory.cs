using Drona.AyushmanBharat.Application.Models.ABDM.HPR;
using Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument;

namespace Drona.AyushmanBharat.Application.Contracts.Infrastructure.ABDM.HealthProfessionalRegistory
{
    //todo : Model classes needs to be created for below methods.
    public interface IHealthProfessionalRegistory
    {
        #region https://sandbox.abdm.gov.in/static/media/RegisterProfessional_HPR_V2_prod02.d0c87f5e.pdf

        public Task<GatewayToken> GenerateGatewayToken(CancellationToken cancellationToken);
        public Task<GenerateAadhaarOtpResponse> GenerateAadhaarOTP(GenerateAadhaarOtpRequest request, string? token, CancellationToken cancellationToken);
        public Task<VerifyAadhaarOtpResponse> VerifyAadhaarOTP(VerifyAadhaarOtpRequest request, string? token, CancellationToken cancellationToken);
        public Task<GenerateMobileOtpResponse> GenerateMobileOTP(GenerateMobileOtpRequest request, string? token, CancellationToken cancellationToken);
        public Task<VerifyMobileOtpResponse> VerifyMobileOTP(VerifyMobileOtpRequest request, string? token, CancellationToken cancellationToken);
        public Task<CreateHprIdResponse> CreateHPRId(CreateHprIdRequest request, string? token, CancellationToken cancellationToken);
        public Task<RegisterProfessionalResponse> RegisterProfessional(RegisterProfessionalRequest request, string? token, CancellationToken cancellationToken);
        public Task<SearchUserByHprIdResponse> SearchUserByHprId(SearchUserByHprIdRequest request, string? token, CancellationToken cancellationToken);
        public Task<ICollection<string>> GetHprIdSuggestion(GetHprIdSuggestionRequest request, string? token, CancellationToken cancellationToken);
        public Task<GetProfessionalInformationResponse> FetchProfessionalInformation(GetProfessionalInformationRequest request, string? token, CancellationToken cancellationToken);
        #endregion

        #region Upload Document

        public Task<AccessTokenResponse> LoginViaPassword(LoginViaPasswordRequest loginViaPasswordRequest, string? token, CancellationToken cancellationToken);
        public Task<LoginViaMobileSendOTPResponse> LoginViaMobileSendOTP(LoginViaMobileSendOTPRequest loginViaMobileSendOTPRequest, string? token, CancellationToken cancellationToken);
        public Task<LoginViaMobileVerifyOtpResponse> LoginViaMobileVerifyOTP(LoginViaMobileVerifyOtpRequest loginViaMobileVerifyOtpRequest, string? token, CancellationToken cancellationToken);
        public Task<AccessTokenResponse> LoginWithHRPId(LoginwithHprIdRequest request, string? token, CancellationToken cancellationToken);
        public Task<LoginViaAadhaarSendOTPResponse> LoginViaAadharSendOTP(LoginViaAadhaarSendOTPRequest loginViaAadhaarSendOTPRequest, string? token, CancellationToken cancellationToken);
        public Task<AccessTokenResponse> LoginViaAadharVerifyOtp(LoginViaAadharVerifyOtpRequest request, string? token, CancellationToken cancellationToken);
        public Task<FetchProfessionalInfoResponse> FetchProfessionalInfo(FetchProfessionalInfoRequest request, string? token, CancellationToken cancellationToken);
        public Task<UploadDocumentResponse> UploadDocument(UploadDocumentRequest request, string? token, CancellationToken cancellationToken);
        public Task<FetchDocumentsListResponse> FetchDocumentsList(FetchDocumentsListRequest request, string? token, CancellationToken cancellationToken);
        #endregion
    }
}
