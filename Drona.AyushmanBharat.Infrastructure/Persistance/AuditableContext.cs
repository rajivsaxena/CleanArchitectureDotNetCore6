using Drona.AyushmanBharat.Application.Models;
using Drona.AyushmanBharat.Domain.Common;
using Drona.AyushmanBharat.Domain.Common.Enum;
using Microsoft.EntityFrameworkCore;


namespace Drona.AyushmanBharat.Infrastructure.Persistance
{
    public abstract class AuditableContext : DbContext
    {
        public AuditableContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Audit>? AuditLogs { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private void OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
#pragma warning disable CS8601 // Possible null reference assignment.
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.UserId = "1"; //todo : need to get it from request;
                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
#pragma warning restore CS8601 // Possible null reference assignment.
            foreach (var auditEntry in auditEntries)
            {
                if (AuditLogs != null)
                    AuditLogs.Add(auditEntry.ToAudit());
            }
        }
    }
}
