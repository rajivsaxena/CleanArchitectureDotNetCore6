using Drona.AyushmanBharat.Application.Contracts.Persistance;
using Drona.AyushmanBharat.Domain.Entities.ABDM.HPR;
using Drona.AyushmanBharat.Infrastructure.Persistance;

namespace Drona.AyushmanBharat.Infrastructure.Repositories
{
    public class HprRegisterProfessionalRepository : RepositoryBase<RegisterProfessionalDto>, IHprRegisterProfessionalRepository
    {
        public HprRegisterProfessionalRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            if (dbContext is null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
        }
    }
}
