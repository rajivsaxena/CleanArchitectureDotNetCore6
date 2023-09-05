using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using MediatR;

namespace Drona.AyushmanBharat.Application.Features.Patients.Queries.GetPatient
{
    public class GetPatientQueryHandler : IRequestHandler<GetPatientQuery, PatientVm>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public GetPatientQueryHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PatientVm> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetPatientByMobileNumber(request.MobileNumber);
            return _mapper.Map<PatientVm>(patient);
        }
    }
}