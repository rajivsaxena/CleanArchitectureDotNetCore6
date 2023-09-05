using Drona.AyushmanBharat.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drona.AyushmanBharat.Domain.Entities.ABDM.HPR.HPRMaster
{
    public  class DoctorCouncil : EntityBase
    {
        public int CouncilId { get; set; }
        public string? CouncilName { get; set; }

        [ForeignKey("MedicineSystemId")]
        public int MedicineSystemId { get; set; }
        public MedicineSystem MedicineSystem { get; set; }
    }
}
