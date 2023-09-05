using MediatR;

namespace Drona.AyushmanBharat.Application.Features.HPR.Commands.AddRegisterProfessional
{
    public class AddRegisterProfessionalCommand : IRequest<int>
    {
        public Guid? TxnId { get; set; }
        public string? ReferenceNumber { get; set; }
        public bool Status { get; set; }
        public string? HprId { get; set; }
        public string? Message { get; set; }
    }
}
