using AyushmanBharat.Domain.Entities;

namespace AyushmanBharat.Application.Contracts.Persistance
{
    public interface IPatientRepository : IAsyncRepository<Patient>
    {
        Task<Patient?> GetPatientByMobileNumber(string mobileNumber);
    }
}
