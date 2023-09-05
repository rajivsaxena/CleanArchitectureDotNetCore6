using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using MediatR;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Drona.AyushmanBharat.Application.Features.HPR.Queries.GetLanguages
{
    public class GetLanguageQueryHandler : IRequestHandler<GetLanguageQuery, List<LanguageVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLanguageQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)

        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<LanguageVm>> Handle(GetLanguageQuery request, CancellationToken cancellationToken)
        {
            var languages = await _unitOfWork.LanguageRepository.GetAllAsync();
            return _mapper.Map<List<LanguageVm>>(languages);
        }
    }
}
