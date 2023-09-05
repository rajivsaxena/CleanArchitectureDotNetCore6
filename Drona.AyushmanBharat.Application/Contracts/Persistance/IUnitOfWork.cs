using Drona.AyushmanBharat.Domain.Entities.ABDM.HPR.HPRMaster;

namespace Drona.AyushmanBharat.Application.Contracts.Persistance
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<MedicineSystem> MedicineRepository { get; }
        IAsyncRepository<LanguageSpoken> LanguageRepository { get; }
        IAsyncRepository<DoctorDegree> DegreeRepository { get; }
        IAsyncRepository<DoctorCouncil> CouncilRepository { get; }
        public IAsyncRepository<DoctorSpeciality> SpecialityRepository { get; }
        public IAsyncRepository<DoctorUniversity> DoctorUniversity { get; }
        public IAsyncRepository<DoctorCollege> DoctorCollege { get; }
    }
}
