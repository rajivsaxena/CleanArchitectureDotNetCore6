using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using MediatR;

namespace Drona.AyushmanBharat.Application.Features.HPR.Queries.GetAadhaarOtp
{
    public class GetAadhaarOtpQueryHandler : IRequestHandler<GetAadhaarOtpQuery, AadhaarOtpResponseVm>
    {
        private readonly IHprRepository _repository;
        private readonly IMapper _mapper;

        public GetAadhaarOtpQueryHandler(IHprRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AadhaarOtpResponseVm> Handle(GetAadhaarOtpQuery request, CancellationToken cancellationToken)
        {
            var patient = await _repository.GetByIdAsync(request.id);
            return _mapper.Map<AadhaarOtpResponseVm>(patient);
        }
    }
}
