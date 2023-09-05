using Drona.AyushmanBharat.Application.Contracts.Persistance;
using Drona.AyushmanBharat.Domain.Entities.ABDM.HPR.HPRMaster;
using Drona.AyushmanBharat.Infrastructure.Persistance;

namespace Drona.AyushmanBharat.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;
        public UnitOfWork(ApplicationDbContext _context)
        {
            context = _context;
        }
        private IAsyncRepository<MedicineSystem>? medicineRepository;
        private IAsyncRepository<LanguageSpoken>? languageRepository;
        private IAsyncRepository<DoctorDegree>? degreeRepository;
        private IAsyncRepository<DoctorCouncil>? councilRepository;
        private IAsyncRepository<DoctorSpeciality>? specialityRepository;
        private IAsyncRepository<DoctorUniversity>? universityRepository { get; }
        private IAsyncRepository<DoctorCollege>? collegeRepository { get; }
        public IAsyncRepository<MedicineSystem> MedicineRepository => medicineRepository ?? new RepositoryBase<MedicineSystem>(context);

        public IAsyncRepository<LanguageSpoken> LanguageRepository => languageRepository ?? new RepositoryBase<LanguageSpoken>(context);

        public IAsyncRepository<DoctorDegree> DegreeRepository => degreeRepository ?? new RepositoryBase<DoctorDegree>(context);

        public IAsyncRepository<DoctorCouncil> CouncilRepository => councilRepository ?? new RepositoryBase<DoctorCouncil>(context);

        public IAsyncRepository<DoctorSpeciality> SpecialityRepository => specialityRepository ?? new RepositoryBase<DoctorSpeciality>(context);

        public IAsyncRepository<DoctorUniversity> DoctorUniversity => universityRepository ?? new RepositoryBase<DoctorUniversity>(context);
        public IAsyncRepository<DoctorCollege> DoctorCollege => collegeRepository ?? new RepositoryBase<DoctorCollege>(context);

        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (context != null) context.Dispose();
                }

                // free unmanaged resources (unmanaged objects) and overrided a finalizer below.
                //set large fields to null.

                disposedValue = true;
                medicineRepository = null;
                languageRepository = null;
                degreeRepository = null;
                councilRepository = null;
            }
        }

        // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~UnitOfWork()
        {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // comment the following line if the finalizer is not overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}