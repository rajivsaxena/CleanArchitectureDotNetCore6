using AutoMapper;
using AyushmanBharat.Application.Features.Patients.Commands.AddPatient;
using AyushmanBharat.Application.Features.Patients.Commands.UpdatePatient;
using AyushmanBharat.Application.Features.Patients.Queries.GetPatient;
using AyushmanBharat.Domain.Entities;

namespace AyushmanBharat.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientVm>().ReverseMap();
            CreateMap<Patient, AddPatientCommand>().ReverseMap();
            CreateMap<Patient, UpdatePatientCommand>().ReverseMap();
        }
    }
}
