using AutoMapper;
using AyushmanBharat.Application.Contracts.Persistance;
using AyushmanBharat.Application.Exceptions;
using AyushmanBharat.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AyushmanBharat.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeletePatientCommandHandler> _logger;

        public DeletePatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, ILogger<DeletePatientCommandHandler> logger)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patientToDelete = await _patientRepository.GetByIdAsync(request.Id);
            if (patientToDelete == null)
            {
                throw new NotFoundException(nameof(Patient), request.Id);
            }

            await _patientRepository.DeleteAsync(patientToDelete);
            _logger.LogInformation("Patient {0} deleted successfully.", patientToDelete.Id);
            return Unit.Value;
        }
    }
}
