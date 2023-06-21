using AyushmanBharat.Application.Features.Patients.Commands.AddPatient;
using AyushmanBharat.Application.Features.Patients.Commands.DeletePatient;
using AyushmanBharat.Application.Features.Patients.Commands.UpdatePatient;
using AyushmanBharat.Application.Features.Patients.Queries.GetPatient;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AyushmanBharat.API.Controllers
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

        [HttpGet("{mobileNumber}", Name = "GetPatientByMobileNumber")]
        [ProducesResponseType(typeof(PatientVm),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<PatientVm>> GetPatient(string mobileNumber)
        {
            var query = new GetPatientQuery(mobileNumber);
            var patient = await _mediator.Send(query);
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
