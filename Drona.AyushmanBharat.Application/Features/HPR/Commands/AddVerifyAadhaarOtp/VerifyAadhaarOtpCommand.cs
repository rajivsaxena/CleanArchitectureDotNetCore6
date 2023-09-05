using MediatR;

namespace Drona.AyushmanBharat.Application.Features.HPR.Commands.AddVerifyAadhaarOtp
{
    public class VerifyAadhaarOtpCommand : IRequest<int>
    {
        /// <summary>
        /// Based on UUID
        /// </summary>
        public System.Guid TxnId { get; set; }

        /// <summary>
        /// Mobile number of the user.
        /// </summary>
        public string? MobileNumber { get; set; }

        /// <summary>
        /// Base64 string KYC Photo
        /// </summary>
        public ICollection<byte[]>? Photo { get; set; }

        /// <summary>
        /// Gender of the User, M-Male, F-Female, T-Transgender
        /// </summary>
        public string? Gender { get; set; }

        /// <summary>
        /// Name of the User
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Email of the user
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Pincode
        /// </summary>
        public string? Pincode { get; set; }

        /// <summary>
        /// Date of Birth(dd-MM-YYY) or Year of Birth(YYYY).
        /// </summary>
        public string? Birthdate { get; set; }

        /// <summary>
        /// Care of
        /// </summary>
        public string? CareOf { get; set; }

        /// <summary>
        /// house
        /// </summary>
        public string? House { get; set; }

        /// <summary>
        /// street
        /// </summary>
        public string? Street { get; set; }

        /// <summary>
        /// Landmark
        /// </summary>
        public string? Landmark { get; set; }

        /// <summary>
        /// locality
        /// </summary>
        public string? Locality { get; set; }

        /// <summary>
        /// village Town City
        /// </summary>
        public string? VillageTownCity { get; set; }

        /// <summary>
        /// Subdistrict Name
        /// </summary>
        public string? SubDist { get; set; }

        /// <summary>
        /// District Name
        /// </summary>
        public string? District { get; set; }

        /// <summary>
        /// State Name
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// Post office
        /// </summary>
        public string? PostOffice { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string? Address { get; set; }

        private IDictionary<string, object>? _additionalProperties;

        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }
        public int ProgressStep { get; set; }

    }
}
