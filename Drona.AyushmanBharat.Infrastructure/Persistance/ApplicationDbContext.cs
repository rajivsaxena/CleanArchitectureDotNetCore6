using Drona.AyushmanBharat.Domain.Common;
using Drona.AyushmanBharat.Domain.Entities;
using Drona.AyushmanBharat.Domain.Entities.ABDM.HPR;
using Drona.AyushmanBharat.Domain.Entities.ABDM.HPR.HPRMaster;
using Microsoft.EntityFrameworkCore;


namespace Drona.AyushmanBharat.Infrastructure.Persistance
{
    public class ApplicationDbContext : AuditableContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Patient>? Patient { get; set; }
        public DbSet<HprTransaction>? HprTransaction { get; set; }

        public DbSet<RegisterProfessionalDto>? registerProfessionalDtos { get; set; }

        public DbSet<LanguageSpoken> LanguageSpokens { get; set; }

        public DbSet<Country>? Countries { get; set; }

        public DbSet<MedicineSystem>? MedicineSystems { get; set; }

        public DbSet<DoctorCouncil>? DoctorCouncils { get; set; }

        public DbSet<DoctorDegree> DoctorDegree { get; set; }

        public DbSet<DoctorSpeciality> DoctorSpecialities { get; set; }

        public DbSet<DoctorUniversity> DoctorUniversities { get; set; }

        public DbSet<DoctorCollege> DoctorColleges { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        //todo : Created by needs to be get from Identity User
                        entry.Entity.CreatedBy = "Drona User";
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now;
                        //todo : Modified by needs to be get from Identity User
                        entry.Entity.ModifiedBy = "Drona User";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
