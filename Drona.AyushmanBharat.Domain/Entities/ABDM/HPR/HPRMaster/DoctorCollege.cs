#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using Drona.AyushmanBharat.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drona.AyushmanBharat.Domain.Entities.ABDM.HPR.HPRMaster
{
    public class DoctorCollege : EntityBase
    {
        public int HprCollegeId { get; set; }

        public string CollegeName { get; set; }

        public string State { get; set; }

        [ForeignKey("HprUniversityId")]
        public int HprUniversityId { get; set; }
        public DoctorUniversity HprUniversity { get; set; }
    }
}
