using Drona.AyushmanBharat.API.Factories;
using Drona.AyushmanBharat.Application.FacadeServcies;
using Drona.AyushmanBharat.Application.Models.ABDM.HPR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Drona.AyushmanBharat.API.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class HPRController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHPRService _hprService;
        public HPRController(IMediator mediator, IHPRService hprService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _hprService = hprService ?? throw new ArgumentNullException(nameof(hprService));
        }

        [HttpPost("GenerateAadhaarOtp")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<GenerateAadhaarOtpResponse>> GenerateAadhaarOtp([FromBody] GenerateAadhaarOtpRequest generateAadhaarOtpRequest)
        {
            var result = await _hprService.GenerateAadhaarOTP(generateAadhaarOtpRequest);
            string jwtToken = JwtTokenGenerator.GenerateJwtToken("MyClaim").Result;
            Response.Headers.Add("Authorization", "Bearer " + jwtToken);
            return Ok(result);
        }

        [HttpPost("VerifyAadhaarOtp")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<VerifyAadhaarOtpResponse>> VerifyAadhaarOtp([FromBody] VerifyAadhaarOtpRequest verifyAadhaarOtpRequest)
        {
            var result = await _hprService.VerifyAadhaarOTP(verifyAadhaarOtpRequest);
            return Ok(result);
        }

        [HttpPost("GenerateMobileOtp")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<GenerateMobileOtpResponse>> GenerateMobileOtp(GenerateMobileOtpRequest generateMobileOtpRequest)
        {
            var result = await _hprService.GenerateMobileOTP(generateMobileOtpRequest);
            return Ok(result);
        }

        [HttpPost("VerifyMobileOtp")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<VerifyMobileOtpResponse>> VerifyMobileOtp(VerifyMobileOtpRequest verifyMobileOtpRequest)
        {
            var result = await _hprService.VerifyMobileOTP(verifyMobileOtpRequest);
            return Ok(result);
        }

        [HttpPost("CreateHprId")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateHprIdResponse>> CreateHprId([FromBody] CreateHprIdRequest createHprIdRequest)
        {
            var result = await _hprService.CreateHPRId(createHprIdRequest);
            return Ok(result);
        }

        [HttpPost("RegisterProfessional")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<RegisterProfessionalResponse>> RegisterProfessional([FromBody] RegisterProfessionalRequest registerProfessionalRequest, Guid txnId)
        {
            var result = await _hprService.RegisterProfessional(registerProfessionalRequest, txnId);
            return Ok(result);
        }

        [HttpPost("SearchUserByHprId")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<SearchUserByHprIdResponse>> SearchUserByHprId([FromBody] SearchUserByHprIdRequest searchUserByHprIdRequest)
        {
            var result = await _hprService.SearchUserByHprId(searchUserByHprIdRequest);
            return Ok(result);
        }

        /// <summary>
        /// Call this api after verifying the aadhaar otp
        /// </summary>
        /// <param name="searchUserByHprIdRequest">txn id</param>
        /// <returns></returns>
        [HttpPost("GetHprIdSuggestion")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ICollection<string>>> GetHprIdSuggestion([FromBody] GetHprIdSuggestionRequest getHprIdSuggestionRequest)
        {
            var result = await _hprService.GetHprIdSuggestion(getHprIdSuggestionRequest);
            return Ok(result);
        }

        /// <summary>
        /// Get Account information
        /// </summary>
        /// <returns></returns>
        [HttpPost("FetchProfessionalInformation")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetProfessionalInformationResponse>> FetchProfessionalInformation([FromBody] GetProfessionalInformationRequest getProfessionalInformationRequest)
        {
            var result = await _hprService.FetchProfessionalInformation(getProfessionalInformationRequest);
            return Ok(result);
        }
    }
}
