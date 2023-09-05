using AutoMapper;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorColleges;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorCouncils;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorDegrees;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorSpecialities;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorUniversities;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetLanguages;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetMedicineSystems;
using Drona.AyushmanBharat.Domain.Entities.ABDM.HPR.HPRMaster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Drona.AyushmanBharat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HprMasterDataController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HprMasterDataController> _logger;
        public HprMasterDataController(IMediator mediator, ILogger<HprMasterDataController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("GetAllLanguages")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<LanguageVm>>> GetAllLanguages()
        {
            var query = new GetLanguageQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetAllMedicineSysytems")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<MedicineSystemVm>>> GetAllMedicineSystems()
        {
            var query = new GetMedicineSystemQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetAllDoctorCouncils")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DoctorCouncilVm>>> GetAllCouncils()
        {
            var query = new GetDoctorCouncilQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetAllDoctorDegrees")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DoctorDegreeVm>>> GetAllDoctorDegrees()
        {
            var query = new GetDoctorDegreeQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetSubcategories")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DoctorSpecialityVm>>> GetSubcategories()
        {
            var query = new GetDoctorSpecialityQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetDoctorUnivesities")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DoctorUniversity>>> GetDoctorUnivesities()
        {
            var query = new GetDoctorUniversityQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetDoctorColleges")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<DoctorCollegeVm>>> GetDoctorColleges()
        {
            var query = new GetDoctorCollegeQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
