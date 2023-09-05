using MediatR;

namespace Drona.AyushmanBharat.Application.Features.HPR.Queries.GetAadhaarOtp
{
    public class GetAadhaarOtpQuery : IRequest<AadhaarOtpResponseVm>
    {
        public int id { get; set; }

        public GetAadhaarOtpQuery(int _id)
        {
            id = _id;
        }
    }
}
