using MediatR;

namespace Drona.AyushmanBharat.Application.Features.HPR.Commands.AddVerifyMobileOtp
{
    public class AddVerifyMobileOtpCommand : IRequest<int>
    {
        public Guid? TxnId { get; set; }
        
        public string? MobileNumber { get; set; }

        public int ProgressStep { get; set; }
    }
}
