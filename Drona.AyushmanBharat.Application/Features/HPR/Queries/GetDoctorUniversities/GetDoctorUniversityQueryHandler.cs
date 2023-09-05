using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using MediatR;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorUniversities
{
    public class GetDoctorUniversityQueryHandler : IRequestHandler<GetDoctorUniversityQuery, List<DoctorUniversityVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDoctorUniversityQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<DoctorUniversityVm>> Handle(GetDoctorUniversityQuery request, CancellationToken cancellationToken)
        {
            var university = await _unitOfWork.DoctorUniversity.GetAllAsync();
            return _mapper.Map<List<DoctorUniversityVm>>(university);
        }
    }
}
