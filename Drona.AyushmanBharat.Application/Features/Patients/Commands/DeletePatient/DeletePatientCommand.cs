using MediatR;

namespace Drona.AyushmanBharat.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommand : IRequest
    {
        public int Id { get; set; }
    }
}
