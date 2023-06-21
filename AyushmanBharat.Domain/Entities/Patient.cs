using AyushmanBharat.Domain.Common;

namespace AyushmanBharat.Domain.Entities
{
    public class Patient : EntityBase
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? AadharNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? Gender { get; set; }
        public string? HealthId { get; set; }
        public string? HealthIdNumber { get; set; }
    }
}
