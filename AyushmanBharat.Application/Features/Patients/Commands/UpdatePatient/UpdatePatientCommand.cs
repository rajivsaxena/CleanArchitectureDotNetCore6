using MediatR;

namespace AyushmanBharat.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommand : IRequest
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}
