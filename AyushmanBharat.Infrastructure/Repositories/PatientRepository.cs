using Microsoft.EntityFrameworkCore;
using AyushmanBharat.Application.Contracts.Persistance;
using AyushmanBharat.Domain.Entities;
using AyushmanBharat.Infrastructure.Persistance;

namespace AyushmanBharat.Infrastructure.Repositories
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            if (dbContext is null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
        }
        public async Task<Patient?> GetPatientByMobileNumber(string mobileNumber)
        {
            Patient? patient = await _dbContext.Patient.Where(x => x.MobileNumber == mobileNumber).FirstOrDefaultAsync();
            return patient;
        }
    }
}
