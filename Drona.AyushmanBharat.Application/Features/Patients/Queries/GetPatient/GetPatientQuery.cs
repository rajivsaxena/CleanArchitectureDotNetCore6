using MediatR;

namespace Drona.AyushmanBharat.Application.Features.Patients.Queries.GetPatient
{
    public class GetPatientQuery : IRequest<PatientVm>
    {
        public string MobileNumber { get; set; }

        public GetPatientQuery(string mobileNumber)
        {
            MobileNumber = mobileNumber ?? throw new ArgumentNullException(nameof(mobileNumber));
        }
    }
}
