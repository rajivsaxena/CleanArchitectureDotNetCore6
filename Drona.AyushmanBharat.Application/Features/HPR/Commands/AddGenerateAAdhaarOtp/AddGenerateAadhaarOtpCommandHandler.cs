using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using Drona.AyushmanBharat.Domain.Entities.ABDM.HPR;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Drona.AyushmanBharat.Application.Features.HPR.Commands.AddGenerateAAdhaarOtp
{
    internal class AddGenerateAadhaarOtpCommandHandler : IRequestHandler<AddGenerateAadhaarOtpCommand, int>
    {
        private readonly ILogger<AddGenerateAadhaarOtpCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IHprRepository _hprRepository;

        public AddGenerateAadhaarOtpCommandHandler(IHprRepository hprRepository, IMapper mapper, ILogger<AddGenerateAadhaarOtpCommandHandler> logger)
        {
            _hprRepository = hprRepository ?? throw new ArgumentNullException(nameof(hprRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(AddGenerateAadhaarOtpCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Adding ABDM API Response AddGenerateAadhaarOtpCommand : {request.TxnId} is successfully created.", request.TxnId);
            var entity = _mapper.Map<HprTransaction>(request);
            var response = await _hprRepository.AddAsync(entity);
            _logger.LogInformation("ABDM API Response  addded {response.Id} is successfully created.", response.Id);
            return response.Id;
        }
    }
}
