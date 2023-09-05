using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using Drona.AyushmanBharat.Domain.Entities.ABDM.HPR;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Drona.AyushmanBharat.Application.Features.HPR.Commands.AddGenerateMobileOtp
{
    internal class GenerateMobileOtpCommandHandler : IRequestHandler<GenerateMobileOtpCommand, int>
    {
        private readonly ILogger<GenerateMobileOtpCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IHprRepository _hprRegistory;

        public GenerateMobileOtpCommandHandler(IHprRepository hprRegistory, IMapper mapper, ILogger<GenerateMobileOtpCommandHandler> logger)
        {
            _hprRegistory = hprRegistory ?? throw new ArgumentNullException(nameof(hprRegistory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(GenerateMobileOtpCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Adding ABDM API Response GenerateMobileOtpCommandHandler : {request.TxnId} is successfully created.", request.TxnId);
            var entity = _mapper.Map<HprTransaction>(request);
            var response = await _hprRegistory.AddAsync(entity);
            _logger.LogInformation("ABDM API Response  addded {response.Id} is successfully created.", response.Id);
            return response.Id;
        }
    }
}
