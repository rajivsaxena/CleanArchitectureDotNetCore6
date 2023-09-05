using Microsoft.EntityFrameworkCore;
using Drona.AyushmanBharat.Application.Contracts.Persistance;
using Drona.AyushmanBharat.Domain.Entities;
using Drona.AyushmanBharat.Infrastructure.Persistance;

namespace Drona.AyushmanBharat.Infrastructure.Repositories
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
#pragma warning disable CS8604 // Possible null reference argument.
            Patient? patient = await _dbContext.Patient.Where(x => x.MobileNumber == mobileNumber).FirstOrDefaultAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            return patient;
        }
    }
}
