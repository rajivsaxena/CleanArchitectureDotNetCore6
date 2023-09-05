using Drona.AyushmanBharat.Domain.Common;

namespace Drona.AyushmanBharat.Domain.Entities.ABDM.HPR
{
    public class RegisterProfessionalDto : EntityBase
    {
        public Guid? TxnId { get; set; }
        public string? ReferenceNumber { get; set; }
        public bool Status { get; set; }
        public string? HprId { get; set; }
        public string? Message { get; set; }
    }
}
