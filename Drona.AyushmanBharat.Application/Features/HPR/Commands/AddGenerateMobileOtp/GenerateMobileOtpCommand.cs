using MediatR;

namespace Drona.AyushmanBharat.Application.Features.HPR.Commands.AddGenerateMobileOtp
{
    public class GenerateMobileOtpCommand : IRequest<int>
    {
        public Guid? TxnId { get; set; }
        
        public string? MobileNumber { get; set; }

        public int ProgressStep { get; set; }
    }
}
