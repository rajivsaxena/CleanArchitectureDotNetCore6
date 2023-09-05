namespace Drona.AyushmanBharat.Application.Features.HPR.Queries.GetAadhaarOtp
{
    public class AadhaarOtpResponseVm
    {
        public Guid? TxnId { get; set; }
        public string? MobileNumber { get; set; }
        public int ProgressStep { get; set; }
        public int Id { get; protected set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
