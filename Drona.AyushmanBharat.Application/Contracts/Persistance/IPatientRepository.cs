using Drona.AyushmanBharat.Domain.Entities;

namespace Drona.AyushmanBharat.Application.Contracts.Persistance
{
    public interface IPatientRepository : IAsyncRepository<Patient>
    {
        Task<Patient?> GetPatientByMobileNumber(string mobileNumber);
    }
}
