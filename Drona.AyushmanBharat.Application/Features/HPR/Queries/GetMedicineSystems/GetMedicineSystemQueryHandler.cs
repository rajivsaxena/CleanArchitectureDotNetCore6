using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using MediatR;

namespace Drona.AyushmanBharat.Application.Features.HPR.Queries.GetMedicineSystems
{
    public class GetMedicineSystemQueryHandler : IRequestHandler<GetMedicineSystemQuery, List<MedicineSystemVm>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMedicineSystemQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<MedicineSystemVm>> Handle(GetMedicineSystemQuery request, CancellationToken cancellationToken)
        {
            var medicineSystems = await _unitOfWork.MedicineRepository.GetAllAsync();
            return _mapper.Map<List<MedicineSystemVm>>(medicineSystems);
        }
    }
}
