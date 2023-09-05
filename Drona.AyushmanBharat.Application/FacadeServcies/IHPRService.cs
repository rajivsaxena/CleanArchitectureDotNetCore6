using Drona.AyushmanBharat.Application.Models.ABDM.HPR;
using Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument;

namespace Drona.AyushmanBharat.Application.FacadeServcies
{
    public interface IHPRService
    {
        #region Create HPR Id
        public Task<GenerateAadhaarOtpResponse> GenerateAadhaarOTP(GenerateAadhaarOtpRequest generateAadhaarOtpRequest);
        public Task<VerifyAadhaarOtpResponse> VerifyAadhaarOTP(VerifyAadhaarOtpRequest verifyAadhaarOtpRequest);
        public Task<GenerateMobileOtpResponse> GenerateMobileOTP(GenerateMobileOtpRequest generateMobileOtpRequest);
        public Task<VerifyMobileOtpResponse> VerifyMobileOTP(VerifyMobileOtpRequest verifyMobileOtpRequest);
        public Task<CreateHprIdResponse> CreateHPRId(CreateHprIdRequest createHprIdRequest);
        public Task<RegisterProfessionalResponse> RegisterProfessional(RegisterProfessionalRequest registerProfessionalRequest, Guid txnId);
        public Task<SearchUserByHprIdResponse> SearchUserByHprId(SearchUserByHprIdRequest searchUserByHprIdRequest);
        public Task<ICollection<string>> GetHprIdSuggestion(GetHprIdSuggestionRequest getHprIdSuggestionRequest);
        public Task<GetProfessionalInformationResponse> FetchProfessionalInformation(GetProfessionalInformationRequest getProfessionalInformationRequest);
        #endregion

        #region Upload Document Region 
        public Task<AccessTokenResponse> LoginViaPassword(LoginViaPasswordRequest loginViaPasswordRequest);
        public Task<LoginViaMobileSendOTPResponse> LoginViaMobileSendOTP(LoginViaMobileSendOTPRequest loginViaMobileSendOTPRequest);
        public Task<LoginViaMobileVerifyOtpResponse> LoginViaMobileVerifyOTP(LoginViaMobileVerifyOtpRequest request);
        public Task<AccessTokenResponse> LoginWithHRPId(LoginwithHprIdRequest request);
        public Task<LoginViaAadhaarSendOTPResponse> LoginViaAadharSendOTP(LoginViaAadhaarSendOTPRequest LoginViaAadhaarSendOTPRequest);
        public Task<AccessTokenResponse> LoginViaAadharVerifyOtp(LoginViaAadharVerifyOtpRequest request);
        public Task<FetchProfessionalInfoResponse> FetchProfessionalInfo(FetchProfessionalInfoRequest request);
        public Task<UploadDocumentResponse> UploadDocument(UploadDocumentRequest request);
        public Task<FetchDocumentsListResponse> FetchDocumentsList(FetchDocumentsListRequest request);
        #endregion
    }
}
