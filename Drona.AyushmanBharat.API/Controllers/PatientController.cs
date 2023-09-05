using Drona.AyushmanBharat.API.Factories;
using Drona.AyushmanBharat.Application.Features.Patients.Commands.AddPatient;
using Drona.AyushmanBharat.Application.Features.Patients.Commands.DeletePatient;
using Drona.AyushmanBharat.Application.Features.Patients.Commands.UpdatePatient;
using Drona.AyushmanBharat.Application.Features.Patients.Queries.GetPatient;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Drona.AyushmanBharat.API.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetPatientByMobileNumber")]
        [ProducesResponseType(typeof(PatientVm),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<PatientVm>> GetPatient(string mobileNumber)
        {
            var query = new GetPatientQuery(mobileNumber);
            var patient = await _mediator.Send(query);

            string jwtToken = JwtTokenGenerator.GenerateJwtToken("MyClaim").Result;
            Response.Headers.Add("Authorization", "Bearer " + jwtToken);
            return Ok(patient);
        }
        
        [HttpPost(Name = "AddPatient")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddPatient([FromBody]AddPatientCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdatePatient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePatient([FromBody] UpdatePatientCommand command)
        {
            var result = await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePatient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var command = new DeletePatientCommand() { Id=id};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
