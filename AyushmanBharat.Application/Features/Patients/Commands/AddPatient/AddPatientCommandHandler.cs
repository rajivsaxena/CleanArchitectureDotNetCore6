using AutoMapper;
using AyushmanBharat.Application.Contracts.Infrastructure;
using AyushmanBharat.Application.Contracts.Persistance;
using AyushmanBharat.Application.Models;
using AyushmanBharat.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AyushmanBharat.Application.Features.Patients.Commands.AddPatient
{
    public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, int>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddPatientCommand> _logger;

        public AddPatientCommandHandler(IPatientRepository patientRepository, IMapper mapper, IEmailService emailService, ILogger<AddPatientCommand> logger)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            var patientEntity = _mapper.Map<Patient>(request);
            var newPatient = await _patientRepository.AddAsync(patientEntity);
            _logger.LogInformation("Patient {newPatient.Id} is successfully created.", newPatient.Id);
            await SendMail(newPatient);
            return newPatient.Id;
        }

        private async Task SendMail(Patient patient)
        {
            var email = new Email { To = patient.EmailAddress, Body = $"Patient added successfully.", Subject = "ABHA Number Created Successfully" };
            try
            {
                await _emailService.SendEmailAsync(email);
            }
            catch (Exception ex)
            {
                _logger.LogError("Patient {0} email failed due to error with email service : {1}", patient.Id, ex.Message);

            }
        }
    }
}
