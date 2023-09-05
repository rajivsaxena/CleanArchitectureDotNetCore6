using Drona.AyushmanBharat.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drona.AyushmanBharat.Domain.Entities.ABDM.HPR.HPRMaster
{
    public class DoctorSpeciality : EntityBase
    {
        public int HprSpcialityId { get; set; }

        public string? SpecialityName { get; set; }

        [ForeignKey("MedicineSystemId")]
        public int MedicineSystemId { get; set; }
        public MedicineSystem MedicineSystem { get; set; }
    }
}
