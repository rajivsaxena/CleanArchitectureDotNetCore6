using AyushmanBharat.Domain.Entities;
using AyushmanBharat.Infrastructure.Persistance;
using Microsoft.Extensions.Logging;


namespace AyushmanBharat.Infrastructure.Persistance
{
    public class PatientContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext, ILogger<PatientContextSeed> logger)
        {
            if (dbContext.Patient != null)
            {
                dbContext.AddRange(GetPreconfiguredPatient());
                await dbContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationDbContext).Name);
            }
        }

        private static Patient GetPreconfiguredPatient()
        {
            return new Patient { FirstName = "Rajiv", LastName ="Saxena", MobileNumber ="9911442686"};
        }
    }
}

