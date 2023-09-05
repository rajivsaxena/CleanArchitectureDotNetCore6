using Drona.AyushmanBharat.Application.FacadeServcies;
using Drona.AyushmanBharat.Application.Models.ABDM.HPR;
using Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Drona.AyushmanBharat.API.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class HPRUploadDocumentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHPRService _hprService;
        public HPRUploadDocumentController(IMediator mediator, IHPRService hprService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _hprService = hprService ?? throw new ArgumentNullException(nameof(hprService));
        }

        #region Login with Password

        [HttpPost("LoginViaPassword")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AccessTokenResponse>> LoginViaPassword(LoginViaPasswordRequest loginViaPasswordRequest)
        {
            var result =  await _hprService.LoginViaPassword(loginViaPasswordRequest);
            return Ok(result);
        }

        #endregion

        #region Login With Mobile

        [HttpPost("LoginViaMobileSendOTP")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<LoginViaMobileSendOTPResponse>> LoginViaMobileSendOTP([FromBody] LoginViaMobileSendOTPRequest loginViaMobileSendOTPRequest)
        {
            var result = await _hprService.LoginViaMobileSendOTP(loginViaMobileSendOTPRequest);
            return Ok(result);
        }

        [HttpPost("LoginViaMobileVerifyOTP")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<LoginViaMobileVerifyOtpResponse>> loginViaMobileVerifyOTP([FromBody] LoginViaMobileVerifyOtpRequest request)
        {
            var result = await _hprService.LoginViaMobileVerifyOTP(request);
            return Ok(result);
        }

        [HttpPost("LoginWithHPRId")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<GatewayToken>> LoginWithHPRId([FromBody] LoginwithHprIdRequest request)
        {
            var result = await _hprService.LoginWithHRPId(request);
            return Ok(result);
        }

        #endregion

        #region Login With Aadhaar

        [HttpPost("LoginViaAadharSendOTP")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<LoginViaAadhaarSendOTPResponse>> LoginViaAadharSendOTP([FromBody] LoginViaAadhaarSendOTPRequest loginViaAadhaarSendOTPRequest)
        {
            var result = await _hprService.LoginViaAadharSendOTP(loginViaAadhaarSendOTPRequest);
            return Ok(result);
        }

        [HttpPost("LoginViaAadharVerifyOtp")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<GatewayToken>> LoginViaAadharVerifyOtp([FromBody] LoginViaAadharVerifyOtpRequest request)
        {
            var result = await _hprService.LoginViaAadharVerifyOtp(request);
            return Ok(result);
        }

        #endregion

        [HttpPost("FetchProfessionalInfo")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<FetchProfessionalInfoResponse>> FetchProfessionalInfo([FromBody] FetchProfessionalInfoRequest request)
        {
            var result = await _hprService.FetchProfessionalInfo(request);
            return Ok(result);
        }

        [HttpPost("UploadDocument")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<UploadDocumentResponse>> UploadDocument([FromBody] UploadDocumentRequest request)
        {
            var result = await _hprService.UploadDocument(request);
            return Ok(result);
        }

        [HttpPost("FetchDocumentsList")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<FetchDocumentsListResponse>> FetchDocumentsList([FromBody] FetchDocumentsListRequest request)
        {
            var result = await _hprService.FetchDocumentsList(request);
            return Ok(result);
        }
    }
}
