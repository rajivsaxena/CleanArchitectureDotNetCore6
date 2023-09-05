using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using MediatR;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorDegrees
{
    public class GetDoctorDegreeQueryHandler : IRequestHandler<GetDoctorDegreeQuery, List<DoctorDegreeVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDoctorDegreeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<DoctorDegreeVm>> Handle(GetDoctorDegreeQuery request, CancellationToken cancellationToken)
        {
            var degrees = await _unitOfWork.DegreeRepository.GetAllAsync();
            return _mapper.Map<List<DoctorDegreeVm>>(degrees);
        }
    }
}
