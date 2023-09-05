namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR.UploadDocument
{
    public class FetchDocumentsListResponse : ApiError
    {
        [Newtonsoft.Json.JsonProperty("documentList")]
        public Documentlist? DocumentList { get; set; }

        public class Documentlist
        {
            [Newtonsoft.Json.JsonProperty("profileDetails")]
            public Profiledetails? ProfileDetails { get; set; }

            [Newtonsoft.Json.JsonProperty("registrationDetails")]
            public ICollection<Registrationdetail>? RegistrationDetails { get; set; }

            [Newtonsoft.Json.JsonProperty("qualificationDetails")]
            public ICollection<Qualificationdetail>? QualificationDetails { get; set; }
        }

        public class Profiledetails
        {
            [Newtonsoft.Json.JsonProperty("profilePhoto")]
            public Profilephoto? ProfilePhoto { get; set; }

            [Newtonsoft.Json.JsonProperty("proofOfWorkCertificate")]
            public Proofofworkcertificate? ProofOfWorkCertificate { get; set; }
        }

        public class Profilephoto
        {
            [Newtonsoft.Json.JsonProperty("id")]
            public int Id { get; set; }
        }

        public class Proofofworkcertificate
        {
            [Newtonsoft.Json.JsonProperty("id")]
            public int Id { get; set; }
        }

        public class Registrationdetail
        {
            [Newtonsoft.Json.JsonProperty("registrationCertificate")]
            public Registrationcertificate? RegistrationCertificate { get; set; }

            [Newtonsoft.Json.JsonProperty("proofOfNameChangeRegCertificate")]
            public Proofofnamechangeregcertificate? ProofOfNameChangeRegCertificate { get; set; }
        }

        public class Registrationcertificate
        {
            [Newtonsoft.Json.JsonProperty("id")]
            public int Id { get; set; }

            [Newtonsoft.Json.JsonProperty("systemOfMedicide")]
            public string? SystemOfMedicide { get; set; }
        }

        public class Proofofnamechangeregcertificate
        {
            [Newtonsoft.Json.JsonProperty("id")]
            public int Id { get; set; }

            [Newtonsoft.Json.JsonProperty("systemOfMedicide")]
            public string? SystemOfMedicide { get; set; }
        }

        public class Qualificationdetail
        {
            [Newtonsoft.Json.JsonProperty("degreeCertificate")]
            public Degreecertificate? DegreeCertificate { get; set; }

            [Newtonsoft.Json.JsonProperty("proofOfNameChangeQualCertificate")]
            public Proofofnamechangequalcertificate? ProofOfNameChangeQualCertificate { get; set; }
        }

        public class Degreecertificate
        {
            [Newtonsoft.Json.JsonProperty("id")]
            public int Id { get; set; }

            [Newtonsoft.Json.JsonProperty("courseName")]
            public string? CourseName { get; set; }

            [Newtonsoft.Json.JsonProperty("qualificationYear")]
            public string? QualificationYear { get; set; }
        }

        public class Proofofnamechangequalcertificate
        {
            [Newtonsoft.Json.JsonProperty("id")]
            public int Id { get; set; }

            [Newtonsoft.Json.JsonProperty("courseName")]
            public string? CourseName { get; set; }

            [Newtonsoft.Json.JsonProperty("qualificationYear")]
            public string? QualificationYear { get; set; }
        }

    }
}
