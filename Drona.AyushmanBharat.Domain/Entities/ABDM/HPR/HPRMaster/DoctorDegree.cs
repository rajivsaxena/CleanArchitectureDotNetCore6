using Drona.AyushmanBharat.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drona.AyushmanBharat.Domain.Entities.ABDM.HPR.HPRMaster
{
    public class DoctorDegree : EntityBase
    {
        public int DegreeId { get; set; }
        public string? DegreeName { get; set; }
        [ForeignKey("MedicineSystemId")]
        public int MedicineSystemId { get; set; }
        public MedicineSystem MedicineSystem { get; set; }
    }
}
