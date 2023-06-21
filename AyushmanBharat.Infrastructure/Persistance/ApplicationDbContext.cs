using AyushmanBharat.Domain.Common;
using AyushmanBharat.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AyushmanBharat.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Patient>? Patient { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        //todo : Created by needs to be get from Identity User
                        entry.Entity.CreatedBy = "Rajiv";
                        break;

                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now;
                        //todo : Modified by needs to be get from Identity User
                        entry.Entity.ModifiedBy = "Rajiv";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
