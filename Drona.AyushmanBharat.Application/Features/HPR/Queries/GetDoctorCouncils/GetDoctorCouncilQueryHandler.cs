using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using MediatR;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorCouncils
{
    public class GetDoctorCouncilQueryHandler : IRequestHandler<GetDoctorCouncilQuery, List<DoctorCouncilVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDoctorCouncilQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<DoctorCouncilVm>> Handle(GetDoctorCouncilQuery request, CancellationToken cancellationToken)
        {
            var councils = await _unitOfWork.CouncilRepository.GetAllAsync();
            return _mapper.Map<List<DoctorCouncilVm>>(councils);
        }
    }
}
