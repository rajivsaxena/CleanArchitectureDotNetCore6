using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using MediatR;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorSpecialities
{
    public class GetDoctorSpecialityQueryHandler : IRequestHandler<GetDoctorSpecialityQuery, List<DoctorSpecialityVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDoctorSpecialityQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<DoctorSpecialityVm>> Handle(GetDoctorSpecialityQuery request, CancellationToken cancellationToken)
        {
            var councils = await _unitOfWork.SpecialityRepository.GetAllAsync();
            return _mapper.Map<List<DoctorSpecialityVm>>(councils);
        }
    }
}
