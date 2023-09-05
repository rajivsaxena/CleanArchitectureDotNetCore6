using MediatR;

namespace Drona.AyushmanBharat.Application.Features.Patients.Commands.AddPatient
{
    public class AddPatientCommand : IRequest<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}
