namespace Drona.AyushmanBharat.Application.Models.ABDM.HPR
{
    public class RegisterProfessionalRequest
    {
        public string? hprToken { get; set; }
        public Practitioner? practitioner { get; set; }
    }
    public class Practitioner
    {
        public string? profilePhoto { get; set; }
        public string? healthProfessionalType { get; set; }
        public string? officialMobileCode { get; set; }
        public string? officialMobile { get; set; }
        public string? officialMobileStatus { get; set; }
        public string? officialEmail { get; set; }
        public string? officialEmailStatus { get; set; }
        public string? visibleProfilePicture { get; set; }
        public Personalinformation? personalInformation { get; set; }
        public string? addressAsPerKYC { get; set; }
        public Communicationaddress? communicationAddress { get; set; }
        public Contactinformation? contactInformation { get; set; }
        public Registrationacademic? registrationAcademic { get; set; }
        public Speciality[]? specialities { get; set; }
        public Currentworkdetails? currentWorkDetails { get; set; }
    }
    public class Personalinformation
    {
        public string? salutation { get; set; }
        public string? firstName { get; set; }
        public string? middleName { get; set; }
        public string? lastName { get; set; }
        public string? fatherName { get; set; }
        public string? motherName { get; set; }
        public string? spouseName { get; set; }
        public string? nationality { get; set; }
        public string? placeOfBirthState { get; set; }
        public string? district { get; set; }
        public string? subDistrict { get; set; }
        public string? city { get; set; }
        public string? languagesSpoken { get; set; }
    }

    public class Communicationaddress
    {
        public string? isCommunicationAddressAsPerKYC { get; set; }
        public string? address { get; set; }
        public string? name { get; set; }
        public string? country { get; set; }
        public string? state { get; set; }
        public string? district { get; set; }
        public string? subDistrict { get; set; }
        public string? city { get; set; }
        public int postalCode { get; set; }
    }
    public class Contactinformation
    {
        public string? publicMobileNumber { get; set; }
        public string? publicMobileNumberCode { get; set; }
        public string? publicMobileNumberStatus { get; set; }
        public string? landLineNumber { get; set; }
        public string? landLineNumberCode { get; set; }
        public string? publicEmail { get; set; }
        public string? publicEmailStatus { get; set; }
    }

    public class Registrationacademic
    {
        public string? category { get; set; }
        public Registrationdata[]? registrationData { get; set; }
    }
    public class Registrationdata
    {
        public string? registeredWithCouncil { get; set; }
        public string? registrationNumber { get; set; }
        public string? registrationCertificate { get; set; }
        public string? isNameDifferentInCertificate { get; set; }
        public string? proofOfNameChangeCertificate { get; set; }
        public string? categoryId { get; set; }
        public Qualification[]? qualifications { get; set; }
    }

    public class Qualification
    {
        public string? nameOfDegreeOrDiplomaObtained { get; set; }
        public string? country { get; set; }
        public string? state { get; set; }
        public string? college { get; set; }
        public string? university { get; set; }
        public string? monthOfAwardingDegreeDiploma { get; set; }
        public string? yearOfAwardingDegreeDiploma { get; set; }
        public string? degreeCertificate { get; set; }
        public string? isNameDifferentInCertificate { get; set; }
        public string? proofOfNameChangeCertificate { get; set; }
    }
    public class Currentworkdetails
    {
        public string? currentlyWorking { get; set; }
        public string? purposeOfWork { get; set; }
        public string? chooseWorkStatus { get; set; }
        public string? reasonForNotWorking { get; set; }
        public string? certificateAttachment { get; set; }
        public Facilitydeclarationdata? facilityDeclarationData { get; set; }
    }
    public class Facilitydeclarationdata
    {
        public string? facilityId { get; set; }
        public string? facilityName { get; set; }
        public string? facilityAddress { get; set; }
        public string? facilityPincode { get; set; }
        public string? state { get; set; }
        public string? district { get; set; }
        public string? facilityType { get; set; }
        public string? facilityDepartment { get; set; }
        public string? facilityDesignation { get; set; }
    }

    public class Speciality
    {
        public string? speciality { get; set; }
        public string? subSpecialities { get; set; }
    }
}
