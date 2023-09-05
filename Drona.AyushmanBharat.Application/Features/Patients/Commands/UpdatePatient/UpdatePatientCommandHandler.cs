using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using Drona.AyushmanBharat.Application.Exceptions;
using Drona.AyushmanBharat.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Drona.AyushmanBharat.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePatientCommandHandler> _logger;

        public UpdatePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, ILogger<UpdatePatientCommandHandler> logger)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patientToUpate = await _patientRepository.GetByIdAsync(request.Id);
            if (patientToUpate == null)
            {
                throw new NotFoundException(nameof(Patient), request.Id);
            }
            _mapper.Map(request, patientToUpate, typeof(UpdatePatientCommand), typeof(Patient));
            await _patientRepository.UpdateAsync(patientToUpate);
            _logger.LogInformation("Patient {0} updated successfully.", patientToUpate.Id);
            return Unit.Value;
        }
    }
}
