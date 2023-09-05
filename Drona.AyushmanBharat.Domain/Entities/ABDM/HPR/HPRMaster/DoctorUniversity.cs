using Drona.AyushmanBharat.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Drona.AyushmanBharat.Domain.Entities.ABDM.HPR.HPRMaster
{
    public class DoctorUniversity : EntityBase
    {
        public int HprUniversityId { get; set; }
        public string UniversityName { get; set; }
        [ForeignKey("MedicineSystemId")]
        public int MedicineSystemId { get; set; }
        public MedicineSystem MedicineSystem { get; set; }
        public ICollection<DoctorCollege>? DoctorColleges { get; set; }
    }
}
