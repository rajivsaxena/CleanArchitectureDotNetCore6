using Drona.AyushmanBharat.Domain.Common;

namespace Drona.AyushmanBharat.Domain.Entities.ABDM.HPR
{
    public class HprTransaction : EntityBase
    {
        public Guid? TxnId { get; set; }
        public string? MobileNumber { get; set; }
        public int ProgressStep { get; set; }
    }
}
