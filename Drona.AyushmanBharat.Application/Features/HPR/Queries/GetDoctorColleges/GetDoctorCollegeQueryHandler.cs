using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using MediatR;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorColleges
{
    public class GetDoctorCollegeQueryHandler : IRequestHandler<GetDoctorCollegeQuery, List<DoctorCollegeVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDoctorCollegeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<DoctorCollegeVm>> Handle(GetDoctorCollegeQuery request, CancellationToken cancellationToken)
        {
            var colleges = await _unitOfWork.DoctorCollege.GetAllAsync();
            return _mapper.Map<List<DoctorCollegeVm>>(colleges);
        }
    }
}
