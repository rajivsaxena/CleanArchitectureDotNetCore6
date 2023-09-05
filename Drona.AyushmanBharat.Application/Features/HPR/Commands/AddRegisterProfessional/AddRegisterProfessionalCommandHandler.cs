using AutoMapper;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using Drona.AyushmanBharat.Domain.Entities.ABDM.HPR;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
namespace Drona.AyushmanBharat.Application.Features.HPR.Commands.AddRegisterProfessional
{
    public class AddRegisterProfessionalCommandHandler : IRequestHandler<AddRegisterProfessionalCommand,int>
    {
        private readonly ILogger<AddRegisterProfessionalCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IHprRegisterProfessionalRepository _hprRegisterProfessionalRegistory;

        public AddRegisterProfessionalCommandHandler(IHprRegisterProfessionalRepository hprRegisterProfessionalRegistory, IMapper mapper, ILogger<AddRegisterProfessionalCommandHandler> logger)
        {
            _hprRegisterProfessionalRegistory = hprRegisterProfessionalRegistory ?? throw new ArgumentNullException(nameof(_hprRegisterProfessionalRegistory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<int> Handle(AddRegisterProfessionalCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Adding ABDM API Response AddRegisterProfessionalCommandHandler : {request.TxnId} is successfully created.");
            var entity = _mapper.Map<RegisterProfessionalDto>(request);
            var response = await _hprRegisterProfessionalRegistory.AddAsync(entity);
            _logger.LogInformation("ABDM API Response  addded {response.Id} is successfully created.", response.Id);
            return response.Id;
        }
    }
}
