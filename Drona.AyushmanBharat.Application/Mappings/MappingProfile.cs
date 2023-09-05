using AutoMapper;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddGenerateAAdhaarOtp;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddGenerateMobileOtp;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddHprId;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddRegisterProfessional;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddVerifyAadhaarOtp;
using Drona.AyushmanBharat.Application.Features.HPR.Commands.AddVerifyMobileOtp;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetAadhaarOtp;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorColleges;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorCouncils;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorDegrees;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorSpecialities;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetDoctorUniversities;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetLanguages;
using Drona.AyushmanBharat.Application.Features.HPR.Queries.GetMedicineSystems;
using Drona.AyushmanBharat.Application.Features.Patients.Commands.AddPatient;
using Drona.AyushmanBharat.Application.Features.Patients.Commands.UpdatePatient;
using Drona.AyushmanBharat.Application.Features.Patients.Queries.GetPatient;
using Drona.AyushmanBharat.Domain.Entities;
using Drona.AyushmanBharat.Domain.Entities.ABDM.HPR;
using Drona.AyushmanBharat.Domain.Entities.ABDM.HPR.HPRMaster;

namespace Drona.AyushmanBharat.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientVm>().ReverseMap();
            CreateMap<Patient, AddPatientCommand>().ReverseMap();
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
            CreateMap<HprTransaction, AddGenerateAadhaarOtpCommand>().ReverseMap();
            CreateMap<HprTransaction, AadhaarOtpResponseVm> ().ReverseMap();
            CreateMap<HprTransaction, VerifyAadhaarOtpCommand>().ReverseMap();
            CreateMap<HprTransaction, GenerateMobileOtpCommand>().ReverseMap(); 
            CreateMap<HprTransaction, AddVerifyMobileOtpCommand>().ReverseMap();
            CreateMap<HprTransaction, CreateHprIdCommand>().ReverseMap();
            CreateMap<RegisterProfessionalDto, AddRegisterProfessionalCommand>().ReverseMap();
            CreateMap<MedicineSystem, MedicineSystemVm>().ReverseMap();
            CreateMap<LanguageSpoken, LanguageVm>().ReverseMap();
            CreateMap<DoctorCouncil, DoctorCouncilVm>().ReverseMap();
            CreateMap<DoctorDegree, DoctorDegreeVm>().ReverseMap();
            CreateMap<DoctorSpeciality, DoctorSpecialityVm>().ReverseMap();
            CreateMap<DoctorUniversity, DoctorUniversityVm>().ReverseMap();
            CreateMap<DoctorCollege, DoctorCollegeVm>().ReverseMap();
        }
    }
}
