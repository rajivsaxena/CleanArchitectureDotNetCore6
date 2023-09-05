using Drona.AyushmanBharat.Domain.Common;

namespace Drona.AyushmanBharat.Domain.Entities.ABDM.HPR.HPRMaster
{
    public class MedicineSystem : EntityBase
    {
        public int MedicineSystemId { get; set; }
        public string? MedincineSystemName { get; set; }
        public ICollection<DoctorCouncil>? Councils { get; set; }
        public ICollection<DoctorDegree>? Degrees { get; set; }
        public ICollection<DoctorSpeciality>? Specialities { get; set; }
        public ICollection<DoctorUniversity>? Universities { get; set; }
    }
}
